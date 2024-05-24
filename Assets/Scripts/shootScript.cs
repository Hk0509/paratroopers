﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector3 dir;
    public GameObject smoke;
    bool foradded = false;
    public static int score = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        shoot();
    }

    public void shoot()
    {
        if (spawnbullet.shooting == true && foradded == false)
        {
            dir = Quaternion.AngleAxis(rotateCannon.angle, Vector3.forward) * Vector3.right;
            rb.AddForce(dir * 2000f);
            spawnbullet.shooting = false;
            spawnbullet.Empty = true;
            foradded = true;
        }
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ensure that this script is attached to a bullet GameObject
        if (collision.CompareTag("Heli"))
        {
            if (gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                Instantiate(smoke, transform.position, smoke.transform.rotation);
                score += 5;
            }
        }
        else if (collision.CompareTag("Attacker"))
        {
            if (gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                Instantiate(smoke, transform.position, smoke.transform.rotation);
                score += 10;
            }
        }
    }
}
