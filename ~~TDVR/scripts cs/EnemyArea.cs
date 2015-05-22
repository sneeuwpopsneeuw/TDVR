using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyArea : MonoBehaviour {


    //public GameObject affected : List.<GameObject> = new List.<GameObject> ();
    
    //ActivateAffected (false);

    void OnTriggerEnter ( Collider other ){
        if (other.tag == "Player") { }
		    //ActivateAffected (true);
    }

    void OnTriggerExit ( Collider other ){
        if (other.tag == "Player") { }
		    //ActivateAffected (false);
    }

    /*void ActivateAffected ( bool state ){
	     foreach(GameObject go in affected) {
		    if (go == null)
			    continue;
		    go.SetActive (state);
		    yield return 0;
	    }
	    foreach(Transform tr in transform) {
		    tr.gameObject.SetActive (state);
		    yield return 0;
	    }
    } */
}