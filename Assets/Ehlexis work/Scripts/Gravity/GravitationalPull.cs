using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalPull : MonoBehaviour
{
    public float gravitationalForce = 9.8f;
    public float gravitationalRange = 10f;

    private Rigidbody2D rb;
    private LineRenderer lineRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Add CircleCollider2D component for the gravitational range
        CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D>();
        collider.isTrigger = true;
        collider.radius = gravitationalRange;

        // Add LineRenderer component to draw a circle around the collider
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 32; // number of points to draw the circle
        lineRenderer.useWorldSpace = false; // use local space for drawing the circle
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // set the material to use for the line
        lineRenderer.startColor = Color.white; // set the color of the line
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.1f; // set the width of the line
        lineRenderer.endWidth = 0.1f;
        UpdateLineRendererPositions();
    }

    void Update()
    {
        UpdateLineRendererPositions();
    }

    void UpdateLineRendererPositions()
    {
        // Update the positions to draw the circle
        float angle = 0f;
        float angleIncrement = (2f * Mathf.PI) / lineRenderer.positionCount;
        Vector3[] positions = new Vector3[lineRenderer.positionCount];
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            float x = Mathf.Sin(angle) * gravitationalRange;
            float y = Mathf.Cos(angle) * gravitationalRange;
            positions[i] = new Vector3(x, y, 0f);
            angle += angleIncrement;
        }
        lineRenderer.SetPositions(positions);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.attachedRigidbody != null)
        {
            Vector2 direction = transform.position - other.transform.position;
            float distance = direction.magnitude;
            float forceMagnitude = gravitationalForce * rb.mass * other.attachedRigidbody.mass / Mathf.Pow(distance, 2);
            Vector2 force = direction.normalized * forceMagnitude;
            other.attachedRigidbody.AddForce(force);
        }
    }
}