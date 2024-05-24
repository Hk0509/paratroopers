using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateCannon : MonoBehaviour
{

    public Transform cannon;
    public float currentangle;
    public static float angle;
    public Text scorebrd;
    public GameObject go, cont;
    public Text got;


    private void Update()
    {
        angle = cannon.eulerAngles.z;
        scorebrd.text = "Score: " + shootScript.score.ToString();
        if (soldierControl.fin == true)
        {
            got.text = "Game Over\nScore: " + shootScript.score.ToString();
            go.SetActive(true);
            Time.timeScale = 0f;
            cont.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            leftRotate();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rightRotate();
        }
    }

    public void leftRotate()
    {
        currentangle = cannon.eulerAngles.z;
        currentangle = (currentangle + 5f) % 180;
        cannon.eulerAngles = new Vector3(0f, 0f, currentangle);
    }

    public void rightRotate()
    {
        currentangle = cannon.eulerAngles.z;
        currentangle = (currentangle - 5f) % 180;
        cannon.eulerAngles = new Vector3(0f, 0f, currentangle);
    }


}