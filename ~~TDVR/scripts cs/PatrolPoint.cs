using UnityEngine;
using System.Collections;

public class PatrolPoint : MonoBehaviour {


    private Vector3 position;

    void Awake (){
	    position = transform.position;
    }
}