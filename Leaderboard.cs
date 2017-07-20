using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {
    public Text name;
    public Text kills;
    public Text totalScore;
    public Text bunnies;
    public Text bear;
    public Text phant;
    public static int bunnyKill;
    public static int bearKill;
    public static int phantKill;
    public static int totalKills;
    Canvas leaderboard;

	// Use this for initialization
	void Start () {
        leaderboard = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
        //if the player presses the tab key
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //turn on leaderboard
            leaderboard.enabled = true;
        }
        //when the player releases the tab key
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            //turn off the leaderboard
            leaderboard.enabled = false;
        }
        //update leaderboard
        totalScore.text = ScoreManager.totalScore.ToString();
        kills.text = totalKills.ToString();
        name.text = Play.Name;
        bunnies.text = bunnyKill.ToString();
        bear.text = bearKill.ToString();
        phant.text = phantKill.ToString();
	}
}
