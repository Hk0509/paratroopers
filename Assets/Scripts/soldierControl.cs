using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierControl : MonoBehaviour
{
    public Rigidbody2D self;
    bool dropped = false;
    bool climbing = false;
    bool movingToCenter = false;
    public static bool fin = false;
    public float climbSpeed = 0.5f; // Speed of climbing
    public float moveSpeed = 0.3f; // Speed of horizontal movement
    public float topYPosition = -2.0f; // The Y position that represents the top of the pedestal
    public float centerThreshold = 0.0f; // Threshold distance to consider the soldier at the center
    // public int cnt = 0;

    private bool isOnPedestal = false;
    private Vector2 centerPosition;

    void Start()
    {
        centerPosition = GameObject.FindGameObjectWithTag("Pedestal").transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y <= -4.3f && !dropped)
        {
            self.gravityScale = 0f;
            self.velocity = Vector3.zero;
            dropped = true;
        }

        if (transform.position.y <= -4.3f && !climbing && !isOnPedestal)
        {
            if (transform.position.x > centerPosition.x)
            {
                self.velocity = Vector3.left * moveSpeed;
            }
            else if (transform.position.x < centerPosition.x)
            {
                self.velocity = Vector3.right * moveSpeed;
            }
        }

        if (climbing && transform.position.y <= -3.0f)
        {
            // Move the soldier up until it reaches the top of the pedestal
            self.velocity = Vector3.up * climbSpeed;

            if (transform.position.y >= topYPosition)
            {
                climbing = false;
                self.velocity = Vector3.zero; // Stop vertical movement
                StartMovingToCenter();
            }
        }
        else if (climbing && transform.position.y >= -3.0f)
        {
            climbing = false;
            self.velocity = Vector3.zero; // Stop vertical movement
            StartMovingToCenter();
        }

        if (movingToCenter)
        {
            // Move towards the center of the pedestal along the X-axis only
            Vector2 direction = (centerPosition - (Vector2)transform.position).normalized;
            direction.y = 0; // Set Y component to 0 to restrict movement vertically
            self.velocity = direction * moveSpeed;

            // Check if the soldier is close enough to the center horizontally
            if (Mathf.Abs(transform.position.x - centerPosition.x) <= centerThreshold)
            {
                movingToCenter = false;
                self.velocity = Vector3.zero;
            }
        }

    }

    // Detect trigger collision with the pedestal and the cannon
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pedestal"))
        {
            isOnPedestal = true;
            StartClimbing();
        }
        else if (other.gameObject.CompareTag("Cannon"))
        {
            GameOver();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pedestal"))
        {
            isOnPedestal = false;
        }
    }

    // Start climbing logic
    void StartClimbing()
    {
        climbing = true;
        self.velocity = Vector3.zero; // Stop any current horizontal movement
    }

    // Start moving towards the center of the pedestal
    void StartMovingToCenter()
    {
        movingToCenter = true;
    }

    // Game Over logic
    void GameOver()
    {
        Debug.Log("GameOver");
        self.velocity = Vector3.zero;
        soldierControl.fin = true;
    }
}
