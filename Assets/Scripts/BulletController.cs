using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int weaponDamage = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(weaponDamage);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(weaponDamage);
        }

        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        weaponDamage = damage;
    }
}