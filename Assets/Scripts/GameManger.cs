﻿using UnityEngine;
using System.Collections;
using System;



public class GameManger : MonoBehaviour {

    public Camera OverviewCamera;
	private bool paused = false;
    private bool gameover = false;
    // Use this for initialization
    void Start () {
        OverviewCamera.enabled = false;
		Time.timeScale = 1f;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			RestartGame();
		}
        if (Input.GetKeyDown (KeyCode.C))
        {
            OverviewCamera.enabled = !OverviewCamera.enabled;
        }
		if (Input.GetKeyDown (KeyCode.P)) {
			paused = togglePause ();
		}
	
	}
	void OnGUI()
	{
		if (paused) {
			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			
			GUILayout.BeginVertical("box");
			GUILayout.Label ("Game is paused!");
			if (GUILayout.Button ("Continue")) {
				paused = togglePause ();
			}
			if (GUILayout.Button ("Restart")) {
				Application.LoadLevel(Application.loadedLevel);
				
			}
			if (GUILayout.Button ("Exit")) {
				Application.Quit ();
			}
			GUILayout.EndVertical();		
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.EndArea();
		}
        if (gameover)
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            GUILayout.BeginVertical("box");
            GUILayout.Label("Game Over!");
            if (GUILayout.Button("Restart"))
            {
                Application.LoadLevel(Application.loadedLevel);

            }
            if (GUILayout.Button("Exit"))
            {
                Application.Quit();
            }
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.EndArea();
        }
    }

	private void RestartGame () 
	{
        Application.LoadLevel(Application.loadedLevel);
	}

	private bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);    
		}
	}
    public void gameOverToggle()
    {
        gameover = !gameover;
    }
}