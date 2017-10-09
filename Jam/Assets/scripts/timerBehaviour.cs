using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerBehaviour : MonoBehaviour {

    Text timer;
    public float maxTime=5.0f;
    private float actualTime;

    public bool toCountdown
    {
        get;
        set;
    }

    circularProgressbar progressbar;
	// Use this for initialization
	void Start () {
        timer=GetComponent<Text>();
        toCountdown = false;

        actualTime = maxTime;

        progressbar = GameObject.Find("progressbar").GetComponent<circularProgressbar>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        actualTime+= toCountdown ? (actualTime>0.0f ? -Time.deltaTime : 0.0f) : (actualTime<maxTime ? Time.deltaTime : 0.0f);

        progressbar.setProgression(actualTime);
        timer.text = ((int)actualTime).ToString();
	}
}
