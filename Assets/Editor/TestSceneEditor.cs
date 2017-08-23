using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(GameObject))]
public class TestSceneEditor : Editor
{
    void OnSceneGUI()
    {
        GameObject monoTest = Selection.activeGameObject;
        
        Handles.Label(monoTest.transform.position+Vector3.up*2,monoTest.name+"     :     "+monoTest.transform.position.ToString());
        
        Handles.BeginGUI();
        
        GUILayout.BeginArea(new Rect(0,0,100,100));
        
        if(GUILayout.Button("按钮"))
            Debug.Log("Scene Test!");
        
        GUILayout.Label("我在编辑scene视图");
        GUILayout.EndArea();
        
        Handles.EndGUI();
    }
}
