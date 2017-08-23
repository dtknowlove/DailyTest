using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPhysics : MonoBehaviour 
{

	void Start ()
	{
		GameObject collision = GameObject.Find ("Collision");
		GameObject trigger = GameObject.Find ("Trigger");
		PhysicsEventListener.Get(collision).RegisterCollisionEnter(delegate(Collision arg0) {
			Debug.Log ("[CollisionEnter===>]"+arg0.collider.name);
		});
		PhysicsEventListener.Get(collision).RegisterCollisionStay(delegate(Collision arg0) {
			Debug.Log ("[CollisionStay===>]"+arg0.collider.name);
		});
		PhysicsEventListener.Get(collision).RegisterCollisionExit(delegate(Collision arg0) {
			Debug.Log ("[CollisionExit===>]"+arg0.collider.name);
		});
		PhysicsEventListener.Get (trigger).RegisterTriggerEnter (delegate(Collider arg0) {
			Debug.Log ("[TriggerEnter===>]"+arg0.name);
		});
		PhysicsEventListener.Get (trigger).RegisterTriggerStay (delegate(Collider arg0) {
			Debug.Log ("[TriggerStay===>]"+arg0.name);
		});
		PhysicsEventListener.Get (trigger).RegisterTriggerExit (delegate(Collider arg0) {
			Debug.Log ("[TriggerExit===>]"+arg0.name);
		});

		Destroy (collision, 10);
		Destroy (trigger, 10);
	}
}
