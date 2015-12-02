using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LevelSelect))]
public class LevelLinksEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        //LevelSelect m_script = (LevelSelect)target;
        //EditorGUILayout.;
    }
}
