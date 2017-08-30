using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ColorWindowEditor : EditorWindow 
{
	public class ColorData
	{
		public string name;
		public Color color;

		public ColorData(string _n,Color _c)
		{
			this.name = _n;
			this.color = _c;
		}
	}
	
	//模板路径
	string templateColorPath="Assets/Scripts/EditorTest/ColorPresetTool/Res/color.colors";
	string newColorPathDir="Assets/Editor/";
	string newColorPath="";
	string colorName = "default";
	string suffix = ".colors";
	
	[MenuItem("LLL/Tool/ColorPresetWindow",false,2)]
	static void ColorWindow()
	{
		Rect windowRect=new Rect(0,0,540,350);
		ColorWindowEditor myWindow =
			(ColorWindowEditor) EditorWindow.GetWindowWithRect(typeof(ColorWindowEditor), windowRect, true, "Color Preset");
		myWindow.Show();
	}

	private List<ColorData> cDataList;
	void Awake()
	{
		cDataList=new List<ColorData>();
	}

	void OnGUI()
	{
		//绘制标题
		GUILayout.Space(10);
		GUI.skin.label.fontSize = 24;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUILayout.Label("Color Style");
		GUI.skin.label.fontSize = 12;
		GUILayout.Space(10);

		//name
		EditorGUILayout.BeginHorizontal();
		GUILayout.Space(10);
		EditorGUILayout.LabelField("Preset Name:",GUILayout.Width(75));
		colorName = EditorGUILayout.TextField(colorName, GUILayout.Width(100));
		EditorGUILayout.EndHorizontal();
		GUILayout.Space(10);
		//show
		if (cDataList.Count > 0)
		{
			for (int i = 0; i < cDataList.Count; i++)
			{
				AddItem(cDataList[i]);
			}
		}
		//add & save
		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("add"))
		{
			cDataList.Add(new ColorData("按钮",Color.blue));
		}
		if (GUILayout.Button("save"))
		{
			SaveItemToColorPreset();
		}
		EditorGUILayout.EndHorizontal();
		
		//clear
		if (GUILayout.Button("clear all colorpreset"))
		{
			ClearAllFileBySuffix(newColorPathDir,suffix);
		}
	}

	void AddItem(ColorData c)
	{
		EditorGUILayout.BeginHorizontal();
		GUILayout.Space(10);
		EditorGUILayout.LabelField("Name:",GUILayout.Width(40));
		c.name = EditorGUILayout.TextField(c.name,GUILayout.Width(100));
		EditorGUILayout.LabelField("Value:",GUILayout.Width(40));
		c.color = EditorGUILayout.ColorField("",c.color,GUILayout.Width(250));
		if (GUILayout.Button("delete",GUILayout.Width(70),GUILayout.Height(20)))
		{
			if (cDataList.Contains(c))
			{
				cDataList.Remove(c);
			}
		}
		EditorGUILayout.EndHorizontal();
	}

	void SaveItemToColorPreset()
	{
		//复制一份新的模板到newColorPath目录下
		newColorPath = newColorPathDir + colorName + suffix;
		AssetDatabase.DeleteAsset(newColorPath);
		AssetDatabase.CopyAsset(templateColorPath,newColorPath);
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
	
		UnityEngine.Object newColor = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(newColorPath);
		SerializedObject serializedObject = new SerializedObject(newColor);
		SerializedProperty property = serializedObject.FindProperty("m_Presets");
		property.ClearArray();
 
		//数据写进去
		for(int i =0; i< cDataList.Count; i++)
		{
			property.InsertArrayElementAtIndex(i);
			SerializedProperty colorsProperty = property.GetArrayElementAtIndex(i);
			colorsProperty.FindPropertyRelative("m_Name").stringValue = cDataList[i].name;
			colorsProperty.FindPropertyRelative("m_Color").colorValue = cDataList[i].color;
		}
		//保存
		serializedObject.ApplyModifiedProperties();
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
	}

	void ClearAllFileBySuffix(string directory, string suffix)
	{
		if (!Directory.Exists(directory)) return;
		Debug.Log("Start delete...");
		string[] dirs = Directory.GetFiles(directory,"*"+ suffix, SearchOption.TopDirectoryOnly);
		for (int i = 0; i < dirs.Length; i++)
		{
			AssetDatabase.DeleteAsset(dirs[i]);
			Debug.Log("Delete "+dirs[i]);
		}
		AssetDatabase.Refresh();
		Debug.Log("End delete!!!");
	}

	void OnDestroy()
	{
		
	}
}
