using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//事件父类
public abstract class EventNode 
{
	public abstract IEnumerator Excute();
}

public class SpawnObjNode:EventNode
{
	public GameObject mObj;

	public SpawnObjNode (GameObject obj)
	{
		this.mObj = obj;
	}

	public override IEnumerator Excute ()
	{
		GameObject.Instantiate (mObj);
		yield return 0;
	}
}

public class SpawnDelayNode:EventNode
{
	public float mDelayTime;
	public SpawnDelayNode (float dt)
	{
		this.mDelayTime = dt;
	}

	public override IEnumerator Excute ()
	{
		Debug.Log (mDelayTime);
		yield return new WaitForSeconds (mDelayTime);
		mDelayTime = 0;
	}
}

public class AssetAllNode
{
	Queue<EventNode> queue=new Queue<EventNode>();

	public AssetAllNode (Queue<EventNode> qq)
	{
		this.queue = qq;
	}

	public IEnumerator Excute()
	{
		while (this.queue.Count!=0) 
		{
			EventNode en = this.queue.Dequeue ();
			yield return en.Excute ();
		}
	}

}


