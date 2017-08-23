using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUnit : MonoBehaviour
{

	public BaseUnit unit;
	
	// Use this for initialization
	void OnGUI()
	{
		if(GUI.Button(new Rect(10,10,150,100),"攻击测试" ))
			unit.BeAttacked();
	}
}
