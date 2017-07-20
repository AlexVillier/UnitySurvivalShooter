using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour {
    Light flashlight;
	// Use this for initialization
	void Start () {
        flashlight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            if (flashlight.enabled == true)
            {
                flashlight.enabled = false;
            }
            else
            {
                flashlight.enabled = true;
            }
        }
    }
}
