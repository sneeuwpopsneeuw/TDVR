using UnityEngine;
using System.Collections;

 /// <summary>
 /// 
 /// dingen om te doen
 ///    lobby
 ///    naam
 ///    room
 ///    team
 ///    player spawn
 ///        team id
 ///        spawn position 
 ///        turn off items, turn on items
 ///        camera
 ///    respawn
 ///    
 /// </summary>


public class networkMaster : MonoBehaviour {

    //public
    public GameObject standbyCamera;

    public string recourcePlayerName = "VRNetworkSnowman";


    // private
    private bool connecting = false;

    private bool dontDestroyOnLoad = true;

      // settings
    private string playerName;



    void Awake() {
        if (dontDestroyOnLoad) {
            DontDestroyOnLoad(transform.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ConnectWithName( string playerName) {
        PhotonNetwork.player.name = playerName;
        PhotonNetwork.ConnectUsingSettings("TDVR v002");    // gebruik de settings file en gebruik de volgende versie naam:  MultiFPS v005
    }
}
