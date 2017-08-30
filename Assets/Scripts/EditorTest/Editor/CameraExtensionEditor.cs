///
///拓展系统自带组件的Inspector
///

using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(Camera),true)]
public class CameraExtensionEditor :Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
        if (GUILayout.Button("dtknowlove"))
        {
            Debug.Log("Dtknowlove is in camera component!");
        }
    }
}
