using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyQueue : MonoBehaviour {

	private string EventStr="obj,2,obj1,1,obj2";

	Queue<EventNode> queueN = new Queue<EventNode> ();


	IEnumerator Start ()
	{
		Debug.Log (11111);
		string[] s = EventStr.Split (',');
		for (int i = 0; i < s.Length; i++) 
		{
			float delayTime = 0;
			float.TryParse (s [i], out delayTime);
			if (delayTime == 0)
				queueN.Enqueue (new SpawnObjNode (GameObject.Find (s [i])));
			else
				queueN.Enqueue (new SpawnDelayNode(delayTime));
		}
		AssetAllNode a = new AssetAllNode (queueN);
		yield return StartCoroutine (a.Excute());

		Debug.Log (2222);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (333);
	}
}
