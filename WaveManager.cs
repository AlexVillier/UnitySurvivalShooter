using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveManager : MonoBehaviour {
    public static int numDead;
    public static int totalAllowed;
    public static int numSpawned;
    public static int wave;
	public float TimeBetweenWaves = 16f;
    float delay = 4f;
    Text text;
	bool WaveOver = false;

	// Use this for initialization
	void Awake () {
        text = GetComponent<Text>();
        wave = 1;
        totalAllowed = 0;
	}
    
    void Update()
    {
        delay -= Time.deltaTime;
        //if all enemies for wave is dead and the code hasn't been run yet
		if(numSpawned >= totalAllowed && numDead == numSpawned && WaveOver == false && delay <= 0)
        {
			TimeManager.wait += 1;
			WaveOver = true;
        }

        //Wait time between waves
		if (WaveOver == true) {
			TimeBetweenWaves -= Time.deltaTime;
			if (TimeBetweenWaves <= 0) {
				wave += 1;
				text.text = "Wave " + wave;
				numSpawned = 0;
				numDead = 0;
                BunnySpawn.Spawned = 0;
                BunnySpawn.Allowed = 0;
				WaveOver = false;
				TimeBetweenWaves = 16f;
                delay = 4f;
                BunnySpawn.wait += 1;
                totalAllowed = 0;
                BearSpawn.Spawned = 0;
                BearSpawn.Allowed = 0;
                BearSpawn.wait += 1;
                PhantSpawn.Spawned = 0;
                PhantSpawn.Allowed = 0;
                PhantSpawn.wait += 1;
            }
		}
    }
}
