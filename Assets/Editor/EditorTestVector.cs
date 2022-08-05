using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

[CustomEditor(typeof(TestMyVector))]
public class EditorTestVector : Editor
{
    public override void OnInspectorGUI()
    {
        TestMyVector tmv = (TestMyVector)target;
        
        GUILayout.Label("Vector1: ", EditorStyles.boldLabel);
        
        GUILayout.BeginHorizontal();

        tmv.vector1.x = EditorGUILayout.FloatField("x:", tmv.vector1.x);
        tmv.vector1.y = EditorGUILayout.FloatField("y:", tmv.vector1.y);
        
        GUILayout.EndHorizontal();
        
        GUILayout.Label("Vector2: ", EditorStyles.boldLabel);
        
        GUILayout.BeginHorizontal();

        tmv.vector2.x = EditorGUILayout.FloatField("x:", tmv.vector2.x);
        tmv.vector2.y = EditorGUILayout.FloatField("y:", tmv.vector2.y);
        
        GUILayout.EndHorizontal();
        
        tmv.factor = (float)EditorGUILayout.Slider("Factor Escalar", tmv.factor, 0, 1);
    }
}
