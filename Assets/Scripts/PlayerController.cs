using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D playerRigidbody;
    private Vector2 movement;
    private Vector2 mousePosition;

    [SerializeField] private float moveSpeed;
    private new Camera camera;

    private void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        camera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            animator.SetBool("Is Walk", true);
        }
        else
        {
            animator.SetBool("Is Walk", false);
        }

        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 distanceToMouse = mousePosition - playerRigidbody.position;
        float angle = Mathf.Atan2(distanceToMouse.y,distanceToMouse.x) * Mathf.Rad2Deg - 90f;
        playerRigidbody.rotation = angle;
    }
}