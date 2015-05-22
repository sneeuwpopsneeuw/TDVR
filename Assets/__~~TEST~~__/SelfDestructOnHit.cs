using UnityEngine;
using System.Collections;

public class SelfDestructOnHit : MonoBehaviour {

    private float selfDestructTime = 5.0f;

    void OnTriggerStay(Collider other) {
        selfDestructTime -= Time.deltaTime;

        PhotonView pv = GetComponent<PhotonView>();

        if (pv != null && pv.instantiationId != 0) {
            PhotonNetwork.Destroy(gameObject);
            NetworkManager nm = GameObject.FindObjectOfType<NetworkManager>();

            nm.standbyCamera.SetActive(true);
            nm.respawnTimer = 3f;
        } 
    }
}
