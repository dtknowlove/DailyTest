using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCallTest : MonoBehaviour
{

	[SerializeField] private GameObject Prefab;
	
	void Start ()
	{
		GameObject tmpObj;
		for (int i = 0; i < 500; i++)
		{
			tmpObj = Instantiate<GameObject>(Prefab, transform);
			if (i / 100 <= 0)
			{
				tmpObj.transform.localScale=Vector3.one*(-1);
			}
		}
		string a = "ff",b="lalal";
		string c= a + b;
	}
	
	void Update () 
	{
		
	}
}
