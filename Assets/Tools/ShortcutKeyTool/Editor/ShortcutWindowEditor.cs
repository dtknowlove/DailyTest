using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class ShortcutWindowEditor : EditorWindow
{
	private static string shortcutPath = "";
	
	[MenuItem("LLL/Tools/ShortcutWindow _o",false,3)]
	static void SetUpShortcutWindow()
	{
		ShortcutWindowEditor myWindow =
			(ShortcutWindowEditor) EditorWindow.GetWindow(typeof(ShortcutWindowEditor), true, "Shortcut Key");
		myWindow.Show();
	}

	private ShortcutKeyItem ski;
	private List<ShortcutKeyItem> mSkiList;
	
	void Awake()
	{
		ski=new ShortcutKeyItem();
		mSkiList=new List<ShortcutKeyItem>();
		shortcutPath = Application.dataPath + "/Tools/ShortcutKeyTool/Editor/ShortcutKeyEditor.cs";
	}

	void OnGUI()
	{
		//绘制标题
		GUILayout.Space(10);
		GUI.skin.label.fontSize = 24;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUILayout.Label("Shortcut Style");
		GUI.skin.label.fontSize = 12;
		GUILayout.Space(10);

		EditorGUILayout.BeginHorizontal();
		ski.TargetName = EditorGUILayout.TextField(ski.TargetName, GUILayout.Width(200));
		ski.ShortKeyName = EditorGUILayout.TextField(ski.ShortKeyName, GUILayout.Width(200));
		if(GUILayout.Button("add",GUILayout.Width(30)))
		{
			Debug.LogFormat("add {0} {1} {2} {3} ",ski.TargetName,ski.ShortKeyName,ski.MenuItemName,ski.FuncName);
			if (!mSkiList.Contains(ski))
			{
				mSkiList.Add(ski);
				CreateUhortcutKeyEditorCode(shortcutPath,mSkiList);
				mSkiList.Clear();
			}
		}
		EditorGUILayout.EndHorizontal();
	}
	
	private void CreateUhortcutKeyEditorCode(string path,List<ShortcutKeyItem> skiList)
	{
		Debug.Log(path);
		string strDlg = path.Substring(path.LastIndexOf('/')+1).Split('.')[0];
		string strFilePath = path;
		if (File.Exists(strFilePath) == true)
		{
			StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
			StringBuilder strBuilder = new StringBuilder();

			strBuilder.AppendLine("using UnityEditor;");
			strBuilder.AppendLine();
//			strBuilder.AppendLine("namespace " );
//			strBuilder.AppendLine("{");
//			strBuilder.AppendLine();
			
			//类名开始
			strBuilder.AppendFormat("\tpublic class {0}", strDlg); 
			strBuilder.AppendLine();
			strBuilder.AppendLine("{");
			
			//方法开始
			for (int i = 0; i < skiList.Count; i++)
			{
				strBuilder.Append("\t\t").AppendFormat("[MenuItem(\"LLL/ShortcutKey/{0} {1}\")]",skiList[i].MenuItemName,skiList[i].ShortKeyName).AppendLine();
				strBuilder.Append("\t\t").AppendFormat("static void ShortcutKey_{0}()",skiList[i].FuncName).AppendLine();
				strBuilder.Append("\t\t").AppendLine("{");
				strBuilder.Append("\t\t").Append("\t").AppendFormat("EditorApplication.ExecuteMenuItem(\"{0}\");",skiList[i].TargetName).AppendLine();
				strBuilder.Append("\t\t").AppendLine("}").AppendLine();
			}
			//方法结束
			
			//类名结束
			strBuilder.Append("}");		
//			strBuilder.Append("}");

			sw.Write(strBuilder);
			sw.Flush();
			sw.Close();
		}
		AssetDatabase.Refresh();

		Debug.Log(">>>>>>>Success Create UIPrefab Code: " + strDlg);
	}
}


public class ShortcutKeyItem
{
	public string TargetName;
	public string ShortKeyName;

	public string MenuItemName
	{
		get
		{
			if (string.IsNullOrEmpty(TargetName))
				return null;
			return TargetName.Substring(TargetName.LastIndexOf('/')+1);
		}
	}

	public string FuncName
	{
		get
		{
			if (string.IsNullOrEmpty(TargetName))
				return null;
			return TargetName.Replace("/", "").Replace(" ","");
		}
	}

	public ShortcutKeyItem()
	{
		TargetName = "";
		ShortKeyName = "";
	}

	public ShortcutKeyItem(string _targetName,string _shortcutName)
	{
		TargetName = _targetName;
		ShortKeyName = _shortcutName;
	}
}
//
//[MenuItem("LLL/ShortcutKey/Player _p")]
//static void ShortcutKey_ProjectSettingsPlayer()
//{
//EditorApplication.ExecuteMenuItem("Edit/Project Settings/Player");
//}
//	
//[MenuItem("LLL/ShortcutKey/CreateFolder #f")]
//static void ShortcutKey_CreateFolder()
//{
//EditorApplication.ExecuteMenuItem("Assets/Create/Folder");
//}
//[MenuItem("LLL/ShortcutKey/RevealInFinder #r")]
//static void ShortcutKey_RevealInFinder()
//{
//EditorApplication.ExecuteMenuItem("Assets/Reveal in Finder");
//}
//	
//[MenuItem("LLL/ShortcutKey/Open #o")]
//static void ShortcutKey_Open()
//{
//EditorApplication.ExecuteMenuItem("Assets/Open");
//}