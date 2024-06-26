﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playScript : MonoBehaviour
{
    public GameObject plybtn, controls;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    //Play button logic
    public void play()
    {
        Time.timeScale = 1f;
        controls.SetActive(true);
        plybtn.SetActive(false);
    }

    //Exit button logic
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Application Exited!!");
    }
}
