﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinMov : MonoBehaviour {

    public float speed=1.0f;
  
    

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0.0f, 0.0f, Time.deltaTime * speed * 100.0f));
	}
}