using UnityEngine;
using UnityEditor;

public class DailyEditor
{
	/// <summary>
	/// 合并多个模型点collider
	/// </summary>
	[MenuItem ("LLL/Merge Collider")]
	static void MergeCollider () 
	{
		Transform parent = 	Selection.activeGameObject.transform;
		Vector3 postion = parent.position;
		Quaternion rotation = parent.rotation;
		Vector3 scale = parent.localScale;
		parent.position = Vector3.zero;
		parent.rotation = Quaternion.Euler(Vector3.zero);
		parent.localScale = Vector3.one;
 
		Collider[] colliders = parent.GetComponentsInChildren<Collider>();
		foreach (Collider child in colliders){
			UnityEngine.Object.DestroyImmediate(child);
		}
		Vector3 center = Vector3.zero;
		Renderer[] renders  = 	parent.GetComponentsInChildren<Renderer>();
		foreach (Renderer child in renders){
			center += child.bounds.center;   
		}
		center /= parent.GetComponentsInChildren<Renderer>().Length; //center is average center of children
		Bounds bounds = new Bounds(center,Vector3.zero);//Now you have a center, calculate the bounds by creating a zero sized 'Bounds'
		Vector3 max, min;
		foreach (Renderer child in renders){
			bounds.Encapsulate(child.bounds);   //计算所有子物体边界的最大和最小点
		}
		
		BoxCollider boxCollider = 	parent.gameObject.AddComponent<BoxCollider>();
		boxCollider.center = bounds.center - parent.position;
		boxCollider.size = bounds.size;
 
		parent.position = postion;
		parent.rotation = rotation;
		parent.localScale = scale;
	}
	/// <summary>
	/// 重置多个模型的中心点
	/// </summary>
	[MenuItem ("LLL/Reset Center4Model")]
	static void ResetCenter4Model()
	{
		Transform parent = 	Selection.activeGameObject.transform;
		Vector3 postion = parent.position;
		Quaternion rotation = parent.rotation;
		Vector3 scale = parent.localScale;
		parent.position = Vector3.zero;
		parent.rotation = Quaternion.Euler(Vector3.zero);
		parent.localScale = Vector3.one;
 
 
		Vector3 center = Vector3.zero;
		Renderer[] renders = parent.GetComponentsInChildren<Renderer>();
		foreach (Renderer child in renders){
			center += child.bounds.center;   
		}
		center /= parent.GetComponentsInChildren<Transform>().Length; 
		Bounds bounds = new Bounds(center,Vector3.zero);
		foreach (Renderer child in renders){
			bounds.Encapsulate(child.bounds);   
		}
	
		parent.position = postion;
		parent.rotation = rotation;
		parent.localScale = scale;
 
		foreach(Transform t in parent){
			t.position = t.position -  bounds.center;
		}
		parent.transform.position = bounds.center + parent.position;
	}
	[CustomEditor(typeof(SceneAsset),true)]
	public class CustomInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			base.DrawDefaultInspector();
			string path = AssetDatabase.GetAssetPath(target);
			GUI.enabled = true;
			if (path.EndsWith(".unity"))
				GUILayout.Button("我是场景！");
			else if(path.EndsWith(".cs"))
				GUI.Button(new Rect(0,0,300,100), "我是脚本！");
			else if(path.EndsWith(""))
				GUILayout.Button("我是文件夹！");
		}
	}
	[CustomEditor(typeof(DefaultAsset),true)]
	public class CustomInspectorDefault : Editor
	{
		public override void OnInspectorGUI()
		{
			base.DrawDefaultInspector();
			string path = AssetDatabase.GetAssetPath(target);
			GUI.enabled = true;
			if (path.EndsWith(".unity"))
				GUILayout.Button("我是场景！");
			else if(path.EndsWith(".cs"))
				GUI.Button(new Rect(0,0,300,100), "我是脚本！");
			else if(path.EndsWith(""))
				GUILayout.Button("我是文件夹！");
		}
	}

//	public class ShortCutKey : Editor
//	{
//		public override void OnInspectorGUI()
//		{
//			base.DrawDefaultInspector();
//			if (Input.GetKeyDown(KeyCode.LeftCommand) && Input.GetKeyDown(KeyCode.J))
//			{
//				Debug.Log("lallala");
//				EditorApplication.ExecuteMenuItem("Window/Editor Tests Runner");
//			}
//		}
//	}

//	[MenuItem("LLL/Restart %#n")]
//	static void OpenOtherItem()
//	{
////		EditorApplication.OpenProject(Application.dataPath+"/../");
//		EditorApplication.ExecuteMenuItem("Window/Editor Tests Runner");
//	}
}
