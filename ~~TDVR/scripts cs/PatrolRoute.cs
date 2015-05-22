using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatrolRoute : MonoBehaviour {


    // TODO: Wait for this - will work in 3.3f
    //import System.Collections.Generic;

    //@script RequireComponent (Collider)
    [RequireComponent (typeof (Rigidbody))]

    public bool  pingPong = false;
    // TODO: In Unity 3.3f remove the System.Collections.Generic and impoprt the namespace instead
    //public System.Collections.Generic.List.patrolPoints<PatrolPoint> = new System.Collections.Generic.List<PatrolPoint>();

    //private System.Collections.Generic.List.activePatrollers<GameObject> = new System.Collections.Generic.List<GameObject>();

    public void Register ( GameObject go  ){
	    activePatrollers.Add (go);
    }

    public void UnRegister ( GameObject go  ){
	    activePatrollers.Remove (go);
    }

    void OnTriggerEnter ( Collider other  ){
	    if (activePatrollers.Contains (other.gameObject)) {
		    AI ai = other.gameObject.GetComponentInChildren<AI> ();
		    if (ai)
			    ai.OnEnterInterestArea ();
	    }
    }

    void OnTriggerExit ( Collider other  ){
	    if (activePatrollers.Contains (other.gameObject)) {
		    AI ai = other.gameObject.GetComponentInChildren<AI> ();
		    if (ai)
			    ai.OnExitInterestArea ();
	    }
    }

    public int GetClosestPatrolPoint ( Vector3 pos  ){
	    if (patrolPoints.Count == 0)
		    return 0;
	
	    float shortestDist = Mathf.Infinity;
	    int shortestIndex = 0;
	    for (int i = 0; i < patrolPoints.Count; i++) {
		    patrolPoints[i].position = patrolPoints[i].transform.position;
		    float dist = (patrolPoints[i].position - pos).sqrMagnitude;
		    if (dist < shortestDist) {
			    shortestDist = dist;
			    shortestIndex = i;
		    }
	    }
	
	    // If going towards the closest point makes us go in the wrong direction,
	    // choose the next point instead.
	    if (!pingPong || shortestIndex < patrolPoints.Count - 1) {
		    int nextIndex = (shortestIndex + 1) % patrolPoints.Count;
		    float angle = Vector3.Angle (
			    patrolPoints[nextIndex].position - patrolPoints[shortestIndex].position,
			    patrolPoints[shortestIndex].position - pos
		    );
		    if (angle > 120)
			    shortestIndex = nextIndex;
	    }
	
	    return shortestIndex;
    }

    void OnDrawGizmos (){
	    if (patrolPoints.Count == 0)
		    return;
	
	    Gizmos.color = Color (0.5f, 0.5f, 1.0f);
	
	    Vector3 lastPoint = patrolPoints[0].transform.position;
	    FIXME_VAR_TYPE loopCount= patrolPoints.Count;
	    if (pingPong)
		    loopCount--;
	    for (int i = 0; i < loopCount; i++) {
		    if (!patrolPoints[i])
			    break;
		    FIXME_VAR_TYPE newPoint= patrolPoints[(i + 1) % patrolPoints.Count].transform.position;
		    Gizmos.DrawLine (lastPoint, newPoint);
		    lastPoint = newPoint;
	    }
    }

    public void GetIndexOfPatrolPoint ( PatrolPoint point  ){
	    for (int i = 0; i < patrolPoints.Count; i++) {
		    if (patrolPoints[i] == point)
			    return i;
	    }
	    return -1;
    }

    GameObject InsertPatrolPointAt ( int index  ){
	    FIXME_VAR_TYPE go= new GameObject ("PatrolPoint", PatrolPoint);
	    go.transform.parent = transform;
	    int count = patrolPoints.Count;
	
	    if (count == 0) {
		    go.transform.localPosition = Vector3.zero;
		    patrolPoints.Add(go.GetComponent<PatrolPoint>());
	    }
	    else {
		    if (!pingPong || (index > 0 && index < count) || count < 2) {
			    index = index % count;
			    int prevIndex = index - 1;
			    if (prevIndex < 0)
				    prevIndex += count;
			
			    go.transform.position = (
				    patrolPoints[prevIndex].transform.position
				    + patrolPoints[index].transform.position
			    ) * 0.5f;
		    }
		    else if (index == 0) {
			    go.transform.position = (
				    patrolPoints[0].transform.position * 2
				    - patrolPoints[1].transform.position
			    );
		    }
		    else {
			    go.transform.position = (
				    patrolPoints[count-1].transform.position * 2
				    - patrolPoints[count-2].transform.position
			    );
		    }
		    patrolPoints.Insert(index, go.GetComponent<PatrolPoint>());
	    }
	
	    return go;
    }

    public void RemovePatrolPointAt ( int index  ){
	    GameObject go = patrolPoints[index].gameObject;
	    patrolPoints.RemoveAt (index);
	    DestroyImmediate (go);
    }
}