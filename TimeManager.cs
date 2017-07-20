using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeManager : MonoBehaviour {
	Text text;
	public static int wait;
	public float CountDown = 16f;
	int old_wait = 0;
	float timer;
	bool counter = false;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text>();
		wait = 0;
		text.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (wait != old_wait) {
			old_wait = wait;
			counter = true;
			//Count ();
		}

		if (counter == true) {
			text.enabled = true;
			CountDown -= Time.deltaTime;
			int display = (int)CountDown;
			text.text = display.ToString ();
			if (CountDown <= 0) {
				counter = false;
				CountDown = 16f;
				text.enabled = false;
			}
		}
	}
}
