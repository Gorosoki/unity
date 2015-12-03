using UnityEngine;
using System.Collections;
using System;



public class GameManager : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public Camera OverviewCamera;
	private bool paused = false;
    private bool gameover = false;
    private OVRPlayerController player;
    //private Menu menu;
    //private GameOver gameOver;
    // Use this for initialization
    void Start () {
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        OverviewCamera.enabled = false;
        gameover = false;
        Time.timeScale = 1f;

       // menu = GetComponent<Menu>();
       // gameOver = GetComponent<GameOver>();

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
            togglePause();
            paused = !paused;
            //menu.enabled = !menu.enabled;
             
		}

        if(player.transform.position.y < 0)
        {
            gameOverToggle();
        }
	
	}
    //void OnGUI()
    //{
    //    if (paused)
    //    {
    //        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
    //        GUILayout.FlexibleSpace();
    //        GUILayout.BeginHorizontal();
    //        GUILayout.FlexibleSpace();

    //        GUILayout.BeginVertical();
    //        GUILayout.Label("Game is paused!");
    //        if (GUILayout.Button("Continue"))
    //        {
    //            togglePause();
    //            paused = !paused;
    //        }
    //        if (GUILayout.Button("Restart"))
    //        {
    //            Application.LoadLevel(Application.loadedLevel);

    //        }
    //        if (GUILayout.Button("Exit"))
    //        {
    //            Application.Quit();
    //        }
    //        GUILayout.EndVertical();
    //        GUILayout.FlexibleSpace();
    //        GUILayout.EndHorizontal();
    //        GUILayout.FlexibleSpace();
    //        GUILayout.EndArea();
    //    }
    //    if (gameover)
    //    {
    //        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
    //        GUILayout.FlexibleSpace();
    //        GUILayout.BeginHorizontal();
    //        GUILayout.FlexibleSpace();

    //        GUILayout.BeginVertical("box");
    //        GUILayout.Label("Game Over!");
    //        if (GUILayout.Button("Restart"))
    //        {
    //            Application.LoadLevel(Application.loadedLevel);

    //        }
    //        if (GUILayout.Button("Exit"))
    //        {
    //            Application.Quit();
    //        }
    //        GUILayout.EndVertical();
    //        GUILayout.FlexibleSpace();
    //        GUILayout.EndHorizontal();
    //        GUILayout.FlexibleSpace();
    //        GUILayout.EndArea();
    //    }
    //}


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
			Time.timeScale = 1f;
		}
		else
		{
            pausePanel.SetActive(true);
			Time.timeScale = 0f;    
		}
	}
    public void gameOverToggle()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        //gameOver.enabled = gameOver.enabled;
        gameover = true;
    }
    public void MenuToggle()
    {
        togglePause();
        //menu.enabled = !menu.enabled;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
