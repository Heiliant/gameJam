using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pjMovement : MonoBehaviour {
    private float rad = 0.64f;
    private Vector3 me;

    public float bigRad; //rad of the detection once the player is moving, so of it moves kinda fast, the object doesnt lose track of the finger
    public float littleRad;//the rad of the actual circle

    public float camSpeedReleased;
    public float camSpeedPressed;

    TargetJoint2D myJoint;

    camBehaviour myCamera;
    timerBehaviour myTimer;

    // Use this for initialization
    void Start () {
        myJoint = GetComponent<TargetJoint2D>();
        myJoint.autoConfigureTarget = false;

        myCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camBehaviour>();
        myTimer = GameObject.Find("timer").GetComponent<timerBehaviour>();

        myCamera.Speed = camSpeedReleased;
    }
	
	// Update is called once per frame
	void Update () {

        Vector2 myMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        me = GetComponent<Transform>().position;
        
        if (Input.GetMouseButton(0) && Vector2.Distance(me, myMouse) < rad)
        {
            //the camera moves
            rad = bigRad;
            myJoint.target = myMouse;
            myCamera.Speed = camSpeedPressed;

            myTimer.toCountdown = false;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            //the camera stops moving
            rad = littleRad;
            myCamera.Speed = camSpeedReleased;

            myTimer.toCountdown = true;
        }
    }
}
