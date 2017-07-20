using UnityEngine;
using System.Collections;

public class BunnySpawn : MonoBehaviour {
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public static int spawnRate;
    public static int totalKills;
    public static int Spawned;
    public static int Allowed;
    public static int wait;
    int old_wait = 0;
    float timer;
    float timer2 = 0f;


    void Start()
    {
        wait = 0;
        Allowed = 2 * ((WaveManager.wave - 1) * (WaveManager.wave - 1)) + (WaveManager.wave - 1) + 6;
        WaveManager.totalAllowed += Allowed;
        Spawn();
    }

    void Update()
    {
        if (wait != old_wait)
        {
            Allowed = 2 * ((WaveManager.wave - 1) * (WaveManager.wave - 1)) + (WaveManager.wave - 1) + 6;
            WaveManager.totalAllowed += Allowed;
            old_wait = wait;
        }
        timer2 += Time.deltaTime;
        if (timer2 >= spawnTime)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        timer2 = 0f;
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        if (Spawned < Allowed)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            WaveManager.numSpawned += 1;
            Spawned += 1;
            Wait();
        }
    }

    void Wait()
    {
        float a = Time.deltaTime;
        timer = 0;
        while (timer - a <= spawnTime)
        {
            timer += Time.deltaTime;
        }
    }
}
