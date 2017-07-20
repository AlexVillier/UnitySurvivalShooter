using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour {

    public Text text;
    Text infoText;
    GameObject info;
    Text howTo;
    GameObject howT;
    GameObject playerName;
    public static string Name = "Player1";
    GameObject place;
    Text placeholder;
    GameObject namer;
    Text name1;
    GameObject quit;
    Text quitT;

    void Awake()
    {
        text = GetComponent<Text>();
        info = GameObject.FindGameObjectWithTag("Info");
        infoText = info.GetComponent<Text>();
        howT = GameObject.FindGameObjectWithTag("HowTo");
        howTo = howT.GetComponent<Text>();
        playerName = GameObject.FindGameObjectWithTag("playerName");
        place = GameObject.FindGameObjectWithTag("placeholder");
        placeholder = place.GetComponent<Text>();
        namer = GameObject.FindGameObjectWithTag("name");
        name1 = namer.GetComponent<Text>();
        quit = GameObject.FindGameObjectWithTag("Quit");
        quitT = quit.GetComponent<Text>();
    }

    public void OnMouseDown()
    {
        //check to make sure not on How ToPlay page
        if(text.text == "Play")
        {
            playerName.GetComponent<Image>().enabled = true;
            playerName.GetComponent<InputField>().enabled = true;
            placeholder.enabled = true;
            text.text = "Back";
            howTo.enabled = false;
            quitT.enabled = false;
        }
        //else if it is on HTP page, act as "back" button
        else
        {
            text.text = "Play";
            infoText.enabled = false;
            quitT.enabled = true;
            howTo.enabled = true;
            playerName.GetComponent<Image>().enabled = false;
            playerName.GetComponent<InputField>().enabled = false;
            placeholder.enabled = false;
        }

    }

    public void play()
    {
        //start playing game
        Name = name1.text.ToString();
        SceneManager.LoadScene(1);
    }

}