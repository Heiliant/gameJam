using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public float speed=1.0f;
    private Transform me;
    

	// Use this for initialization
	void Start () {
        me = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        me.Translate(new Vector2(0.0f, Time.deltaTime * speed * 100.0f));
	}
}
