﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;



public class GameManager : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public RawImage redDot;
    public Camera OverviewCamera;

    private OVRPlayerController player;
    public Text timerLabel;
    private float time;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        OverviewCamera.enabled = false;
        redDot.enabled = false;

        Time.timeScale = 1f;

        GameObject gameControllerObject = GameObject.FindWithTag("OVRPlayerController");
        if (gameControllerObject != null)
        {
            player = gameControllerObject.GetComponent<OVRPlayerController>();
        }
        if (player == null)
        {
            Debug.Log("Cannot find 'OVRPlayerController' script");
        }

    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timerLabel.text = "Timer: " + System.Math.Round(time, 2);

		if (Input.GetKeyDown (KeyCode.R)) {
			RestartGame();
		}
        if (Input.GetKeyDown (KeyCode.C))
        {
            OverviewCamera.enabled = !OverviewCamera.enabled;
        }
		if (Input.GetKeyDown (KeyCode.P)) {
            togglePause();
		}
	}

    public void RestartGame () 
	{
        Application.LoadLevel(Application.loadedLevel);
	}

	private void togglePause()
	{
        //pausePanel.SetActive(!pausePanel.activeSelf);
        if (Time.timeScale == 0f)
		{
            pausePanel.SetActive(false);
            redDot.enabled = false;
            Time.timeScale = 1f;
            Cursor.visible = false;
            cursorToggle();
        }
		else
		{
            pausePanel.SetActive(true);
            redDot.enabled = true;
            Time.timeScale = 0f;
            Cursor.visible = true;
            cursorToggle();
        }
	}
    public void gameOverToggle()
    {
        Cursor.visible = true;
        cursorToggle();
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        redDot.enabled = true;
    }
    public void MenuToggle()
    {
        togglePause();
    }

    public void quitGame()
    {
        Application.Quit();
    }
    public void cursorToggle()
    {
        if (Cursor.visible == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
