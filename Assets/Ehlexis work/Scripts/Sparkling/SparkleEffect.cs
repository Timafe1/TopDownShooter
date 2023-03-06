using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleEffect : MonoBehaviour
{
    public ParticleSystem sparkleParticleSystem; // the particle system that emits sparkles

    private void Start()
    {
        sparkleParticleSystem.Stop(); // stop the particle system initially
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // check if the collider belongs to the player
        {
            sparkleParticleSystem.Play(); // play the particle system when the player collides with the object
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // check if the collider belongs to the player
        {
            sparkleParticleSystem.Stop(); // stop the particle system when the player exits the object's collider
        }
    }
}