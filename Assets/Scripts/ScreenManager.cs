using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public TextMesh screenText;

    public void changeText(string inputItem1, string inputItem2)
    {
        screenText.text = inputItem1 + "\n" + "Nr. " + inputItem2;
    }

    public void customText(string inputItem)
    {
        screenText.text = inputItem;
    }
}
