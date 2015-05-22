/// <summary>
/// Timo Strating
/// 28 2 2015
/// VRemulator.cs
///     Dit script zorgt er voor dat je de VR camera kan bewegen in de game (cheat)
/// </summary>

using UnityEngine;
using System.Collections;

public class VRemulator : MonoBehaviour {
    // private Camera camera;

	// Use this for initialization
	void Start () {
        // camera = Camera.current;
	} 
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.Keypad4)) {    // left
            transform.Rotate(Vector3.down * 75 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Keypad6)) {    // right
            transform.Rotate(Vector3.up * 75 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Keypad8)) {    // up
            transform.Rotate(Vector3.left * 75 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Keypad5)) {    // down
            transform.Rotate(Vector3.right * 75 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Keypad7)) {    // linksom draaien
            transform.Rotate(Vector3.back * 75 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Keypad9)) {    // rechtsom draaien
            transform.Rotate(Vector3.forward * 75 * Time.deltaTime);
        }
	}
}
