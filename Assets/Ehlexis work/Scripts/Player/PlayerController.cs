using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // adjust this to change the speed of the player
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input from the user for the horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction of the player
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Set the velocity of the player
        rb.velocity = movementDirection * speed;
    }
}