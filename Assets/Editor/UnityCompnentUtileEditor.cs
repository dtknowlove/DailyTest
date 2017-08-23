using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UnityCompnentUtileEditor : Editor
{

	#region Transform
	[MenuItem("CONTEXT/Transform/ResetPos")]
	static void ResetTransformPos(MenuCommand command)
	{
		Transform trans = (Transform)command.context;
		trans.localPosition = Vector3.zero;
	}
	[MenuItem("CONTEXT/Transform/ResetRot")]
	static void ResetTransformRot(MenuCommand command)
	{
		Transform trans = (Transform)command.context;
		trans.localRotation = Quaternion.identity;
	}
	[MenuItem("CONTEXT/Transform/ResetScale")]
	static void ResetTransformScale(MenuCommand command)
	{
		Transform trans = (Transform)command.context;
		trans.localScale = Vector3.one;
	}
	#endregion
}
