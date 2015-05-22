/// <summary>
/// Timo Strating
/// 2 3 2015
/// menuMaster.cs
///     Dit is het script dat eindverantwoordelijk / beheerder van het menu is (MASTER)
/// </summary>
using UnityEngine;
using System.Collections;

// neeeee het werkt niet neee
public enum Options {
    Red,
    Blue,
    Green
}

public class menuMaster : MonoBehaviour {

    public GameObject[] setNotActive;

    
    // gebruik dit om dingen te doen voordat de scene is geladen
	void Awake () {
        foreach (GameObject item in setNotActive) {
            item.SetActive(false);
        }
	}

    // gebruik dit voor initialization
	void Start () {

	}

    // De Update wordt iedere Frame aangeroepen
    void Update() {

    }

    public void Example() {
        Options options = Options.Red;

        switch (options) {
            case Options.Red:
                print("8182381");
                break;

            case Options.Blue:
                print("001001");
                break;

            case Options.Green:
                print("3a5eq4");
                break;
        }
	}
}
