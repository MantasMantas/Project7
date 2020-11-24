﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManagerW : MonoBehaviour
{
    public GameObject monitor;
    ScreenManager screen;
    Events events;
    HandOffset bodyWarping;
    //Generating a new name for the report file
    public static int increment = 1;

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
    public Transform leftHand;

    List<GameObject> buttons = new List<GameObject>();

    int listSize;
    int taskIndex;
    string buttonName;

    // Start is called before the first frame update
    void Start()
    {
        leftHand = GameObject.Find("LeftHandAnchor").transform;
        //Incrementing the report number
        for (int i = 0; i <= 500; i++)
        {
            if (System.IO.File.Exists("Assets/Reports/Report" + increment + ".csv"))
            {
                increment++;
            }
        }
        CSVManager.CreateReport();
        pathTrackingManager.CreateReport();
        //Submit a new line

        CSVManager.AppendToReport(
            new string[3]
            {
                "Change Blindness Haptic Remapping",
                "5 cm",
                "Yes",
            }
        );
        screen = monitor.GetComponent<ScreenManager>();
        events = GetComponent<Events>();
        bodyWarping = GetComponent<HandOffset>();

        physicalButtonPos = redRound.transform.position;

        buttons.Add(redRound); buttons.Add(blueRound); buttons.Add(greenRound); buttons.Add(yellowRound); buttons.Add(purpleRound); buttons.Add(orangeRound);
        buttons.Add(redSquare); buttons.Add(blueSquare); buttons.Add(greenSquare); buttons.Add(yellowSquare); buttons.Add(purpleSquare); buttons.Add(orangeSquare);

        listSize = buttons.Count;
        taskIndex = 0;

        for (int i = 0; i < listSize; i++)
        {
            buttons[i].GetComponent<Collider>().enabled = false;
        }

    }

    void FixedUpdate()
    {
        pathTrackingManager.AppendToReport(new string[4]
        {
            "Warping",
            leftHand.position.x.ToString(),
            leftHand.position.y.ToString(),
            leftHand.position.z.ToString(),
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (taskIndex >= listSize)
        {
            screen.customText("Good Job");
            return;
        }
        if (!buttons[taskIndex].GetComponent<Collider>().enabled && !bodyWarping.croosed)
        {
            bodyWarping.setT((buttons[taskIndex].transform.position - physicalButtonPos) * 2f);
            buttons[taskIndex].GetComponent<Collider>().enabled = true;
            //screen.changeText(buttons[taskIndex].name);
        }

        if (events.buttonPress)
        {
            if (!buttons[taskIndex].GetComponent<CustomButton>().touched)
            {
                buttons[taskIndex].GetComponent<Collider>().enabled = false;
                events.buttonPress = false;
                taskIndex++;
            }
        }



    }

}
