/// <summary>
/// Timo Strating
/// 2 3 2015
/// trigger.cs
///     trigger test (TEST)
/// </summary>
using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour {

    // Debug bij enter van een collider 
	void OnTriggerEnter(Collider other) {
		Debug.Log ("Trigger Enter");
	}

    // Debug bij Stay van een collider  ( stay wordt iedere frame gecheckt )
	void OnTriggerStay(Collider other) {
		Debug.Log ("Trigger Stay");
	}

    // Debug bij Exit van een collider 
	void OnTriggerExit(Collider other) {
		Debug.Log ("Trigger Exit");
	}
}
