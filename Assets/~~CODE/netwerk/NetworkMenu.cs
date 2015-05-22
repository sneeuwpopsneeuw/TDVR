using UnityEngine;
using System.Collections;

public class NetworkMenu : MonoBehaviour {

    public int teamID;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void UseTeamID(int teamIDInvoer) {
        Application.LoadLevel("multiplayer");
    }
}
