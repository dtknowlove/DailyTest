using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[CustomEditor(typeof(EButton))]
public class EButtonEitor : Editor
{
	private EButton eButton;
	private float f = 0;
	private Transition curTransition;
	private bool isHide = false;
	
	void OnEnable()
	{
		eButton=target as EButton;
		eButton.ColorTint=new ButtonColorTint();
	}

	public override void OnInspectorGUI()
	{
		eButton.Interactable = EditorGUILayout.Toggle("Interactable", eButton.Interactable);
		eButton.Transition =(Transition) EditorGUILayout.EnumPopup("Transition", eButton.Transition);
	
		f = EditorGUILayout.Slider("silder", f,0,1);


//		if (curTransition != eButton.Transition)
//		{
//			curTransition = eButton.Transition;
//			isHide = true;
//			f = 0;
//		}
//
//		if (isHide)
//		{
//			Debug.Log(DateTime.Now.Millisecond);
//			f += DateTime.Now.Millisecond/1000.0f;
//			f = Mathf.Clamp01(f);
//		}
		
		EditorGUI.indentLevel += 1;
		switch (eButton.Transition)
		{
			case Transition.ColorTint:
				if (EditorGUILayout.BeginFadeGroup(f))
				{
					eButton.ColorTint.TargetGraphic =
						(Button) EditorGUILayout.ObjectField("Target Graphic", eButton.ColorTint.TargetGraphic, typeof(Button), true);

					eButton.ColorTint.NormalColor = EditorGUILayout.ColorField("Normal Color", eButton.ColorTint.NormalColor);
					eButton.ColorTint.HighlightedColor =
						EditorGUILayout.ColorField("Highlighted Color", eButton.ColorTint.HighlightedColor);
					eButton.ColorTint.PressedColor = EditorGUILayout.ColorField("Pressed Color", eButton.ColorTint.PressedColor);
					eButton.ColorTint.DisabledColor = EditorGUILayout.ColorField("Disabled Color", eButton.ColorTint.DisabledColor);
				}
				EditorGUILayout.EndFadeGroup();
				break;
		}
		EditorGUI.indentLevel -= 1;
		EditorGUILayout.LabelField("Navigation");
	}
}
