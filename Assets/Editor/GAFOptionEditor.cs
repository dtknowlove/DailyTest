using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using GAF.Core;

public class GAFOptionEditor
{
	private static string prefabsPath = Application.dataPath + "/Test";
	private static string[] splitStr = new string[]{ "Assets"};

	[MenuItem("GAF/AnimationSetting %t")]
	static void InitAnimationSetting()
	{
		List<GameObject> gafList= GetAllGaFObj (prefabsPath);
		if (null == gafList)
			return;

		foreach (GameObject g in gafList) 
		{
			if (null != g) 
			{
				if (g.GetComponent<GAFMovieClip> () != null)
					GAFMovieClipSetting (g.GetComponent<GAFMovieClip> ());
				if(g.GetComponentsInChildren<GAFMovieClip>()!=null)
				{
					foreach (GAFMovieClip gg in g.GetComponentsInChildren<GAFMovieClip>()) 
					{
						GAFMovieClipSetting (gg);
					}
				}
			}
		}
	}

	/// <summary>
	/// 获取所有的预制物集合
	/// </summary>
	/// <returns>The all ga F object.</returns>
	/// <param name="path">Path.</param>
	static List<GameObject> GetAllGaFObj(string path)
	{
		List<GameObject> resultList = new List<GameObject> ();
		if (Directory.Exists (path)) 
		{
			DirectoryInfo dir = new DirectoryInfo (path);
			FileInfo[] files=dir.GetFiles("*.prefab",SearchOption.AllDirectories);
			for (int i = 0; i < files.Length; i++) 
			{
				string p = splitStr[0]+files [i].FullName.Split (splitStr,StringSplitOptions.None)[1];
				Debug.Log (p);
				GameObject g = AssetDatabase.LoadAssetAtPath(p, typeof(GameObject))as GameObject;
				if (null == g) 
				{
					Debug.Log ("【不存在】" + p);
					continue;
				}
				resultList.Add (g);
			}
		}
		return resultList;
	}

	/// <summary>
	/// 设置GAF Prefab
	/// </summary>
	/// <param name="g">The green component.</param>
	static void GAFMovieClipSetting(GAFMovieClip g)
	{
		if(false==g.isLoaded)
			g.reload ();
		g.settings.playAutomatically = false;
		g.settings.wrapMode = GAFInternal.Core.GAFWrapMode.Once;
	}

}
