/// <summary>
/// Player system.
/// Timo Strating
/// 27 3 2015
/// </summary>

using UnityEngine;
using System.Collections;

public class PlayerSystem : MonoBehaviour {
    public int curHealth, maxHealth = 100;

    // Use this for initialization
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	public void AddjustCurrentHealth(int adj) {
		curHealth += adj;
		
		if(curHealth <= 0)
			curHealth = 0;
		
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;
	}
}
