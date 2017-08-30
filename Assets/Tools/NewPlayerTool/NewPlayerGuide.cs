using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 新手引导动画
/// </summary>
[AddComponentMenu("UI/New Player Mask", 1)]
[RequireComponent(typeof(Image))]
public class NewPlayerGuide : MonoBehaviour {
 
 	[HideInInspector][SerializeField]
	public RectTransform target;
	[HideInInspector][SerializeField]
	public float RadusSlider =100f;
	[HideInInspector][SerializeField]
	public Material material;
 
	void Start () 
	{
 		Debug.Log(RadusSlider);
	}
}