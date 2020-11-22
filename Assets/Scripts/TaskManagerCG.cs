using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManagerCG : MonoBehaviour
{
    public GameObject monitor;
    ScreenManager screen;
    Events events;
    ChangeBlindness changeBlindness;

    Vector3 physicalButtonPos;
    Vector3 physicalButtonPos1;
    Vector3 physicalButtonPos2;
    Vector3 physicalButtonPos3;
    Vector3 physicalButtonPos4;


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



    List<GameObject> buttons = new List<GameObject>();
    List<int> randNum = new List<int>();

    int listSize;
    int taskIndex;
    string buttonName;

    // Start is called before the first frame update
    void Start()
    {
        screen = monitor.GetComponent<ScreenManager>();
        events = GetComponent<Events>();
        changeBlindness = GetComponent<ChangeBlindness>();

        physicalButtonPos1 = section1.transform.position;
        physicalButtonPos2 = section2.transform.position;
        physicalButtonPos3 = section3.transform.position;
        physicalButtonPos4 = section4.transform.position;

        buttons.Add(section1); buttons.Add(section12); buttons.Add(section13); buttons.Add(section14); buttons.Add(section15); buttons.Add(section16);
        buttons.Add(section2); buttons.Add(section22); buttons.Add(section23); buttons.Add(section24); buttons.Add(section25); buttons.Add(section26);
        buttons.Add(section3); buttons.Add(section32); buttons.Add(section33); buttons.Add(section34); buttons.Add(section35); buttons.Add(section36);
        buttons.Add(section4); buttons.Add(section42); buttons.Add(section43); buttons.Add(section44); buttons.Add(section45); buttons.Add(section46);

        listSize = buttons.Count;
        taskIndex = 0;


        Randomizer.Shuffle(randNum);

    
        for (int i=0; i < listSize; i++)
        {
            randNum.Add(i);
            buttons[i].GetComponent<Collider>().enabled = false;
        }

        Randomizer.Shuffle(randNum);
        screen.changeText(buttons[randNum[taskIndex]].name);
    }

    // Update is called once per frame
    void Update()
    {
         if(taskIndex >= listSize)
        {
            screen.customText("Good Job");
            return;
        }
        if (!buttons[randNum[taskIndex]].GetComponent<Collider>().enabled && changeBlindness.applyManipulation)
        {
            if (randNum[taskIndex] >= 0 && randNum[taskIndex] <= 5)
            {
                physicalButtonPos = physicalButtonPos1;
                
            }
            if (randNum[taskIndex] >= 6 && randNum[taskIndex] <= 11)
            {
                physicalButtonPos = physicalButtonPos2;
                
            }
            if (randNum[taskIndex] >= 12 && randNum[taskIndex] <= 17)
            {
                physicalButtonPos = physicalButtonPos3;
                
            }
            if (randNum[taskIndex] >= 18 && randNum[taskIndex] <= 23)
            {
                physicalButtonPos = physicalButtonPos4;
                
            }

            changeBlindness.applyM(physicalButtonPos - buttons[randNum[taskIndex]].transform.position, panel);
            buttons[randNum[taskIndex]].GetComponent<Collider>().enabled = true;
            screen.changeText(buttons[randNum[taskIndex]].name);
        }

        if(events.buttonPress)
        {   
            if(!buttons[randNum[taskIndex]].GetComponent<CustomButton>().touched)
            {   
                buttons[randNum[taskIndex]].GetComponent<Collider>().enabled = false;
                events.buttonPress = false;
                taskIndex++;
            }
        }


        
    }

}
