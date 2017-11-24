using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ETest))]
public class ETestEditor :Editor
{
	private ETest et;
	
	void OnEnable()
	{
		et = (ETest) target;
	}

	public override void OnInspectorGUI()
	{
		et.RectData = EditorGUILayout.RectField("窗口坐标", et.RectData);
		et.TexData = EditorGUILayout.ObjectField("贴图", et.TexData,typeof(Texture2D),true) as Texture2D;

		ShowAirPortList(serializedObject.FindProperty("airportLineList"));
		if (GUILayout.Button("Add AirPort"))
		{
			et.airportLineList.Add(new AirPort());
		}
		if (GUILayout.Button("Delete AirPort"))
		{
			if (et.airportLineList.Count > 0)
			{
				et.airportLineList.RemoveAt(et.airportLineList.Count-1);
			}
		}
		serializedObject.ApplyModifiedProperties();
	}

	private void ShowAirPortList(SerializedProperty list)
	{
		EditorGUILayout.PropertyField(list);
		EditorGUI.indentLevel += 1;
		if (list.isExpanded)
		{
			EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
			for (int i = 0; i < list.arraySize; i++)
			{
				ShowAirPort(list.GetArrayElementAtIndex(i),i);
			}
		}
		EditorGUI.indentLevel -= 1;
	}

	private void ShowAirPort(SerializedProperty t, int index)
	{
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.PropertyField(t, new GUIContent("AirPort_" + index));
		EditorGUILayout.EndHorizontal();
		SerializedProperty name = t.FindPropertyRelative("name");
		
		SerializedProperty list = t.FindPropertyRelative("planes");
		EditorGUI.indentLevel += 1;
		if (t.isExpanded)
		{
			EditorGUILayout.PropertyField(name,new GUIContent("Name"));
//			EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
//			EditorGUILayout.PropertyField(list, new GUIContent("planes_" + index));
			for (int i = 0; i < list.arraySize; i++)
			{
				ShowAirPlane(list.GetArrayElementAtIndex(i), i);
			}
			
			EditorGUILayout.BeginHorizontal ();

			GUILayout.Space (30);

			if(GUILayout.Button ("AddItem",EditorStyles.miniButtonLeft))
			{
				list.InsertArrayElementAtIndex (list.arraySize);
			}

			if(GUILayout.Button ("DeleteItem",EditorStyles.miniButtonRight))
			{
				list.DeleteArrayElementAtIndex (list.arraySize-1);
			}

			EditorGUILayout.EndHorizontal ();
		}
		EditorGUI.indentLevel -= 1;
	}

	private void ShowAirPlane(SerializedProperty t, int index)
	{
		EditorGUILayout.PropertyField(t, new GUIContent("AirPlane_" + index));
		SerializedProperty name = t.FindPropertyRelative("name");
		SerializedProperty airportpark = t.FindPropertyRelative("airportpark");
		EditorGUI.indentLevel += 1;
		if (t.isExpanded)
		{
			EditorGUILayout.PropertyField(name,new GUIContent("Name"));
			EditorGUILayout.PropertyField(airportpark,new GUIContent("airportpark"));
		}
		EditorGUI.indentLevel -= 1;
	}
}
