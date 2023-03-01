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
    public float timeAheadOfPlayer = 1f;


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
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;

            // predict player's position after 1 second
            Vector3 predictedPosition = (Vector2)target.position + (target.GetComponent<Rigidbody2D>().velocity * timeAheadOfPlayer);

            // adjust direction to intercept player's path
            Vector2 interceptDirection = (predictedPosition - transform.position).normalized;
            float interceptAngle = Mathf.Atan2(interceptDirection.y, interceptDirection.x) * Mathf.Rad2Deg;

            // limit the turn rate to make the movement smoother
            float maxTurnRate = 180f; // degrees per second
            float deltaAngle = Mathf.MoveTowardsAngle(rb.rotation, interceptAngle, maxTurnRate * Time.deltaTime);
            rb.rotation = deltaAngle;

            moveDirection = interceptDirection;
        }
    }
    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }

    }
}
