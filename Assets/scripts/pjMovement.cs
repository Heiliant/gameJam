using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pjMovement : MonoBehaviour {
    public float rad = 0.64f;
    private Vector3 me;

    public float bigRad; //rad of the detection once the player is moving, so of it moves kinda fast, the object doesnt lose track of the finger
    public float littleRad;//the rad of the actual circle

    public float camSpeedReleased;
    public float camSpeedPressed;

    SpringJoint2D myJoint;

    camBehaviour myCamera;
    timerBehaviour myTimer;
    colorInverter myInverter;

    private Vector3 camSpawnPoint;
    private Vector3 mySpawnPoint;
    public float deathTime=3.0f;
    private float actualDeathTime;
    public bool memuero;

    public string regularTag;
    public string shadowTag;
    public void kill()
    {
        myCamera.Speed = camSpeedReleased;
        memuero = true;
    }

    // Use this for initialization
    void Start () {
        myJoint = GetComponent<SpringJoint2D>();
        myJoint.autoConfigureConnectedAnchor = false;

        camSpawnPoint = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position;
        mySpawnPoint = GetComponent<Transform>().position;
        myCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camBehaviour>();
        myTimer = GameObject.Find("timer").GetComponent<timerBehaviour>();
        myInverter = GameObject.FindObjectOfType<colorInverter>();

        myCamera.Speed = camSpeedReleased;

        memuero = false;
        actualDeathTime = deathTime;
    }
	
	// Update is called once per frame
	void Update () {

        Vector2 myMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        me = GetComponent<Transform>().position;

        if (!memuero)
        {
            if (Input.GetMouseButton(0) && Vector2.Distance(me, myMouse) < rad)
            {
                //the camera moves
                rad = bigRad;
                myJoint.connectedAnchor = myMouse;
                myCamera.Speed = camSpeedPressed;

                myTimer.toCountdown = false;

                gameObject.tag = regularTag;

                myInverter.revert();
            }
            else if (Input.GetMouseButtonUp(0) || Vector2.Distance(me, myMouse) > rad)
            {
                //the camera stops moving
                rad = littleRad;
                myCamera.Speed = camSpeedReleased;

                myTimer.toCountdown = true;

                gameObject.tag = shadowTag;

                myInverter.inversion();
            }
        }
        else
        {
            if(actualDeathTime>0.0f)
                actualDeathTime -= Time.deltaTime;
            else
            {
                actualDeathTime = deathTime;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position = camSpawnPoint;
                GetComponent<Transform>().position = mySpawnPoint;
                myJoint.connectedAnchor = mySpawnPoint;
                myTimer.resetTime();
                memuero = false;
            }
            Color mycolor = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(mycolor.r, mycolor.g, mycolor.b, actualDeathTime / deathTime);

        }
    }
}
