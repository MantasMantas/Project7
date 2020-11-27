using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManagerCG : MonoBehaviour
{
    public GameObject monitor;
    ScreenManager screen;
    Events events;
    CheckGaze checkGaze;

    Vector3 physicalButtonPos;
    Vector3 physicalButtonPos1;
    Vector3 physicalButtonPos2;
    Vector3 physicalButtonPos3;
    Vector3 physicalButtonPos4;
    Vector3 panelOriginalPos;


    public GameObject section1;
    public GameObject section12;
    public GameObject section13;
    public GameObject section14;
    public GameObject section15;
    public GameObject section16;
    public GameObject section2;
    public GameObject section22;
    public GameObject section23;
    public GameObject section24;
    public GameObject section25;
    public GameObject section26;
    public GameObject section3;
    public GameObject section32;
    public GameObject section33;
    public GameObject section34;
    public GameObject section35;
    public GameObject section36;
    public GameObject section4;
    public GameObject section42;
    public GameObject section43;
    public GameObject section44;
    public GameObject section45;
    public GameObject section46;

    public Transform panel;
    public Transform hand;
    public Transform boundarry;
    public GameObject text1;
    public GameObject text2;

    //Generating a new name for the report file
    public static int increment = 1;

    List<GameObject> buttons = new List<GameObject>();
    List<int> randNum = new List<int>();

    int listSize;
    int taskIndex;
    string sectionName;
    bool handTracking;
    float distance;
    float multi;
    bool track;


    // Start is called before the first frame update
    void Start()
    {
        screen = monitor.GetComponent<ScreenManager>();
        events = GetComponent<Events>();
        checkGaze = GetComponent<CheckGaze>();

        physicalButtonPos1 = section1.transform.position;
        physicalButtonPos2 = section2.transform.position;
        physicalButtonPos3 = section3.transform.position;
        physicalButtonPos4 = section4.transform.position;
        panelOriginalPos = panel.position;

        buttons.Add(section1); buttons.Add(section12); buttons.Add(section13); buttons.Add(section14); buttons.Add(section15); buttons.Add(section16);
        buttons.Add(section2); buttons.Add(section22); buttons.Add(section23); buttons.Add(section24); buttons.Add(section25); buttons.Add(section26);
        buttons.Add(section3); buttons.Add(section32); buttons.Add(section33); buttons.Add(section34); buttons.Add(section35); buttons.Add(section36);
        buttons.Add(section4); buttons.Add(section42); buttons.Add(section43); buttons.Add(section44); buttons.Add(section45); buttons.Add(section46);

        listSize = buttons.Count;
        taskIndex = 0;

    
        for (int i=0; i < listSize; i++)
        {
            randNum.Add(i);
            buttons[i].GetComponent<Collider>().enabled = false;
        }

        Randomizer.Shuffle(randNum);
        screen.customText("Look for next task");

         //Incrementing the report number
        for (int i = 0; i <= 500; i++)
        {
            if (System.IO.File.Exists("Assets/Reports/ReportCG" + increment + ".csv"))
            {
                increment++;
            }
        }

        CSVManagerCG.CreateReport();
        pathTrackingManagerCG.CreateReport();

    }

    // Update is called once per frame
    void Update()
    {
        
         if(taskIndex >= listSize)
        {
            screen.customText("Good Job");
            return;
        }
        if (!buttons[randNum[taskIndex]].GetComponent<Collider>().enabled && checkGaze.applyManipulation)
        {
            if (randNum[taskIndex] >= 0 && randNum[taskIndex] <= 5)
            {
                physicalButtonPos = section1.transform.position;
                sectionName = "Zarya";
                multi = -1;

            }
            if (randNum[taskIndex] >= 6 && randNum[taskIndex] <= 11)
            {
                physicalButtonPos = section2.transform.position;
                sectionName = "Unity";
                multi = 1;

            }
            if (randNum[taskIndex] >= 12 && randNum[taskIndex] <= 17)
            {
                physicalButtonPos = section3.transform.position;
                sectionName = "Quest";
                multi = -1;

            }
            if (randNum[taskIndex] >= 18 && randNum[taskIndex] <= 23)
            {
                physicalButtonPos = section4.transform.position;
                sectionName = "Dextre";
                multi = 1;

            }

            distance = Mathf.Abs(physicalButtonPos.x - buttons[randNum[taskIndex]].transform.position.x);
            panel.position = new Vector3(panelOriginalPos.x + (multi*distance), panelOriginalPos.y, panelOriginalPos.z);
            buttons[randNum[taskIndex]].GetComponent<Collider>().enabled = true;
            screen.changeText(sectionName, buttons[randNum[taskIndex]].name);

            if(taskIndex<= 0) { track = true; }
        }

        if(events.buttonPress)
        {
            track = false;
            if(!buttons[randNum[taskIndex]].GetComponent<CustomButton>().touched)
            {   
                text1.SetActive(true);
                text2.SetActive(true);
                screen.customText("Was the environment" + "\n" + "manipulated?");

                if (events.questionYes || events.questionNo)
                {
                    if(events.questionYes)
                    {
                        events.questionYes = false;
                        append(distance.ToString(), "Yes");
                    }
                    else
                    {
                        events.questionNo = false;
                        append(distance.ToString(), "No");
                    }

                    text1.SetActive(false);
                    text2.SetActive(false);

                    buttons[randNum[taskIndex]].GetComponent<Collider>().enabled = false;
                    events.buttonPress = false;
                    track = true;
                    taskIndex++;
                }

            }
        }
        if(hand.position.z > boundarry.position.z)
        {
            handTracking = true;
        }
        else
        {
            handTracking = false;
        }


        
    }

    void FixedUpdate()
    {
        if(handTracking && track)
        {
            pathTrackingManagerCG.AppendToReport(new string[5]
        {
            "Change Blindness",
            hand.position.x.ToString(),
            hand.position.y.ToString(),
            hand.position.z.ToString(),
            Vector3.Distance(physicalButtonPos, buttons[randNum[taskIndex]].transform.position).ToString(),
        });
        }
    }

    void append(string condition, string question)
    {
        CSVManagerCG.AppendToReport(
            new string[3]
            {
                "Change Blindness",
                condition,
                question,
            }
        );
    }
    

}
