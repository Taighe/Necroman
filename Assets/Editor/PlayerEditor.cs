using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor {
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Player currentPlayer = target as Player;

        if ( GUILayout.Button("My Groovy Button!!!") )
        {
            Undo.RecordObject(currentPlayer, "Player");
            currentPlayer.m_facing = nENTITY.Facing.RIGHT;
        }

    }

}
