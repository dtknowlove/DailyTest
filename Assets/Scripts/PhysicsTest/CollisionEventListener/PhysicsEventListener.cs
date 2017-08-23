using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class CollisionEnterEvent: UnityEvent<Collision>{}
public sealed class CollisionStayEvent: UnityEvent<Collision>{}
public sealed class CollisionExitEvent: UnityEvent<Collision>{}
public sealed class TriggerEnterEvent: UnityEvent<Collider>{}
public sealed class TriggerStayEvent: UnityEvent<Collider>{}
public sealed class TriggerExitEvent: UnityEvent<Collider>{}

public class PhysicsEventListener: MonoBehaviour
{
	public static PhysicsEventListener Get(GameObject go)
	{
		PhysicsEventListener listener = go.GetComponent<PhysicsEventListener> ();
		if (listener == null)
			listener = go.AddComponent<PhysicsEventListener> ();
		return listener;
	}

	void OnDestroy()
	{
		RemoveAll ();
	}

	void RemoveAll()
	{
		if (collisionEnterEvent != null) 
		{
			collisionEnterEvent.RemoveAllListeners ();
			collisionEnterEvent = null;
		}
		if (collisionStayEvent != null) 
		{
			collisionStayEvent.RemoveAllListeners ();
			collisionStayEvent = null;
		}
		if (collisionExitEvent != null) 
		{
			collisionExitEvent.RemoveAllListeners ();
			collisionExitEvent = null;
		}
		if (triggerEnterEvent != null) 
		{
			triggerEnterEvent.RemoveAllListeners ();
			triggerEnterEvent = null;
		}
		if (triggerStayEvent != null) 
		{
			triggerStayEvent.RemoveAllListeners ();
			triggerStayEvent = null;
		}
		if (triggerExitEvent != null) 
		{
			triggerExitEvent.RemoveAllListeners ();
			triggerExitEvent = null;
		}
	}

	#region OnCollisionEnter
	private CollisionEnterEvent collisionEnterEvent;

	public void RegisterCollisionEnter(UnityAction<Collision> evt)
	{

		if (collisionEnterEvent == null)
			collisionEnterEvent = new CollisionEnterEvent ();
		collisionEnterEvent.AddListener (evt);
	}

	public void UnRegisterCollisionEnter(UnityAction<Collision> evt)
	{
		if (collisionEnterEvent == null)
			return;
		collisionEnterEvent.RemoveListener (evt);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collisionEnterEvent != null)
			collisionEnterEvent.Invoke (collision);
	}
	#endregion

	#region OnCollisionStay
	private CollisionStayEvent collisionStayEvent;

	public void RegisterCollisionStay(UnityAction<Collision> evt)
	{

		if (collisionStayEvent == null)
			collisionStayEvent = new CollisionStayEvent ();
		collisionStayEvent.AddListener (evt);
	}

	public void UnRegisterCollisionStay(UnityAction<Collision> evt)
	{
		if (collisionStayEvent == null)
			return;
		collisionStayEvent.RemoveListener (evt);
	}

	void OnCollisionStay(Collision collision)
	{
		if (collisionStayEvent != null)
			collisionStayEvent.Invoke (collision);
	}
	#endregion

	#region OnCollisionExit
	private CollisionExitEvent collisionExitEvent;

	public void RegisterCollisionExit(UnityAction<Collision> evt)
	{

		if (collisionExitEvent == null)
			collisionExitEvent = new CollisionExitEvent ();
		collisionExitEvent.AddListener (evt);
	}

	public void UnRegisterCollisionExit(UnityAction<Collision> evt)
	{
		if (collisionExitEvent == null)
			return;
		collisionExitEvent.RemoveListener (evt);
	}

	void OnCollisionExit(Collision collision)
	{
		if (collisionExitEvent != null)
			collisionExitEvent.Invoke (collision);
	}
	#endregion

	#region OnTriggerEnter
	private TriggerEnterEvent triggerEnterEvent;

	public void RegisterTriggerEnter(UnityAction<Collider> evt)
	{

		if (triggerEnterEvent == null)
			triggerEnterEvent = new TriggerEnterEvent ();
		triggerEnterEvent.AddListener (evt);
	}

	public void UnRegisterTriggerEnter(UnityAction<Collider> evt)
	{
		if (triggerEnterEvent == null)
			return;
		triggerEnterEvent.RemoveListener (evt);
	}

	void OnTriggerEnter(Collider collider)
	{
		if (triggerEnterEvent != null)
			triggerEnterEvent.Invoke (collider);
	}
	#endregion

	#region OnTriggerStay
	private TriggerStayEvent triggerStayEvent;

	public void RegisterTriggerStay(UnityAction<Collider> evt)
	{

		if (triggerStayEvent == null)
			triggerStayEvent = new TriggerStayEvent ();
		triggerStayEvent.AddListener (evt);
	}

	public void UnRegisterTriggerStay(UnityAction<Collider> evt)
	{
		if (triggerStayEvent == null)
			return;
		triggerStayEvent.RemoveListener (evt);
	}

	void OnTriggerStay(Collider collider)
	{
		if (triggerStayEvent != null)
			triggerStayEvent.Invoke (collider);
	}
	#endregion

	#region OnTriggerExit
	private TriggerExitEvent triggerExitEvent;

	public void RegisterTriggerExit(UnityAction<Collider> evt)
	{

		if (triggerExitEvent == null)
			triggerExitEvent = new TriggerExitEvent ();
		triggerExitEvent.AddListener (evt);
	}

	public void UnRegisterTriggerExit(UnityAction<Collider> evt)
	{
		if (triggerExitEvent == null)
			return;
		triggerExitEvent.RemoveListener (evt);
	}

	void OnTriggerExit(Collider collider)
	{
		if (triggerExitEvent != null)
			triggerExitEvent.Invoke (collider);
	}
	#endregion

	#region Example

	void Example()
	{
		PhysicsEventListener.Get (this.gameObject).RegisterCollisionEnter (ExampleDelegateFuction);
	}
	void ExampleDelegateFuction(Collision c){}

	#endregion
}
