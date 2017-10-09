using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class circularProgressbar : MonoBehaviour
{
    private Image myImage;

    private float progression;

    public void setProgression(float num) {
        while (num > 1.0f)
            num--;
        progression = num;
    }

    // Use this for initialization
    void Start()
    {
        myImage = GetComponent<Image>();
        myImage.type = UnityEngine.UI.Image.Type.Filled;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myImage.fillAmount = progression;
    }
}
