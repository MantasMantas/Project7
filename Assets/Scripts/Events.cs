using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    
    public bool red = false;
    public bool blue = false;
    public bool green = false;
    
    public void RedButtonPress()
    {
        red = true;
        Debug.Log("Red Button is pressed");
    }

    public void BlueButtonPress()
    {
        blue = true;
        Debug.Log("Blue Button is pressed");
    }

    public void GreenButtonPress()
    {
        green = true;
        Debug.Log("Green Button is pressed");
    }

}
