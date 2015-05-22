/// <summary>
/// Timo Strating
/// 12 3 2015
/// deadTrigger.cs
///     Dit script wordt tijdelijk gebruikt om de game te testen (TEST)
/// </summary>
using UnityEngine;
using System.Collections;

public class DeadTrigger : MonoBehaviour {
    // dit laad het level opnieuw op het moment dat er een collider tegen aan komt
    // TODO: Het weet niet welk object er in komt
    //       een box reset de game dus ook
    void OnTriggerEnter(Collider other)
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
