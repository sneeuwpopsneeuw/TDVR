using UnityEngine;
using System.Collections;

public class gunTest : MonoBehaviour {
    public Transform spwanpoint;
    public GameObject projectile;
    public float speed = 20;

    void Start() {
        //if (spwanpoint == null) {
        //    spwanpoint = new Vector3(transform.position.x + 5, transform.position.y + 5, transform.position.z + 5);
        //}
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            Instantiate(projectile, spwanpoint.position, transform.rotation);
            //instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
    }
}
