using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "myobject",menuName = "Create myobject",order = 1)]
public class MyObject : ScriptableObject
{
	public int myInt = 42;
	public List<string> newStr=new List<string>()
	{
		"a","b","c"
	};
}

public class SerializedPropertyTest : MonoBehaviour
{
	void Start()
	{
		MyObject obj = ScriptableObject.CreateInstance<MyObject>();
		AssetDatabase.CreateAsset(obj,"Assets/Resources/myobj.asset");
		SerializedObject serializedObject = new SerializedObject(obj);

		SerializedProperty serializedPropertyMyInt = serializedObject.FindProperty("myInt");
		SerializedProperty serializedListProperty = serializedObject.FindProperty("newStr");

		Debug.Log("myInt " + serializedPropertyMyInt.intValue);
		Debug.Log("newStr" + serializedListProperty.arraySize + " " + serializedListProperty.hasChildren + " " +
		          serializedListProperty.GetArrayElementAtIndex(2).stringValue);
	}
}
