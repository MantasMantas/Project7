using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestionButton : MonoBehaviour
{
    [System.Serializable]
    public class ButtonEvent : UnityEvent { }

    public ButtonEvent downEvent;

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 0)
        {
            downEvent?.Invoke();
        }
    }
}
