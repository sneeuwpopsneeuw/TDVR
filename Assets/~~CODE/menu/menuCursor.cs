/// <summary>
/// Timo Strating
/// 10 3 2015
/// menuCursor.cs
///     Dit is het script dat wordt gebruikt om data van de cursor door te geven aan andere scripts
/// </summary>
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuCursor : MonoBehaviour {
    public GameObject MenuMaster;           // dit is een reverentie naar de menuMaster.cs
                                            // dit is een script waar data heen gestuurd wordt

    // Debug bij Stay van een collider  ( stay wordt iedere frame gecheckt )
    void OnTriggerStay(Collider other) {
        // als er op spatie wordt gedrukt en het dat binnen de trigger zit bevat een VRButton.cs script wordt er verder gegaan
        if (Input.GetKeyDown(KeyCode.Space) && other.GetComponent<VRButton>() != null) {
            other.GetComponent<VRButton>().launchScreen();
        }
    }
}
