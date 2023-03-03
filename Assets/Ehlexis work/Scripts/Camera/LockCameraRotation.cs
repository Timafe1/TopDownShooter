using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCameraRotation : MonoBehaviour
{
    private Vector3 initialRotation;
    private float initialYPosition;
    private Transform playerTransform;

    private void Awake()
    {
        // Store the initial rotation and Y position of the camera
        initialRotation = transform.localEulerAngles;
        initialYPosition = transform.localPosition.y;

        // Find the player object by tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Make sure the player object exists
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Could not find object with tag 'Player' for camera raycast!");
        }
    }

    private void LateUpdate()
    {
        // Lock the rotation of the camera to the player
        transform.localRotation = Quaternion.Euler(initialRotation);

        // Lock the Y position of the camera
        Vector3 newPosition = transform.localPosition;
        newPosition.y = initialYPosition;
        transform.localPosition = newPosition;

        // Check if the player transform exists
        if (playerTransform != null)
        {
            // Get the camera's forward vector
            Vector3 cameraForward = transform.forward;
            cameraForward.y = 0f;
            cameraForward.Normalize();

            // Get the player's input vector
            Vector3 inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

            // Rotate the input vector to match the camera's forward vector
            inputVector = Quaternion.LookRotation(cameraForward) * inputVector;

            // Move the player object based on the rotated input vector
            playerTransform.position += inputVector * Time.deltaTime;
        }
    }
}