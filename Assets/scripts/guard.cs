using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guard : MonoBehaviour
{

    int i;
    bool direction;
    public float speed;
    public float rotationspeed;
    public System.Collections.Generic.List<Transform> points = new System.Collections.Generic.List<Transform>();
    // Use this for initialization
    void Start()
    {
        direction = true;
        i = 0;
        transform.position = points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        if (direction)
        {
            Vector3 vectorToTarget = points[i + 1].position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationspeed);

            if (transform.position == points[i].position || transform.position != points[i + 1].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, points[i + 1].position, speed * Time.deltaTime);
            }
            else if (transform.position == points[i + 1].position)
            {
                i++;
            }
            if (i == points.Capacity - 1)
            {
                direction = false;
            }
        }
        else
        {
            Vector3 vectorToTarget = points[i - 1].position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationspeed);

            if (transform.position == points[i].position || transform.position != points[i - 1].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, points[i - 1].position, speed * Time.deltaTime);
            }
            else if (transform.position == points[i - 1].position)
            {
                i--;
            }
            if (i == 0)
            {
                direction = true;
            }
        }
    }
}