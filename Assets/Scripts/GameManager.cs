using UnityEngine;
using System.Collections;
using System;



public class GameManager : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public Camera OverviewCamera;

    private OVRPlayerController player;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        OverviewCamera.enabled = false;

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

        //if(player.transform.position.y < 0)
        //{
        //    gameOverToggle();
        //}
	
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
			Time.timeScale = 1f;
            Cursor.visible = false;
            cursorToggle();
        }
		else
		{
            pausePanel.SetActive(true);
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
