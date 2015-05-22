/// <summary>
/// Player system.
/// Timo Strating
/// 8 4 2015
/// </summary>

using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
    public int curHealth, maxHealth = 100;

    // Use this for initialization
    void Start() {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(curHealth);
    }

    void OnCollisionEnter(Collision collision) {
        AddjustCurrentHealth(-10);
    }


    public void AddjustCurrentHealth(int adj) {
        curHealth += adj;

        if (curHealth <= 0) {
            curHealth = 0;
            Debug.Log("je moeder is dood");
        }
		
        if(curHealth > maxHealth)
            curHealth = maxHealth;
		
        if(maxHealth < 1)
            maxHealth = 1;
    }
    
}
