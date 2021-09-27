using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletForce;
    [SerializeField] private int damage;

    [SerializeField] private float shootTime = 0.5f;
    private float shootTimeCount;

    private Animator animator;
    [SerializeField] private Animator fireAnimator;

    private void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (shootTimeCount > 0)
        {
            shootTimeCount -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1"))
        {
            if (shootTimeCount <= 0)
            {
                animator.SetBool("Is Shoot", true);
                fireAnimator.SetBool("Fire", true);
                Shoot();

                shootTimeCount = shootTime;
            }
        }
        else
        {
            animator.SetBool("Is Shoot", false);
            fireAnimator.SetBool("Fire", false);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<BulletController>().SetDamage(damage);
        bulletRigidbody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public float GetBulletForce()
    {
        return bulletForce;
    }

    public int GetDamage()
    {
        return damage;
    }
}