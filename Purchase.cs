using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Purchase : MonoBehaviour {
    public string type;
    public int price = 50;
    GameObject player;
    bool playerInRange;
    GameObject purchase;
    Text purchaseText;
    GameObject priceT;
    Text priceText;
    GameObject gun;
    Text gunType;
    
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        purchase = GameObject.FindGameObjectWithTag("PurchaseText");
        purchaseText = purchase.GetComponent<Text>();
        priceT = GameObject.FindGameObjectWithTag("Price");
        priceText = priceT.GetComponent<Text>();
        gun = GameObject.FindGameObjectWithTag("GunType");
        gunType = gun.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is close enough, and they press enter, and do not have max ammo
        if (playerInRange == true && Input.GetKey(KeyCode.Return) && ScoreManager.score >= price)
        {
            //if the crate is the ammo crate
            if (type == "Ammo" && (PlayerShooting.clip != PlayerShooting.maxClip || PlayerShooting.totalAmmo != PlayerShooting.maxAmmo))
            {
                if (PlayerShooting.inUse == true)
                {
                    ScoreManager.score -= price;
                    PlayerShooting.clip = PlayerShooting.maxClip;
                    PlayerShooting.totalAmmo = PlayerShooting.maxAmmo;
                }
                if (PlayerShooting2.inUse == true)
                {
                    ScoreManager.score -= price;
                    PlayerShooting2.clip = PlayerShooting2.maxClip;
                    PlayerShooting2.totalAmmo = PlayerShooting2.maxAmmo;
                }
            //else if the crate is for the Uzi
            } else if(type == "Uzi" && gunType.text != type)
            {
                //change gun values to that of the Uzi
                if (PlayerShooting2.inUse == false)
                {
                    ScoreManager.score -= price;
                    PlayerShooting2.damagePerShot = 20;
                    PlayerShooting2.timeBetweenBullets = 0.05f;
                    PlayerShooting2.range = 45;
                    PlayerShooting2.reloadTime = 1.5f;
                    PlayerShooting2.clip = 32;
                    PlayerShooting2.maxClip = 32;
                    PlayerShooting2.maxAmmo = 320;
                    PlayerShooting2.totalAmmo = 320;
                    gunType.text = type;
                    PlayerShooting2.inUse = true;
                    PlayerShooting.inUse = false;
                    PlayerShooting2.hasGun = true;
                }
            }
        }
    }
    //when the player is within range of crate
    void OnTriggerEnter(Collider other)
    {
        //if the object is the player
        if (other.gameObject == player)
        {
            playerInRange = true;
            purchaseText.enabled = true;
            purchaseText.text = "Press Return to purchase " + type + "       ";
            priceText.enabled = true;
            priceText.text = "(" + price + ")";
        }
    }
    //when the player leaves
    void OnTriggerExit(Collider other)
    {
        //check to make sure it is the player
        if (other.gameObject == player)
        {
            playerInRange = false;
            purchaseText.enabled = false;
            priceText.enabled = false;
        }
    }
}
