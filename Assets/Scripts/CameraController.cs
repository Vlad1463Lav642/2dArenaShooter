using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController player;

    private Vector3 lastPosition;
    private float distanceX;
    private float distanceY;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        lastPosition = player.transform.position;
    }

    private void Update()
    {
        distanceX = player.transform.position.x - lastPosition.x;
        distanceY = player.transform.position.y - lastPosition.y;

        transform.position = new Vector3(transform.position.x + distanceX, transform.position.y + distanceY, transform.position.z);

        lastPosition = player.transform.position;
    }
}