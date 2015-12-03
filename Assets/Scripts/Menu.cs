using UnityEngine;
using System.Collections;

public class Menu : VRGUI {

    public GUISkin skin;
    private GameManager gameManager;

    public override void OnVRGUI()
    {
        GUI.skin = skin;
        gameManager = GetComponent<GameManager>();
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        GUILayout.BeginVertical("box");
        GUILayout.Label("Game is paused!");
        if (GUILayout.Button("Continue"))
        {
            gameManager.MenuToggle();
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
}
