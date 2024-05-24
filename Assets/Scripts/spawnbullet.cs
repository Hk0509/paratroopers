using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbullet : MonoBehaviour
{
    public static bool Empty = true;
    public GameObject bullet, btmp;
    public static bool shooting = false;
    int i = 0;


    // Update is called once per frame
    void Update()
    {
        if (spawnbullet.Empty == true)
        {
            btmp = Instantiate(bullet, new Vector3(0.02f, -3.79f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            btmp.name = "B" + i.ToString();
            i++;
            spawnbullet.Empty = false;
        }
    }

    public void shoot()
    {
        spawnbullet.shooting = true;
        if (shootScript.score > 0)
            shootScript.score -= 1;

    }
}
