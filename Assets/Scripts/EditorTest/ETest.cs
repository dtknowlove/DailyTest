using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETest : MonoBehaviour
{
	[HideInInspector]
	[SerializeField]//设置后保存为预制物时数据不会丢失
	private Rect mRectData;
	public Rect RectData {
		get { return mRectData; }
		set { mRectData = value; }
	}
	[HideInInspector]
	[SerializeField]
	private Texture2D mTexData;
	public Texture2D TexData
	{
		get { return mTexData; }
		set { mTexData = value; }
	}

	// Use this for initialization
	void Start () 
	{
		Debug.Log(RectData);
		Debug.Log(TexData.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
