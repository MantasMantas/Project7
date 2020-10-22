using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public GameObject monitor;
    ScreenManager screen;
    Events events;
    int taskIndex;

    // Start is called before the first frame update
    void Start()
    {
        screen = monitor.GetComponent<ScreenManager>();
        events = GetComponent<Events>();
        screen.changeText("Red round");
        taskIndex = 0;
        
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
           }
       }
       if(taskIndex == 1)
       {
           if(events.blue)
           {
               screen.changeText("Green round");
               taskIndex++;
           }
       }
       if(taskIndex == 2)
       {
           if(events.green)
           {
               screen.changeText("Gud jub");
               
           }
       }
        
    }
}
