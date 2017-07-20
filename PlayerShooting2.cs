using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShooting2 : MonoBehaviour {
    public static int damagePerShot = 34;
    public static float timeBetweenBullets = 0.15f;
    public static float range = 100f;
    public static int clip = 30;
    public static int maxClip = 30;
    public static float reloadTime = 3f;
    public static int totalAmmo = 270;
    public static int maxAmmo = 270;
    public static bool inUse = false;
    public static bool hasGun;
    public Light faceLight;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    GameObject amm;
    Text ammo;
    bool control = false;
    GameObject tot;
    Text totAmmo;
    GameObject gun;
    Text gunType;
    float timer2 = 0;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        amm = GameObject.FindGameObjectWithTag("Ammo");
        ammo = amm.GetComponent<Text>();
        tot = GameObject.FindGameObjectWithTag("TotalAmmo");
        totAmmo = tot.GetComponent<Text>();
        gun = GameObject.FindGameObjectWithTag("GunType");
        gunType = gun.GetComponent<Text>();
        hasGun = false;
    }


    void Update()
    {
        if (inUse == true)
        {
            timer += Time.deltaTime;
            timer2 += Time.deltaTime;
            if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 && clip > 0 && !control)
            {
                Shoot();
                clip -= 1;
            }
            else if (clip <= 0)
            {
                reloadTime -= Time.deltaTime;
                if (reloadTime <= 0)
                {
                    if (totalAmmo >= maxClip)
                    {
                        clip = maxClip;
                    }
                    else if (maxClip > totalAmmo && totalAmmo > 0)
                    {
                        clip = totalAmmo;
                    }
                    reloadTime = 3f;
                    totalAmmo -= clip;
                }
            }

            if (Input.GetButton("r") || control)
            {
                control = true;
                if (totalAmmo > 0)
                {
                    reloadTime -= Time.deltaTime;
                }

                if (reloadTime <= 0)
                {
                    if (totalAmmo + clip >= maxClip)
                    {
                        totalAmmo -= maxClip - clip;
                        clip = maxClip;
                    }
                    else if (maxClip > totalAmmo + clip && totalAmmo + clip > 0)
                    {
                        clip += totalAmmo;
                        totalAmmo = 0;
                    }
                    reloadTime = 3f;
                    control = false;
                }

            }
            if (Input.GetKey(KeyCode.C) && timer2 >= 0.5f)
            {
                inUse = false;
                PlayerShooting.inUse = true;
                gunType.text = "AK-47";
            }
            ammo.text = clip.ToString();
            totAmmo.text = totalAmmo.ToString();
            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                DisableEffects();
            }
        }
        else
        {
            timer2 = 0f;
        }
    }


    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
        faceLight.enabled = false;
    }


    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;
        faceLight.enabled = true;
        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
