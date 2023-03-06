using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;

    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    public Transform target;
    Vector2 moveDirection;
    //variable for how far ahead of the player  
    public float timeAheadOfPlayer = 1f;
    bool canTurn = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Player").transform;
    }


    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"Damage Amount: {damageAmount}");
        health -= damageAmount;
        Debug.Log($"Health is now: {health}");

        if (health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }
    // Update is called once per frame
    private void Update()
    {
        if (target)
        {
            // Calculate the direction to the predicted position
            Vector3 predictedPosition = (Vector2)target.position + (target.GetComponent<Rigidbody2D>().velocity * timeAheadOfPlayer);
            Vector3 direction = predictedPosition - transform.position;

            Debug.DrawLine(transform.position, predictedPosition, Color.blue); // Draw a line to the predicted position
            Debug.DrawRay(target.position, target.GetComponent<Rigidbody2D>().velocity, Color.green); // Draw a ray in the player's velocity direction

            // Set the rotation of the enemy to face the predicted position
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (canTurn)
            {
                rb.rotation = angle;
            }

            // Calculate the intercept direction
            Vector2 interceptDirection = direction.normalized;

            Debug.DrawRay(transform.position, interceptDirection, Color.red); // Draw a ray in the intercept direction

            // Limit the turn rate to make the movement smoother
            float maxTurnRate = 180f; // degrees per second
            float deltaAngle = Mathf.MoveTowardsAngle(rb.rotation, angle, maxTurnRate * Time.deltaTime);
            rb.rotation = deltaAngle;

            if (Physics2D.Raycast(transform.position, direction, direction.magnitude, LayerMask.GetMask("Player")))
            {
                canTurn = false;
            }
            else
            {
                canTurn = true;
            }

            moveDirection = interceptDirection;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            if (canTurn)
            {
                rb.rotation = Quaternion.LookRotation(Vector3.forward, moveDirection).eulerAngles.z;
            }

            rb.velocity = moveDirection * moveSpeed;
        }
    }
}
