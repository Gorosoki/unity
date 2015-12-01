using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            GameManger gameManger = GetComponent<GameManger>();
            gameManger.gameOverToggle();
            print("Game Over!");
        }
    }
}
