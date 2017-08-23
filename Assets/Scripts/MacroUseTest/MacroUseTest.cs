using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("My Personal Scripts/MacroUseTest",2)]
public class MacroUseTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ShowPaiosToast ();
		ShowMI3Toast ();

		#if MI3
		ShowMI3Toast ();
		#endif
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	[System.Diagnostics.Conditional("PAIOS")]
	void ShowPaiosToast()
	{
		Debug.Log ("[This is a toast!]\n" +
			"[Paios======>I am Paios!]");
	}
	[System.Diagnostics.Conditional("MI3")]
	void ShowMI3Toast()
	{
		Debug.Log ("[This is a toast!]\n" +
			"[MI3======>I am MI3!]");
	}

	#if PAIOS
		public void BBB() 
		{
			Debug.Log("BBB");
		}
	#endif
}
