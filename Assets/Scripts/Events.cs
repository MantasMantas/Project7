using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    
    public bool buttonPress = false;
    
    public void buttonPressed()
    {
        buttonPress = true;
    }

}
