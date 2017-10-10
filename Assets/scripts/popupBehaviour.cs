using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupBehaviour : MonoBehaviour {
    public string message;
    public float timeToRender;
    private float actualTime;

	// Use this for initialization
	void Start () {
        actualTime = timeToRender;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<TextMesh>().text = message;

    }

	
	// Update is called once per frame
	void Update () {
        actualTime -= Time.deltaTime;

        if (actualTime < 0.0f)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<TextMesh>().text = "";
            Destroy(gameObject);
        }
	}
}
