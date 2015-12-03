using UnityEngine;
using System.Collections;



public class GameOver : MonoBehaviour {
    private GameManager gameManager;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameManager");
        if (gameControllerObject != null)
        {
            gameManager = gameControllerObject.GetComponent<GameManager>();
        }
        if (gameManager == null)
        {
            Debug.Log("Cannot find 'GameManager' script");
        }
    }
    void OnTriggerEnter (Collider col)
    {
        print (col.tag);
        if (col.tag == "Player")
        {
            //GameManger gameManger = GetComponent<GameManger>();
            gameManager.gameOverToggle();
            Debug.Log("Game Over!");
        }
    }
}
