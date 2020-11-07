using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManagerW : MonoBehaviour
{
    public GameObject monitor;
    ScreenManager screen;
    Events events;
    HandOffset bodyWarping;

    Vector3 physicalButtonPos;

    public GameObject redRound;
    public GameObject blueRound;
    public GameObject greenRound;
    public GameObject yellowRound;
    public GameObject purpleRound;
    public GameObject orangeRound;
    public GameObject redSquare;
    public GameObject blueSquare;
    public GameObject greenSquare;
    public GameObject yellowSquare;
    public GameObject purpleSquare;
    public GameObject orangeSquare;

    List<GameObject> buttons = new List<GameObject>();

    int listSize;
    int taskIndex;
    string buttonName;

    // Start is called before the first frame update
    void Start()
    {
        screen = monitor.GetComponent<ScreenManager>();
        events = GetComponent<Events>();
        bodyWarping = GetComponent<HandOffset>();

        physicalButtonPos = redRound.transform.position;

        buttons.Add(redRound);buttons.Add(blueRound);buttons.Add(greenRound);buttons.Add(yellowRound);buttons.Add(purpleRound);buttons.Add(orangeRound);
        buttons.Add(redSquare);buttons.Add(blueSquare);buttons.Add(greenSquare);buttons.Add(yellowSquare);buttons.Add(purpleSquare);buttons.Add(orangeSquare);

        listSize = buttons.Count;
        taskIndex = 0;

        for(int i=0; i < listSize; i++)
        {
            buttons[i].GetComponent<Collider>().enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(taskIndex >= listSize)
        {
            screen.customText("Good Job");
            return;
        }
        if(!buttons[taskIndex].GetComponent<Collider>().enabled && !bodyWarping.croosed)
        {
            bodyWarping.setT((buttons[taskIndex].transform.position - physicalButtonPos) * 2f);
            buttons[taskIndex].GetComponent<Collider>().enabled = true;
            screen.changeText(buttons[taskIndex].name);
        }

        if(events.buttonPress)
        {   
            if(!buttons[taskIndex].GetComponent<CustomButton>().touched)
            {   
                buttons[taskIndex].GetComponent<Collider>().enabled = false;
                events.buttonPress = false;
                taskIndex++;
            }
        }


        
    }

}
