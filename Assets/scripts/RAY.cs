using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAY : MonoBehaviour {
	public float freq = 20.0f;
	public float magnitude = 0.5f;
    Vector3 s;

    EdgeCollider2D myEdge;
    Vector2[] myPoints = new Vector2[2];

	// Use this for initialization
	void Start () {
		 s = GetComponent<LineRenderer>().GetPosition(0);

        myEdge = GetComponent<EdgeCollider2D>();

    }
	
	// Update is called once per frame
	void Update () {
		
        
		GetComponent<LineRenderer>().SetPosition (0, new Vector3 (s.x, s.y + Mathf.Sin (Time.time * freq) * magnitude, s.z));

        myPoints[0] = new Vector2(GetComponent<LineRenderer>().GetPosition(0).x, GetComponent<LineRenderer>().GetPosition(0).y);
        myPoints[1] = new Vector2 (GetComponent<LineRenderer>().GetPosition(1).x, GetComponent<LineRenderer>().GetPosition(1).y);

        myEdge.points = myPoints;


    }
}
