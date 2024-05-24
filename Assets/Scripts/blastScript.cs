using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blastScript : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(2f, 0f);
        Destroy(gameObject, 1f); // Destroy the game object 3 seconds after it is created
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 18f || transform.position.x < -18f)
        {
            Destroy(gameObject);
        }
    }
}
