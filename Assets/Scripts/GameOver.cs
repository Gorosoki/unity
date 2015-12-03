using UnityEngine;
using System.Collections;



public class GameOver : VRGUI
{

    public GUISkin skin;

    public override void OnVRGUI()
    {
        GUI.skin = skin;

        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        GUILayout.BeginVertical();
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
        GUILayout.EndArea();
    }
    
}