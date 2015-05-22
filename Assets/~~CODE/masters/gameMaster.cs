/// <summary>
/// Timo Strating
/// 3 3 2015
/// gameMaster.cs
///     Dit is de gameMaster die de game beheerd 
///     De gamaMaster:
///         kan niet vernietigd worden ook niet als er van scene wordt gewisseld
///         wordt enkel en alleen in het menu aangemaakt
///         kan data bewaren dat in meerdere scene's nodig is
/// </summary>

using UnityEngine;
using System.Collections;

public class gameMaster : MonoBehaviour {
     //settings
    public bool useVRCamera = true;                     // bool gebruik VRCamera (used in VRMaster.cs)
    public bool useFading = true;                       // bool gebruik fading
    public bool CursorLock = true;                      // bool lock cursor in het midden van het scherm

     //camera
    //public GameObject BackUpCamera;
    public GameObject listNotVr;
    public GameObject listVr;

     //player
    //public Transform spawnpoint;                        // player spawn point
    //public GameObject player;                           // player GameObject

     //cheatSheet
	public GameObject cheatSheetPrefab;                 // de prefab waar een clone van wordt gemaakt
    public bool cheatSheetIsOpend = false;              // of de cheatSheet is geopend

    private GameObject cheatSheetPrefabClone;           // het kopie van de prefab dat in de wereld wordt gezet


     // fading
    //public Texture2D fadeOutTexture;                    // 
    //public float fadeSpeed = 0.8f;

    //private int drawDepth = -1000;
    //private float alpa = 1.0f;
    //private int fadeDir = -1;




	// gebruik dit om dingen te doen voordat de scene is geladen
	void Awake() {
        // de game master wordt aangemaakt in de MENU scene en wordt doorgegeven van scene naar scene
        DontDestroyOnLoad(transform.gameObject);
	}

    void Start() {
        //StartCoroutine(fadeAfterSeconds(1));
        //StartCoroutine(CameraSwitching());
    }

    /*void OnGUI() {
        // fade out in real seconds
        alpa += fadeDir * fadeSpeed * Time.deltaTime;

        // force (Clamp) a number between 0 and 1 for alpa. Is neded for GUI.color to work properly
        alpa = Mathf.Clamp01(alpa);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpa);             // set the alpha
        GUI.depth = -1000;                                                              // use layer -1000 most upper layer
        GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);   // draw
    }

    public float BeginFade(int direction) {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded( int level) {
        BeginFade(-1);
        StartCoroutine(fadeAfterSeconds(1));
    }

    IEnumerator fadeAfterSeconds(int seconds) {
        fadeDir = 1;
        yield return new WaitForSeconds(seconds);
        fadeDir = -1;
    }


    /*IEnumerator CameraSwitching() {
        BackUpCamera.SetActive(true);
        normalCamera.SetActive(false);
        VRCamera.SetActive(false);

        yield return new WaitForSeconds(2);

        BackUpCamera.SetActive(false);
        normalCamera.SetActive(false);
        VRCamera.SetActive(true);
    } */


	// De Update wordt iedere Frame aangeroepen
	void Update () {
        //print(fadeDir);
        if (Input.GetKey(KeyCode.Q))
            Cursor.lockState = CursorLockMode.Locked;
        else if (Input.GetKey(KeyCode.E))
            Cursor.lockState = CursorLockMode.None;

		// Toggle CheatSheetScreen
		if (Input.GetKeyDown(KeyCode.BackQuote) ) {
			if (!cheatSheetIsOpend) {
                // Clone = (GameObject)GameObject.Instantiate(cheatSheetPrefab, new Vector3(5, 5, 5), Quaternion.identity);
				cheatSheetPrefabClone = (GameObject)GameObject.Instantiate(cheatSheetPrefab);
                //PauseStart();
                cheatSheetIsOpend = !cheatSheetIsOpend;
			}
			else if (cheatSheetIsOpend) { 
				Destroy(cheatSheetPrefabClone, 0);
                //PauseStop();
                cheatSheetIsOpend = !cheatSheetIsOpend;
			}
		}

        // Quit
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Quit();
        }

        // Toggle Fullscreen
        if (Input.GetKeyDown(KeyCode.F11))
        {
            Screen.fullScreen = !Screen.fullScreen;
            Debug.Log("FullScreen = active");
        }
	}


    // start het volgende level
    public void Nextlevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void loadLevelOnName(string levelName) {
        Application.LoadLevel(levelName.ToString());
    }

    // public test die enkel als beschikbaarheids test geld
	public void DebugTest (string text) {
		Debug.Log(text);
	}

    // public pause 
    public void PauseStart() {
        Time.timeScale = 0;
    }

    // public pause 
    public void PauseStop() {
        Time.timeScale = 1;
    }

    // public quit die unity altijd stop zet
	public void Quit () {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}