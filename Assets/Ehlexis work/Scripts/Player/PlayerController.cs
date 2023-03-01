using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // adjust this to change the speed of the player

    // Update is called once per frame
    void Update()
    {
        // Get the input from the user for the horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position of the player
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;

        // Set the new position of the player
        transform.position = newPosition;
    }
}