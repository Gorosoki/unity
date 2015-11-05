using UnityEngine;
using System.Collections;

public class GameManger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		BeginGame();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			RestartGame();
		}
	
	}

	private void BeginGame ()
	{

	}

	private void RestartGame () 
	{
		BeginGame ();
	}
}
