using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HowTo : MonoBehaviour {

    GameObject playT;
    Text playText;
    GameObject info;
    Text infoText;
    GameObject quit;
    Text quitT;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        playT = GameObject.FindGameObjectWithTag("PlayText");
        playText = playT.GetComponent<Text>();
        info = GameObject.FindGameObjectWithTag("Info");
        infoText = info.GetComponent<Text>();
        quit = GameObject.FindGameObjectWithTag("Quit");
        quitT = quit.GetComponent<Text>();
    }

    //when player clicks on How To Play text
    public void OnMouseDown()
    {
        text.enabled = false;
        quitT.enabled = false;
        playText.text = "Back";
        infoText.enabled = true;
    }

}
