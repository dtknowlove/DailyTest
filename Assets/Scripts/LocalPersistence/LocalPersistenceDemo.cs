using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPersistenceDemo : MonoBehaviour {

	void Start () 
	{
		Debug.Log (GetComponentInParent<Transform>().name);
		foreach (Transform item in this.GetComponentsInParent<Transform>()) 
		{
			Debug.Log (item.name);
		}

	}
	
	void Update () 
	{
		
	}
}
