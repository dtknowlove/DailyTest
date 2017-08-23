using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("My Personal Scripts/AndroidAPI",1)]
public class AndroidAPI : MonoBehaviour {

	void Start () 
	{
		//设置当前游戏物体的名称，android中将给该物体发送消息
		this.name="AndroidAPI";	
	}
	//接收android调用unity方法的回调
	public void SetCameraColor ()
	{
		Camera.main.backgroundColor = new Color (1f,0.5f,0.5f);
	}

	void OnGUI()
	{
		if (GUILayout.Button ("print ", GUILayout.Height (145))) 
		{	
			AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject> ("currentActivity");

			AndroidJavaClass activity = new AndroidJavaClass ("com.example.sdfsdfsdf.ExampleActivity"); 
			activity.CallStatic ("ShowToast", jo, "CNM 调了吗？～");
		}
		
//
//		//通过传值打开Activity  
//		if(GUILayout.Button("调用Android API中打开Activity",GUILayout.Height(45)))  
//		{  
//			//获取Android的Java接口  
//			AndroidJavaClass jc=new AndroidJavaClass("com.unity3d.player.UnityPlayer");  
//			AndroidJavaObject jo=jc.GetStatic<AndroidJavaObject>("currentActivity");  
//			//打开博主的博客  
//			jo.Call("StartWebView","http://blog.csdn.net/");  
//		}  
//		//通过API调用Toast  
//		if(GUILayout.Button("调用Android API中的Toast",GUILayout.Height(45)))  
//		{  
//			//获取Android的Java接口  
//			AndroidJavaClass jc=new AndroidJavaClass("com.unity3d.player.UnityPlayer");  
//			AndroidJavaObject jo=jc.GetStatic<AndroidJavaObject>("currentActivity");  
//			jo.Call("ShowToast","为Unity3D编写Android插件是件苦差事！");  
//		} 
		if(GUILayout.Button("调用Android API中的震动方法",GUILayout.Height(245)))  
		{  
			//获取Android的Java接口  
			AndroidJavaClass jc=new AndroidJavaClass("com.unity3d.player.UnityPlayer");  
			AndroidJavaObject jo=jc.GetStatic<AndroidJavaObject>("currentActivity");  

			AndroidJavaClass activity = new AndroidJavaClass ("com.example.sdfsdfsdf.ExampleActivity"); 
			activity.CallStatic("SetVibrator",jo,2000);
		}

		if(GUILayout.Button("通过SendMessage调用Unity中的方法",GUILayout.Height(45)))  
		{  
			//获取Android的Java接口  
			AndroidJavaClass jc=new AndroidJavaClass("com.unity3d.player.UnityPlayer");  
			AndroidJavaObject jo=jc.GetStatic<AndroidJavaObject>("currentActivity");  

			AndroidJavaClass activity = new AndroidJavaClass ("com.example.sdfsdfsdf.ExampleActivity"); 
			activity.CallStatic("InvokeUnity",jo,"你大爷！");  
		}  
	}
}
