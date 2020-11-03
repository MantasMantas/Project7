using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public GameObject monitor;
    public GameObject hand;
    ScreenManager screen;
    Events events;
    HandOffset bodyWarping;

    public Transform buttonRed;
    public Transform buttonBlue;
    public Transform buttonGreen;

    int taskIndex;

    // Start is called before the first frame update
    void Start()
    {
        screen = monitor.GetComponent<ScreenManager>();
        events = GetComponent<Events>();
        bodyWarping = hand.GetComponent<HandOffset>();

        screen.changeText("Red round");
        taskIndex = 0;
        bodyWarping.switchTarget(buttonRed);
        
    }

    // Update is called once per frame
    void Update()
    {
       if(taskIndex == 0)
       {
           if(events.red)
           {
               screen.changeText("Blue round");
               taskIndex++;
               bodyWarping.switchTarget(buttonBlue);
           }
       }
       if(taskIndex == 1)
       {
           if(events.blue)
           {
               screen.changeText("Green round");
               taskIndex++;
               bodyWarping.switchTarget(buttonGreen);
           }
       }
       if(taskIndex == 2)
       {
           if(events.green)
           {
               screen.customText("Gud jub");
               
           }
       }
        
    }
}
