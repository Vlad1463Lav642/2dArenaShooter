using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float addToScore;
    private Rigidbody2D enemyRigidbody;
    private PlayerController player;

    private ScoreManager scoreManager;

    [SerializeField] private float shootTime = 0.5f;
    private float shootTimeCount;
    private bool isAttacked;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private int damage = 40;

    private Animator animator;

    private Vector3 directionToPlayer;
    private float angleToPlayer;

    private void Start()
    {
        currentHealth = maxHealth;

        animator = gameObject.GetComponentInChildren<Animator>();
        enemyRigidbody = gameObject.GetComponent<Rigidbody2D>();

        player = FindObjectOfType<PlayerController>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        if (shootTimeCount > 0)
        {
            shootTimeCount -= Time.deltaTime;
        }

        if (currentHealth <= 0)
        {
            scoreManager.AddScore(addToScore);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            directionToPlayer = player.transform.position - transform.position;
            angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90f;
            enemyRigidbody.rotation = angleToPlayer;
            directionToPlayer.Normalize();
        }

        if (!isAttacked)
        {
            animator.SetBool("Is Walk", true);
            MoveEnemy();
        }
        else
        {
            animator.SetBool("Is Walk", false);
        }
    }

    private void MoveEnemy()
    {
        enemyRigidbody.MovePosition(transform.position + (directionToPlayer * moveSpeed * Time.deltaTime));
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (shootTimeCount <= 0)
            {
                animator.SetBool("Is Shoot", true);
                Shoot();

                shootTimeCount = shootTime;
                isAttacked = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Is Shoot", false);
            isAttacked = false;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<BulletController>().SetDamage(damage);
        bulletRigidbody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}