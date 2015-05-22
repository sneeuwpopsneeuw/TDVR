/// <summary>
/// Timo Strating
/// 2 3 2015
/// collision.cs
///     collision test (TEST)
/// </summary>
using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour {

    // Debug bij eerste collision
	void OnCollisionEnter(Collision collision) {
		Debug.Log("Collission Enter");
	}

    // Debug bij de rest van de collision's
	void OnCollisionStay(Collision collision) {
		Debug.Log("Collission Stay");
	}

    // Debug bij de laatste collision
	void OnCollisionExit(Collision collision) {
		Debug.Log("Collission Exit");
	}
}
