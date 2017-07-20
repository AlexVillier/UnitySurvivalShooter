using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
//using UnityEditor;

public class PauseManager : MonoBehaviour {
    Canvas canvas;
	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
        //if player presses Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    //pause the game
    public void Pause()
    {
        canvas.enabled = !canvas.enabled;
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    //if button "Quit" is pressed
    public void Stop()
    {
        //EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
