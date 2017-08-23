using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MacroEditor : Editor
{
	const string MENU_PAIOS="LLL/Environment/Paios";
	const string MENU_MI3="LLL/Environment/MI3";

	[MenuItem(MacroEditor.MENU_PAIOS)]
	public static void Change2PaiosEnv()
	{
		PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.Android, "PAIOS");
	}

	[MenuItem(MacroEditor.MENU_MI3)]
	public static void Change2MI3Env()
	{
		PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.Android, "MI3");
	}
	[MenuItem("Assets/Log Name %g")]
	public static void LogSeletedGameObjectName()
	{
		Debug.Log (EditorApplication.applicationContentsPath);
		Debug.Log (EditorApplication.applicationPath);
		Debug.Log (Selection.activeGameObject.name);
	}
	[MenuItem("CONTEXT/Rigidbody/Double Mass")]
	static void DoubleMass(MenuCommand command)
	{
		Rigidbody body = (Rigidbody)command.context;
		body.mass = body.mass * 2;
		Debug.Log (body.mass);
	}
	[MenuItem("GameObject/MyCategory/Custom Game Object", false, 10)]
	static void CreateCustomGameObject(MenuCommand menuCommand)
	{
		// Create a custom game object
		GameObject go = new GameObject("Custom Game Object");
		// Ensure it gets reparented if this was a context click (otherwise does nothing)
		GameObjectUtility.SetParentAndAlign (go, menuCommand.context as GameObject);
//		Debug.Log((menuCommand.context as GameObject));
//		if (null != (menuCommand.context as GameObject))
//			go.transform.SetParent ((menuCommand.context as GameObject).transform);
		// Register the creation in the undo system
		Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
		Selection.activeObject = go;
	}

	[MenuItem("LLL/Log selected obj's name")]
	static void LogSelectedName()
	{
		Debug.Log(Selection.activeGameObject.name);
	}
	
	
	[MenuItem("LLL/Log selected obj's name",true)]
	static bool ValidateLogSelectedName()
	{
//		Debug.Log("lalala");
		return Selection.activeGameObject != null;
	}

}
