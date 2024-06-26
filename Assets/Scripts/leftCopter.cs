﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftCopter : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject soldier;
    int dropnow;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(2f, 0f);
    }

    private void FixedUpdate()
    {
        dropnow = Random.Range(1, 21);

        // Check if the x-coordinate is not in the range -1 to 1
        if (transform.position.x < -1f || transform.position.x > 1f)
        {
            // Check if it's time to drop a soldier
            if (Time.time % dropnow == 0)
            {
                Instantiate(soldier, transform.position, soldier.transform.rotation);
            }
        }

        // Destroy the helicopter if it moves out of bounds
        if (transform.position.x > 18f || transform.position.x < -18f)
        {
            Destroy(gameObject);
        }
    }
}
