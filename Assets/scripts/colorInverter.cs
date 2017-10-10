using UnityEngine;
using System.Collections;
using System;

public class colorInverter : MonoBehaviour
{

    public System.Collections.Generic.List<GameObject> whole;
    public System.Collections.Generic.List<Color> regularColor;

    // Use this for initialization
    void Start()
    {
        whole = new System.Collections.Generic.List<GameObject>();
        regularColor = new System.Collections.Generic.List<Color>();

        whole.AddRange(UnityEngine.Object.FindObjectsOfType<GameObject>());

        for(int i=0; i<whole.Capacity; ++i)
        {
            try
            {
                    regularColor.Add(whole[i].GetComponent<SpriteRenderer>().color);
            }
            catch
            {
                regularColor.Add(new Color());
            }
        }
    }

    // Update is called once per frame
    public void inversion()
    {
        foreach (GameObject a in whole)
        {
            if (a.activeInHierarchy) {

                try
                {
                    a.GetComponent<SpriteRenderer>().color = a.GetComponent<shadowColour>().shadowMode;
                }
                catch (NullReferenceException)
                {
                    try
                    {
                        Color local = a.GetComponent<SpriteRenderer>().color;
                        float localGrey = 0.21f * local.r + 0.72f * local.g + 0.07f * local.b;
                        a.GetComponent<SpriteRenderer>().color = new Color(localGrey, localGrey, localGrey);
                    }
                    catch
                    { }
                }
                catch { }
            }
        }
    }

    public void revert()
    {
        for(int i=0; i<regularColor.Capacity; ++i)
        {
            try
            {
                whole[i].GetComponent<SpriteRenderer>().color = regularColor[i];
            }
            catch {}
        }
    }
}
