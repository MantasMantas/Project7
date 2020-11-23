using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public TextMesh screenText;

    public void changeText(string inputItem)
    {
        screenText.text = "Section" + "\n" + inputItem;
    }

    public void customText(string inputItem)
    {
        screenText.text = inputItem;
    }
}
