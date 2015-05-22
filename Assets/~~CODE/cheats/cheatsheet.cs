/// <summary>
/// Timo Strating
/// 28 2 2015
/// CheatSheet.cs
///     Dit opend een scherm dat cheats bevat (CHEAT)
/// </summary>
using UnityEngine;
using System.Collections;

public class CheatSheet : MonoBehaviour {
	private GameObject gameMasterObject;            // dit is het object dat de game master script bevat
	private gameMaster gameMaster;                  // dit is het scrpt van het object

    // gebruik dit voor initialization
	void Start () {
        // gameMaster script wordt gepakt 
		gameMasterObject = GameObject.Find("_GM");
		gameMaster = gameMasterObject.GetComponent<gameMaster>();
	}

    // De Update wordt iedere Frame aangeroepen
	void Update () {
	
	}

    // laad het level dat je hem geeft als nummer
	public void LoadlevelOnNumber(int levelnumber) {
		Application.LoadLevel(levelnumber);
	}

    // het level dat je hem geeft als naam
	public void LoadlevelOnName(string levelname) {
		Application.LoadLevel(levelname.ToString());
	}

    // vernietigd het object wat je aan hem geeft
	public void Destroy(GameObject destoyable) {
		Destroy(destoyable, 0.1f);
		gameMaster.cheatSheetIsOpend = false;
	}
}