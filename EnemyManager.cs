using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public static int spawnRate;
    public static int totalKills;
    public static int numBunnySpawned;
    public static int numBearSpawned;
    public static int numPhantSpawned;
    public static int bunnyAllowed;
    public static int bearAllowed;
    public static int phantAllowed;
    public static int wait;
    int old_wait = 0;
    float timer;
    float timer2 = 0f;


    void Start ()
    {
        numBearSpawned = 0;
        numBunnySpawned = 0;
        numPhantSpawned = 0;
        bunnyAllowed = 0;
        bearAllowed = 0;
        phantAllowed = 0;
        wait = 0;
        Spawn();
    }

    void Update()
    {
        if (wait != old_wait)
        {
            if (spawnRate == 1)
            {
                bunnyAllowed = 2 * ((WaveManager.wave - 1) * (WaveManager.wave - 1)) + (WaveManager.wave - 1) + 6;
                WaveManager.totalAllowed += bunnyAllowed;
            }
            else if (spawnRate == 2)
            {
                if (WaveManager.wave >= 2)
                {
                    bearAllowed = 2 * ((WaveManager.wave - 1) * (WaveManager.wave - 1)) + (WaveManager.wave - 1) + 6;
                    WaveManager.totalAllowed += bearAllowed;
                }
            }
            else if (spawnRate == 3)
            {
                if (WaveManager.wave >= 3)
                {
                    phantAllowed = 2 * ((WaveManager.wave - 1) * (WaveManager.wave - 1)) + (WaveManager.wave - 1) + 6;
                    WaveManager.totalAllowed += phantAllowed;
                }
            }
            old_wait = wait;
        }
        timer2 += Time.deltaTime;
        if(timer2 >= spawnTime)
        {
            Spawn();
        }
    }

    void Spawn ()
    {
		timer2 = 0f;
        
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        if (spawnRate == 1 && numBunnySpawned < bunnyAllowed)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            WaveManager.numSpawned += 1;
            numBunnySpawned += 1;
            Wait();
        }
         else if (spawnRate == 2 && numBearSpawned < bearAllowed)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            WaveManager.numSpawned += 1;
            numBearSpawned += 1;
            Wait();
        }
        else if (spawnRate == 3 && numPhantSpawned < phantAllowed)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            WaveManager.numSpawned += 1;
            numPhantSpawned += 1;
            Wait();
        }
    }

    void Wait()
    {
        float a = Time.deltaTime;
        timer = 0;
        while (timer-a <= spawnTime)
        {
            timer += Time.deltaTime;
        }
    }
}

