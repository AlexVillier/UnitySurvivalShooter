using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int totalScore;

    Text text;

    //reset score whenn game starts
    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
        totalScore = 0;
    }

    //update score
    void Update ()
    {
        text.text = "Score: " + score;
    }
}
