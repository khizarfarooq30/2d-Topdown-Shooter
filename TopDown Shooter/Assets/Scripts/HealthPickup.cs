using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    Player playerScript;
    public int healAmount;
    public GameObject pickupFx;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate(pickupFx, transform.position, Quaternion.identity);
            playerScript.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
