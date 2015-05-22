using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float hitPoints = 100f;
	private float currentHitPoints;

	// Use this for initialization
	void Start () {
		currentHitPoints = hitPoints;
	}

	[RPC]
	public void TakeDamage(float amt) {
		currentHitPoints -= amt;

		if(currentHitPoints <= 0) {
			Die();
		}
	}

	void Die() {
		if( GetComponent<PhotonView>().instantiationId==0 ) {
			Destroy(gameObject);
		}
		else {
			if( GetComponent<PhotonView>().isMine ) {
				if( gameObject.tag == "Player" ) {		// This is my actual PLAYER object, then initiate the respawn process
					NetworkManager nm = GameObject.FindObjectOfType<NetworkManager>();

					nm.standbyCamera.SetActive(true);
					nm.respawnTimer = 3f;
				}
				else if( gameObject.tag == "Bot" ) {
					Debug.LogError("WARNING: No bot respawn code exists!");
				}

				PhotonNetwork.Destroy(gameObject);
			}
		}
	}
}
