using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMsgReceive : MonoBehaviour,IMsgReceiver {

	// Use this for initialization
	void Start () {
		this.RegisterSelf ("Want Msg",delegate(object[] param) {
			Debug.Log("接收到消息："+param[0]);
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
