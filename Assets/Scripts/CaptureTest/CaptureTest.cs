using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CaptureTest : MonoBehaviour
{

	public Camera[] c;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			Texture2D t= CaptureCamera(new Rect(0, 0, Screen.width, Screen.height), c);
			SaveScreenShotTexture(t);
		}
	}

	private Texture2D CaptureCamera(Rect rect, params Camera[] cameras)
	{
		RenderTexture rt=new RenderTexture((int)Screen.width,(int)Screen.height,24);
		for (int i = 0; i < cameras.Length; i++)
		{
			if (cameras[i] != null)
			{
				cameras[i].targetTexture = rt;
				cameras[i].Render();
			}
		}

		RenderTexture.active = rt;
		Texture2D screenShot=new Texture2D((int)rect.width,(int)rect.height,TextureFormat.RGB24, false);
		screenShot.ReadPixels(rect,0,0);
		screenShot.Apply();
		
		for (int i = 0; i < cameras.Length; i++)
		{
			if (cameras[i] != null)
			{
				cameras[i].targetTexture = null;
			}
		}
		RenderTexture.active = null;
		GameObject.Destroy(rt);
		return screenShot;
	}

	private void SaveScreenShotTexture(Texture2D tex)
	{
		byte[] bytes = tex.EncodeToPNG();
		string path = Application.dataPath + "/../"+DateTime.Now+".png";
		File.WriteAllBytes(path,bytes);
		Debug.Log("Screen Saved:"+DateTime.Now+".png");
	}
}
