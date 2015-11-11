using UnityEngine;
using System.Collections;

public Camera camera2;

public class GameManger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		BeginGame();
        camera2.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			RestartGame();
		}
        if (Input.GetKeyDown (KeyCode.C))
        {
            camera2.enabled = !camera2.enabled;
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
