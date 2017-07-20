using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyAmmo : MonoBehaviour
{
    public int price = 50;
    GameObject player;
    bool playerInRange;
    GameObject purchase;
    Text purchaseText;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        purchase = GameObject.FindGameObjectWithTag("PurchaseText");
        purchaseText = purchase.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange == true && Input.GetKey(KeyCode.Return) && ScoreManager.score >= price)
        {
            ScoreManager.score -= price;
            PlayerShooting.clip = PlayerShooting.maxClip;
            PlayerShooting.totalAmmo = PlayerShooting.maxAmmo;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
            purchaseText.enabled = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
            purchaseText.enabled = false;
        }
    }
}