using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {

    //public
	public GameObject standbyCamera;

    public string recourcePlayerName = "VRNetworkSnowman"; 

	public bool offlineMode = false;

    public float respawnTimer = 0;


    // private
    private SpawnSpot[] spawnSpots;

	private bool connecting = false;

      // message
	private List<string> chatMessages;
	private int maxChatMessages = 5;

      // team
	private bool hasPickedTeam = false;
	private int teamID=0;
    private bool addPlayerOnce = false;

    private GameObject networkMenu;


	// Use this for initialization
	void Start () {
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();
		PhotonNetwork.player.name = PlayerPrefs.GetString("Username", "Awesome Dude");
		chatMessages = new List<string>();

        networkMenu = GameObject.Find("_NMe");
        if (networkMenu != null) {
            Connect();
            connecting = true;
            addPlayerOnce = true;
        }
	}

	void OnDestroy() {
		PlayerPrefs.SetString("Username", PhotonNetwork.player.name);
	}

	public void AddChatMessage(string m) {
		GetComponent<PhotonView>().RPC ("AddChatMessage_RPC", PhotonTargets.AllBuffered, m);
	}

	[RPC]
	void AddChatMessage_RPC(string m) {
		while(chatMessages.Count >= maxChatMessages) {
			chatMessages.RemoveAt(0);
		}
		chatMessages.Add(m);
	}

	void Connect() {
        PhotonNetwork.ConnectUsingSettings("TDVR v005");    // gebruik de settings file en gebruik de volgende versie naam:  MultiFPS v005
	}
	 
	void OnGUI() {
		GUILayout.Label( PhotonNetwork.connectionStateDetailed.ToString() );    // de netwerk status
        if (networkMenu == null) {
            if (PhotonNetwork.connected == false && connecting == false) {
                // We have not yet connected, so ask the player for online vs offline mode.
                GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical();
                GUILayout.FlexibleSpace();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Username: ");
                PhotonNetwork.player.name = GUILayout.TextField(PhotonNetwork.player.name);
                GUILayout.EndHorizontal();

                if (GUILayout.Button("Single Player")) {
                    connecting = true;
                    PhotonNetwork.offlineMode = true;
                    OnJoinedLobby();
                }

                if (GUILayout.Button("Multi Player")) {
                    connecting = true;
                    Connect();
                }

                GUILayout.FlexibleSpace();
                GUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
            }

            if (PhotonNetwork.connected == true && connecting == false) {

                if (hasPickedTeam) {
                    // We are fully connected, make sure to display the chat box.
                    GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
                    GUILayout.BeginVertical();
                    GUILayout.FlexibleSpace();

                    foreach (string msg in chatMessages) {
                        GUILayout.Label(msg);
                    }

                    GUILayout.EndVertical();
                    GUILayout.EndArea();
                } else {
                    // Player has not yet selected a team.

                    GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    GUILayout.BeginVertical();
                    GUILayout.FlexibleSpace();

                    if (GUILayout.Button("Red Team")) {
                        SpawnMyPlayer(1);
                    }

                    if (GUILayout.Button("Blue Team")) {
                        SpawnMyPlayer(2);
                    }

                    if (GUILayout.Button("Random")) {
                        SpawnMyPlayer(Random.Range(1, 3));	// 1 or 2
                    }

                    if (GUILayout.Button("Renegade!")) {
                        SpawnMyPlayer(0);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndVertical();
                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();
                    GUILayout.EndArea();
                }
            }
        }
	}


    // verbonden met de server 
	void OnJoinedLobby() {
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed() {
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom( null );
	}

	void OnJoinedRoom() {
		Debug.Log ("OnJoinedRoom");

		connecting = false;
		//SpawnMyPlayer();
	}

	void SpawnMyPlayer(int teamID) {
		this.teamID = teamID;
		hasPickedTeam = true;
		AddChatMessage("Spawning player: " + PhotonNetwork.player.name);

		if(spawnSpots == null) {
			Debug.LogError ("Geen spawnpoints");
			return;
		}

        standbyCamera.SetActive(false);

		SpawnSpot mySpawnSpot = spawnSpots[ Random.Range (0, spawnSpots.Length) ];
        GameObject myPlayerGO = (GameObject)PhotonNetwork.Instantiate(recourcePlayerName, mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
        print("PhotonNetwork.Instantiate: " + myPlayerGO.name);

		//((MonoBehaviour)myPlayerGO.GetComponent("FPSInputController")).enabled = true;
		((MonoBehaviour)myPlayerGO.GetComponent("PlayerController")).enabled = true;
        ((MonoBehaviour)myPlayerGO.GetComponent<MouseLook>()).enabled = true;

		myPlayerGO.GetComponent<PhotonView>().RPC ("SetTeamID", PhotonTargets.AllBuffered, teamID);

		//myPlayerGO.transform.FindChild("Main Camera").gameObject.SetActive(true);
        myPlayerGO.transform.FindChild("CameraVR").gameObject.SetActive(true);
	}

	void Update() {
        if (connecting == false && addPlayerOnce == true) {
            PhotonNetwork.player.name = "player" + Random.Range(1, 999);
            SpawnMyPlayer(networkMenu.GetComponent<NetworkMenu>().teamID);
            Destroy(networkMenu, 1f);
            addPlayerOnce = false;
        }

		if(respawnTimer > 0) {
			respawnTimer -= Time.deltaTime;

			if(respawnTimer <= 0) {
				// Time to respawn the player!
				SpawnMyPlayer(teamID);
			}
		}
	}
}
