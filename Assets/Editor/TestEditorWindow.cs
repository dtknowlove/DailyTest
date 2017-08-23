using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestEditorWindow : EditorWindow
{
    [MenuItem("LLL/Open Window",false,51)]
    static void OpenWindow()
    {
        TestEditorWindow testEditorWindow =
            (TestEditorWindow) EditorWindow.GetWindowWithRect(typeof(TestEditorWindow), new Rect(0, 0, 500, 500), true,
                "这是一个测试窗口");
        testEditorWindow.Show();
    }

    private string text;
    private Texture texture;

    void Awake()
    {
        texture = Resources.Load<Texture>("tex");
    }

    void OnGUI()
    {
        text = EditorGUILayout.TextField("输入文字", text);
        
        if(GUILayout.Button("打开通知",GUILayout.Width(200)))
            this.ShowNotification(new GUIContent("This is a notification!"));
        
        if(GUILayout.Button("关闭通知",GUILayout.Width(200)))
            this.RemoveNotification();
        
        EditorGUILayout.LabelField("鼠标在窗口的位置：",Event.current.mousePosition.ToString());
        
        texture=EditorGUILayout.ObjectField("添加贴图",texture,typeof(Texture),true) as Texture;

        if (GUILayout.Button("关闭窗口", GUILayout.Width(200)))
            this.Close();

    }

    void OnInspectorUpdate()
    {
        this.Repaint();
    }
}
