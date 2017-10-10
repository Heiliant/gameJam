using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAY_360 : MonoBehaviour {
    public GameObject laser;
    public int laserAmount;
    public float length=1.0f;
    public float heigth= 1.0f;
	// Use this for initialization

	void Start () {
        float degrees = 360.0f / laserAmount;
        for (int i = 0; i < laserAmount; ++i){
            GameObject local = Instantiate(laser, transform.position, transform.rotation);
            local.transform.Translate(new Vector3(0.0f, 0.0f, 3.0f));
            local.transform.Rotate(new Vector3(0.0f, 0.0f, degrees * i));
            local.transform.localScale = new Vector3(length, heigth, local.transform.localScale.z);
            local.transform.parent = gameObject.transform;
            local.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
