using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextsToDisplay : MonoBehaviour {

    public Text displayText;
    List<string> texts = new List<string>();
    int countColl;

    private void Start()
    {
        countColl = 0;

        texts.Add("This is a test text to display when the collectible is touched");
        texts.Add("Another text was added to prove this system works");
        texts.Add("This third text is simply here because 3 is a nice number");
    }

    public void DisplayText ()
    {
        displayText.text = texts[countColl];
        //AddCode to print text here
        countColl = countColl + 1;
    }

}
