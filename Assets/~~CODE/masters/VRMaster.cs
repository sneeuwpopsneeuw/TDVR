using UnityEngine;
using System.Collections;

public class VRMaster : MonoBehaviour {
    // public bool useVRCamera      staat in de gameMaster.cs zodat die in alle scenes gelijk is.
    public GameObject normalCamera;
    public GameObject VRCamera;

	// Use this for initialization
	void Awake () {
        normalCamera.SetActive(false);
        VRCamera.SetActive(false);
        if (FindObjectOfType<gameMaster>().useVRCamera)
            VRCamera.SetActive(true);
        else
            normalCamera.SetActive(true);
	}
}
