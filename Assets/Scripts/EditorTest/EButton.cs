using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Transition
{
	None,
	ColorTint,
	SpriteSwap,
	Animation
}

public class EButton : MonoBehaviour
{
	public bool Interactable = true;
	public Transition Transition=Transition.ColorTint;
	public ButtonColorTint ColorTint;

	void Start()
	{
		Debug.Log(Interactable);
	}
}

public class ButtonColorTint
{
	public Button TargetGraphic;
	public Color NormalColor;
	public Color HighlightedColor=Color.white;
	public Color PressedColor=Color.white;
	public Color DisabledColor=Color.white;

	public ButtonColorTint()
	{
		NormalColor=Color.white;
		ColorUtility.TryParseHtmlString("#F5F5F5FF", out HighlightedColor);
		ColorUtility.TryParseHtmlString("#C8C8C8FF", out PressedColor);
		ColorUtility.TryParseHtmlString("#C8C8C880", out DisabledColor);
	}
}
