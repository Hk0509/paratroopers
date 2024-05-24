using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left : MonoBehaviour
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
        if (Time.time % dropnow == 0)
        {
            Instantiate(soldier, transform.position, soldier.transform.rotation);
        }
        if (transform.position.x > 18f || transform.position.x < -18f)
        {
            Destroy(gameObject);
        }
    }

}
