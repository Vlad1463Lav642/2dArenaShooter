using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    [SerializeField] private int healValue;
    private PlayerController player;
    private HealthBarController healthBar;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        healthBar = FindObjectOfType<HealthBarController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.SetCurrentHealth(healValue);
            healthBar.AddHealth(healValue);
            Destroy(gameObject);
        }
    }
}