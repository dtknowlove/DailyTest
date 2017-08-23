using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HttpWrapper : MonoBehaviour
{
	private WWW www;
	private bool isStart = false;

	void Update()
	{
		if (isStart && www.progress <= 1)
			Debug.Log(www.progress * 100 + "%");
	}

	public void Get(string url, Action<WWW> onSuccess, Action onFail = null)
	{
		www=new WWW(url);
		StartCoroutine(WaitForResponse(www, onSuccess, onFail));
	}

	public void Post(string url, Dictionary<string, string> post, Action<WWW> onSuccess, Action onFail = null)
	{
		WWWForm form=new WWWForm();
		foreach (KeyValuePair<string,string> post_arg in post)
		{
			form.AddField(post_arg.Key,post_arg.Value);
		}
		www=new WWW(url,form);
		StartCoroutine(WaitForResponse(www, onSuccess, onFail));
	}

	private IEnumerator WaitForResponse(WWW www, Action<WWW> onSuccess, Action onFail = null)
	{
		isStart = true;
		yield return www;
		isStart = false;
		if (www.error == null)
			onSuccess(www);
		else
		{
			Debug.Log("WWW Error:"+www.error);
			if (onFail != null) onFail();
		}
	}
}
