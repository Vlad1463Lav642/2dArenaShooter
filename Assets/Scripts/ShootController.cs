using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private int damage = 40;

    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Is Shoot", true);
            Shoot();
        }
        else
        {
            animator.SetBool("Is Shoot", false);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<BulletController>().SetDamage(damage);
        bulletRigidbody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}