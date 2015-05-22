/// <summary>
/// Timo Strating
/// 16 3 2015
/// VRButton.cs
///     Dit script wordt gebruikt om 3d knoppen te maken
///         VRButton heeft minimaal een object nodig dat het actiev kan zetten 
///         en het heeft een collider nodig om te werken
/// </summary>
using UnityEngine;
using System.Collections;

public enum Fuctions {
    None,
    LoadMultiplayer,
    LoadMultiplayerMenu,
    LoadLevel1
}

[RequireComponent( typeof (BoxCollider)) ]
public class VRButton : MonoBehaviour {
    public GameObject windowToOpen;
    public GameObject windowToClose;
    public bool useFunction;
    public Fuctions doFuction;

    // het kijkt of alles goed staat om het te laten werken
    public void Start() {
        if (gameObject.GetComponent<Collider>() == null) {
            Debug.LogWarning("Bij " + this.name + " is geen Collider (3d) toegevoegd || VRButton.cs");
        }
    }

    // dit gebruikt de varriabllen in dit script om het op actief of op niet actief te zetten   (kan worden aangeroepen van buiten af)
    public void launchScreen() {
        print("launchScreen");
        // standaard zou een knop iets moeten openen, er wordt dus een waarschuming gegeven als hij dat niet doet
        if (windowToOpen == null) {
            Debug.LogWarning("Bij " + this.name + " is windowToOpen niet gezet in de inspector || VRButton.cs");
        }
        else {
            windowToOpen.SetActive(true);
        }
        if (windowToClose != null) {
            windowToClose.SetActive(false);
        }


        if (useFunction) {
            print("launchScreen--->");
            switch (doFuction) {
                case Fuctions.None:
                    print("None");
                    break;

                case Fuctions.LoadMultiplayer:
                    Application.LoadLevel("multiplayer");
                    print("multiplayer");
                    break;

                case Fuctions.LoadMultiplayerMenu:
                    Application.LoadLevel("multiplayer-menu");
                    print("LoadMultiplayerMenu");
                    break;

                case Fuctions.LoadLevel1:
                    print("LoadLevel1");
                    break;
            }
        }
    }
}
