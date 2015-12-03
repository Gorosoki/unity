using UnityEngine;
using System.Collections;
using System;



public class GameManager : MonoBehaviour {

    public Camera OverviewCamera;
	private bool paused = false;
    private bool gameover = false;
    private OVRPlayerController player;
    private Menu menu;
    private GameOver gameOver;
    // Use this for initialization
    void Start () {
        OverviewCamera.enabled = false;
        gameover = false;
        Time.timeScale = 1f;

        menu = GetComponent<Menu>();
        gameOver = GetComponent<GameOver>();

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
		if (Input.GetKeyDown (KeyCode.R)) {
			RestartGame();
		}
        if (Input.GetKeyDown (KeyCode.C))
        {
            OverviewCamera.enabled = !OverviewCamera.enabled;
        }
		if (Input.GetKeyDown (KeyCode.P)) {
            paused = !paused;
            menu.enabled = !menu.enabled;
            togglePause(); 
		}

        if(player.transform.position.y < 0)
        {
            gameOverToggle();
        }
	
	}
    void OnGUI()
    {
        if (paused)
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            GUILayout.BeginVertical("box");
            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Continue"))
            {
                togglePause();
            }
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

	private void togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
		}
		else
		{
			Time.timeScale = 0f;    
		}
	}
    public void gameOverToggle()
    {
        Time.timeScale = 0f;
        gameOver.enabled = gameOver.enabled;
        gameover = true;
    }
    public void MenuToggle()
    {
        togglePause();
        menu.enabled = !menu.enabled;
    }
}
