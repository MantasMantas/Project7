using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    
    public bool buttonPress = false;
    public bool questionYes = false;
    public bool questionNo = false;
    
    public void buttonPressed()
    {
        buttonPress = true;
    }

    public void answerYes()
    {
        questionYes = true;
    }

    public void answerNo()
    {
        questionNo = true;
    }

}
