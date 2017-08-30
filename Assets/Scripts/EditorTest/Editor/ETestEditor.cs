using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ETest))]
public class ETestEditor :Editor 
{
	public override void OnInspectorGUI()
	{
		base.DrawDefaultInspector();
		ETest et = (ETest) target;
		et.RectData = EditorGUILayout.RectField("窗口坐标", et.RectData);
		et.TexData = EditorGUILayout.ObjectField("贴图", et.TexData,typeof(Texture2D),true) as Texture2D;
	}
}
