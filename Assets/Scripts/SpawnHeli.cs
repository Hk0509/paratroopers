using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeli : MonoBehaviour
{
    int spawnmod,spawndir,spawnrow;
    public GameObject planeltor,planertol,tmp;
    float xpos,ypos;
    Vector3 pos;
    Quaternion rot;
    private void FixedUpdate()
    {
        spawnmod = Random.Range(2, 11);
        if(Time.time%spawnmod==0)
        {
            Debug.Log("Spawn");
            spawndir = Random.Range(0, 2);
            if(spawndir==0)
            {
                xpos = -16.15f;
                tmp = planeltor;
            }
            else
            {
                xpos = 16.15f;
                tmp = planertol;
            }
            spawnrow = Random.Range(0, 5);
            switch(spawnrow)
            {
                case 0: ypos = 4f;
                    break;
                case 1: ypos = 3f;
                    break;
                case 3: ypos = 2f;
                    break;
                case 4: ypos = 1f;
                    break;
            }
            pos = Vector3.zero;
            pos.x = xpos;
            pos.y = ypos;
            
            Instantiate(tmp, pos, tmp.transform.rotation);
            Debug.Log(spawnrow.ToString());
        }
    }
}
