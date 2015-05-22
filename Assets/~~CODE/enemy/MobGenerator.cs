/// <summary>
/// MobGenerator.cs
/// Timo Strating
/// 1 6 13    RE-Use    25 3 15
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic; 									// dit maakt het mogelijk om een list te maken

public class MobGenerator : MonoBehaviour {
    public enum State {
        Idle,
        Initialize,
        Setup,
        SpawnMob
    }

    public GameObject[] mobPrefabs;									// hier kunnen alle mobs geselekteerd worden die er worden gecreerd
    public GameObject[] spawnPoints;								// hier worden alle spawnpoints aan vast gemaakt 

    public State state;												//dit is de lokale variabele dat holds our current State


    void Awake() {
        state = MobGenerator.State.Initialize;
    }

    // Use this for initialization
    IEnumerator Start() {
        while (true) {
            switch (state) {
                case State.Initialize:
                    Initialize();
                    break;
                case State.Setup:
                    Setup();
                    break;
                case State.SpawnMob:
                    SpawnMob();
                    break;
            }

            yield return 0;
        }
    }

    // zorg er voor da alles opgezet is voordat we doorgaan
    private void Initialize() {
                Debug.Log("De Initialize functie wordt aangeroeppen");
        if (!CheckForMobPrefabs())									// dit betenkent als CheckForMobPrefabs niet true returns dan doet het						
            return;

        if (!CheckForSpawnPoints())									// dit betenkent als CheckForSpawnPoints niet true returns dan doet het						
            return;

        state = MobGenerator.State.Setup;
    }

    // zorg er voor dat alles opgzet is voor dat we doorgaan
    private void Setup() {
        		Debug.Log("De Setup functie wordt aangeroeppen");
        state = MobGenerator.State.SpawnMob;
    }

    // spawn een Mob als we een spawn point hebben zonder mob
    private void SpawnMob() {
        		Debug.Log("De SpawnMob functie wordt aangeroeppen");
        GameObject[] gos = AvailableSpawnPoints();

        for (int cnt = 0; cnt < gos.Length; cnt++) {
            GameObject go = Instantiate(mobPrefabs[Random.Range(0, mobPrefabs.Length)],
                                        gos[cnt].transform.position,
                                        Quaternion.identity
                                        ) as GameObject;
            go.transform.parent = gos[cnt].transform;
        }

        state = MobGenerator.State.Idle;
    }






    #region dit zijn extra functies die aangeroepen worden door andere functies
    // check om te kijken of me minstens een mob prefab hebben.
    private bool CheckForMobPrefabs() {
        if (mobPrefabs.Length > 0)
            return true;
        else
            return false;
    }

    //check om te kijken of me minstens een spawn point hebben
    private bool CheckForSpawnPoints() {
        if (spawnPoints.Length > 0)
            return true;
        else
            return false;
    }

    // dit is een lijst met Spawnpoints die geen Mobs als child hebben
    private GameObject[] AvailableSpawnPoints() {
        List<GameObject> gos = new List<GameObject>();


        for (int cnt = 0; cnt < spawnPoints.Length; cnt++) {
            if (spawnPoints[cnt].transform.childCount == 0) {
                        Debug.Log("*** Spawn Point Available ***");
                gos.Add(spawnPoints[cnt]);
            }
        }

        // returns de list van array(s)
        return gos.ToArray();
    }

    #endregion
}

