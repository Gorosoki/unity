using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    public GameManager gameManager;
	// Use this for initialization
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col)
    {
        print (col.gameObject.tag);
        if (col.gameObject.tag == "OVRPlayerController")
        {
            gameManager.gameOverToggle();
        }
    }
}
