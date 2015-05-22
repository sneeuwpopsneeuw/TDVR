using UnityEngine;
using System.Collections;

public class SignalSender : MonoBehaviour {


    class ReceiverItem {
	    public GameObject receiver;
	    public string action = "OnSignal";
	    public float delay;
	
	    public void SendWithDelay ( MonoBehaviour sender  ){
		    //yield WaitForSeconds (delay);  // yield mag je niet in een class gebruiken
		    if (receiver)
			    receiver.SendMessage (action);
		    else
			    Debug.LogWarning ("No receiver of signal \""+action+"\" on object "+sender.name+" ("+sender.GetType().Name+")", sender);
	    }
    }

    class _SignalSender {
	    public bool  onlyOnce;
	    public ReceiverItem[] receivers;
	
	    private bool  hasFired = false;
	
	    public void SendSignals ( MonoBehaviour sender  ){
		    if (hasFired == false || onlyOnce == false) {
			    for (float i = 0; i < receivers.length; i++) {
				    sender.StartCoroutine (receivers[i].SendWithDelay(sender));
			    }
			    hasFired = true;
		    }
	    }
    }
}