using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour {

	private GameObject tmpObj;

	// Use this for initialization
	void Start () 
	{
		tmpObj = GameObject.Find ("Cube");
		//Destroy (tmpObj,5);
		Debug.Log ("ID:"+tmpObj.GetInstanceID()+"Name:"+tmpObj);
		Debug.Log (tmpObj.hideFlags);
		tmpObj.hideFlags = HideFlags.HideInInspector;
		Debug.Log (tmpObj.isStatic);
		Debug.Log (tmpObj.scene.name);
		Debug.Log (tmpObj.GetHashCode());
		tmpObj = null;
		Debug.Log (tmpObj);
		
		GameObject btn=GameObject.Find("Canvas/Button");
		GameObject btn2 = GameObject.Instantiate(btn, GameObject.Find("Canvas").transform);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
