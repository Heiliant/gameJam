using UnityEngine;
using System.Collections;

public class colorInverter : MonoBehaviour
{

    private GameObject[] whole;
    private Color[] regularColor;
    public bool go;

    // Use this for initialization
    void Start()
    {
        whole = UnityEngine.Object.FindObjectsOfType<GameObject>();
        go=false;
    }

    // Update is called once per frame
    void inversion()
    {
        foreach (GameObject a in whole)
        {
            if (a.activeInHierarchy) {
                try
                {
                    float myGrey = a.GetComponent<SpriteRenderer>().color.r + a.GetComponent<SpriteRenderer>().color.g + a.GetComponent<SpriteRenderer>().color.g;
                    myGrey /= 3;
                    a.GetComponent<SpriteRenderer>().color = 
                    new Color(myGrey, myGrey, myGrey);
                }
                catch
                {
                    Debug.Log(a.name + " has no sprite renderer");
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (go)
        {
            inversion();
            go = false;
        }  
    }
}
