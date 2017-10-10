using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camBehaviour : MonoBehaviour {

    private Transform me;
    public float Speed
    {
        get;
        set;
    }
    public float deltaDistance;

    public float getDeltaDistance() { return deltaDistance; } //return the distance that the camera has travelled

	// Use this for initialization
	void Start () {
        me = GetComponent<Transform>();
            
        deltaDistance = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        me.Translate(new Vector2(0.0f, Speed * Time.deltaTime));
        deltaDistance += Speed * Time.deltaTime;

    }
}
