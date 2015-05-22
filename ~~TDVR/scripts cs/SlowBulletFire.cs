using UnityEngine;
using System.Collections;

public class SlowBulletFire : MonoBehaviour {


GameObject bulletPrefab;
float frequency = 2;
float coneAngle = 1.5f;
AudioClip fireSound;
bool  firing = false;

private float lastFireTime = -1;

void Update (){
	if (firing) {
		if (Time.time > lastFireTime + 1 / frequency) {
			Fire ();
		}
	}
}

void Fire (){
	// Spawn bullet
	FIXME_VAR_TYPE coneRandomRotation= Quaternion.Euler (Random.Range (-coneAngle, coneAngle), Random.Range (-coneAngle, coneAngle), 0);
	Spawner.Spawn (bulletPrefab, transform.position, transform.rotation * coneRandomRotation);
	
	if (GetComponent<AudioSource>() && fireSound) {
		GetComponent<AudioSource>().clip = fireSound;
		GetComponent<AudioSource>().Play ();
	}
	
	lastFireTime = Time.time;
}

void OnStartFire (){
	firing = true;
}

void OnStopFire (){
	firing = false;
}
}