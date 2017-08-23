using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMsgSend : MonoBehaviour,IMsgSender {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			this.SenderMsg ("Want Msg","I am a "+this.name+". My position is "+transform.position.ToString());
	}
}
