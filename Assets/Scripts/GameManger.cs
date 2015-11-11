using UnityEngine;
using System.Collections;



public class GameManger : MonoBehaviour {

    public Camera OverviewCamera;
    // Use this for initialization
    void Start () {
		BeginGame();
        OverviewCamera.enabled = false;
	
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
	
	}

	private void BeginGame ()
	{

	}

	private void RestartGame () 
	{
		BeginGame ();
        Application.LoadLevel(Application.loadedLevel);
	}
}
