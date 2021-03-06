﻿using System;
using System.IO;
using UnityEditor;
using UnityEngine;

//[InitializeOnLoad]
public class FreeStyleWindowEditor : EditorWindow
{
	private const string IMAGE_KEY = "IMAGE_KEY";
	private const string SCRIPT_KEY = "SCRIPT_KEY";
	private const string UPDATEICON_KEY = "UPDATEICON_KEY";
	private static string defaultScriptsPath = "";
	private static string defaultIconPath = "";
	private static string mPngMetaPath="";
	private static string mCsPath = "";
//	private static bool mUpdateIcon = false;
	
//	static FreeStyleWindowEditor()
//	{
//		defaultScriptsPath = Application.dataPath + "/Scripts/";
//		defaultIconPath = Application.dataPath + "/Tools/FreeStyleTool/Res/icon.png";
//		mPngMetaPath = PlayerPrefs.GetString(IMAGE_KEY,defaultIconPath);
//		mCsPath = PlayerPrefs.GetString(SCRIPT_KEY,defaultScriptsPath);
//		if (EditorPrefs.GetBool(UPDATEICON_KEY, true))
//			UpdateIcon(mPngMetaPath, mCsPath);
//		else
//			UpdateIcon(mPngMetaPath,mCsPath,true);
//	}

	[MenuItem("LLL/Tools/FreeStyleWindow",false,1)]
	static void TestWindow()
	{
		Rect windowRect=new Rect(0,0,500,300);
		FreeStyleWindowEditor myWindow =
			(FreeStyleWindowEditor) EditorWindow.GetWindowWithRect(typeof(FreeStyleWindowEditor), windowRect,true, "Script Free Style");
		myWindow.Show();
	}

//	private void OnEnable()
//	{
//		mUpdateIcon = EditorPrefs.GetBool(UPDATEICON_KEY, false);
//	}

	void Awake()
	{
		defaultScriptsPath = Application.dataPath + "/Scripts/";
		defaultIconPath = Application.dataPath + "/Tools/FreeStyleTool/Res/icon.png";
		mPngMetaPath = PlayerPrefs.GetString(IMAGE_KEY,defaultIconPath);
		mCsPath = PlayerPrefs.GetString(SCRIPT_KEY,defaultScriptsPath);
	}

	//绘制窗口时调用
	void OnGUI () 
	{
		mPngMetaPath = PlayerPrefs.GetString(IMAGE_KEY);
		mCsPath = PlayerPrefs.GetString(SCRIPT_KEY);
		//绘制标题
		GUILayout.Space(10);
		GUI.skin.label.fontSize = 24;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUILayout.Label("Free Style");
		GUI.skin.label.fontSize = 12;
		GUILayout.Space(10);
		//icon
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("请输入图片路径:",GUILayout.Width(100));
		EditorGUILayout.TextField(mPngMetaPath,GUILayout.Width(300));
		if (GUILayout.Button("+",GUILayout.Width(30),GUILayout.Height(15)))
		{
			mPngMetaPath = EditorUtility.OpenFilePanelWithFilters("请选择一张图片", defaultIconPath, new string[] {"Image Files", "png"});
			PlayerPrefs.SetString(IMAGE_KEY,mPngMetaPath);
		}
		EditorGUILayout.EndHorizontal();
		//scripts
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("请输入脚本路径:",GUILayout.Width(100));
		EditorGUILayout.TextField(mCsPath,GUILayout.Width(300));
		if (GUILayout.Button("+",GUILayout.Width(30),GUILayout.Height(15)))
		{
			mCsPath = EditorUtility.OpenFolderPanel("请选择一个文件", defaultScriptsPath,"Scripts");
//			mCsPath = EditorUtility.OpenFilePanelWithFilters("请选择一个文件", defaultPath, new string[] {"Script Files", "cs"});
			PlayerPrefs.SetString(SCRIPT_KEY,mCsPath);
		}
		EditorGUILayout.EndHorizontal();
		//button
		EditorGUILayout.BeginHorizontal();
		if(GUILayout.Button("更新Icon",GUILayout.Height(20)))
		{
			UpdateIcon(mPngMetaPath,mCsPath);
			EditorPrefs.SetBool(UPDATEICON_KEY,true);
		}
		if(GUILayout.Button("恢复Icon",GUILayout.Height(20)))
		{
			UpdateIcon(mPngMetaPath,mCsPath,true);
			EditorPrefs.SetBool(UPDATEICON_KEY,false);
		}
		EditorGUILayout.EndHorizontal();
	}

	void OnDestroy()
	{
		PlayerPrefs.SetString(IMAGE_KEY,mPngMetaPath);
		PlayerPrefs.SetString(SCRIPT_KEY,mCsPath);
	}

	static void UpdateIcon(string pngMetaFile,string csDirectory,bool isReset=false)
	{
		pngMetaFile = pngMetaFile + ".meta";
//		Debug.Log(Directory.Exists(csDirectory));
		if (!File.Exists(pngMetaFile) || !Directory.Exists(csDirectory))
		{
			Debug.LogWarning("The path is not exit!");
			return;
		}
		string iconGUID = GetImageMetaGUID(pngMetaFile);
		string[] csFiles = Directory.GetFiles(csDirectory, "*.cs.meta", SearchOption.AllDirectories);
		foreach (string s in csFiles)
		{
			UpdateCsMetaFile(s,iconGUID,isReset);
		}
		AssetDatabase.Refresh();
	}

	static string GetImageMetaGUID(string path)
	{
		if(!File.Exists(path))
			return "";
		string metaStr = File.ReadAllText(path);
		string iconGUID="";
		string[] metaline = metaStr.Split('\n');
		for (int i = 0; i <metaline.Length; i++)
		{
			string[] tmp = metaline[i].Split(':');
			if (tmp[0].Equals("guid"))
			{
				iconGUID = tmp[1].Trim();
				break;
			}
		}
//		Debug.Log(iconGUID);
		return iconGUID;
	}
	
	static void UpdateCsMetaFile(string path,string guid,bool isReset=false)
	{
		if(!File.Exists(path))
			return;
		string metaStr = File.ReadAllText(path);
		string[] metaline = metaStr.Split('\n');
		for (int i = 0; i <metaline.Length; i++)
		{
			string[] tmp = metaline[i].Split(new string[]{":"},StringSplitOptions.RemoveEmptyEntries);
			if (tmp.Length > 1 && tmp[0].Trim().Equals("icon"))
			{
				if (isReset)
					metaline[i] = "  icon: {instanceID: 0}";
				else
					metaline[i] = "  icon: {fileID: 2800000, guid: " + guid + ",type: 3}";
			}
		}
		string resultStr = "";
		for (int i = 0; i < metaline.Length; i++)
		{
			resultStr += metaline[i] + "\n";
		}
		FileInfo fi=new FileInfo(path);
		StreamWriter sw = fi.CreateText();
		sw.WriteLine(resultStr.TrimEnd());
		sw.Close();
		sw.Dispose();
//		Debug.Log(path+" Complete!");
	}
}
