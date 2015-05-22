/// <summary>
/// Enemy AI.
/// Timo Strating
/// 10 6 13  RE USE  31 3 15
/// </summary>

using UnityEngine;
using System.Collections;

public class EnemyAIv1 : MonoBehaviour {
    public Transform target;
    public int moveSpeed = 1;
    public int rotationSpeed = 1;
    public bool nois = true;

    private Transform myTransform;
    private float randomNummer = 1;
    private Quaternion testels;

    void Awake() {
        myTransform = transform;
    }

    // Use this for initialization
    void Start() {
        if (target == null) {
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            target = go.transform;
            Debug.LogWarning(this + " heeft geen target toe gekend gekregen in de inspector || EnemyAIv1.cs");
        }
        if (nois)
            randomNummer = Random.Range(0.95f, 1.05f);
        Debug.Log( this + " = not random = " + randomNummer + " || EnemyAIv1.cs");
    }

    // Update is called once per frame
    void Update() {
        Debug.DrawLine(target.position, myTransform.position, Color.yellow);
        Debug.DrawLine(myTransform.position, myTransform.position + (myTransform.forward * 5), Color.yellow);

        Quaternion qua = Quaternion.Slerp(      myTransform.rotation,
                                                Quaternion.LookRotation(target.position - myTransform.position),
                                                rotationSpeed * Time.deltaTime);
        myTransform.rotation = new Quaternion ( qua.x, qua.y, qua.z, qua.w * randomNummer);
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
    }
}
