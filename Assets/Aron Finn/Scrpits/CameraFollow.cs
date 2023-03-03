using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /*************************************************
     * This script should be placed on the camera,
     * which will follow the player at a fixed rotation,
     * at a fixed distance.
     * ***********************************************/

    //VARIABLES

    //The player variable is a GameObject that represents the player
    // that the camera will follow.

    public GameObject player;

    // The offset is a Vector3 that represents the fixed
    // distance between the camera and the Player.

    public Vector3 offset;

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}