using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingEffectTest : MonoBehaviour
{
	[SerializeField]
	private float m_Interval;
	[SerializeField]
	private string m_ShowWord;

	private string[] m_Words;
	private Text m_ShowCom;
	private float m_Timer;
	private int divisivle;
	private int m_Length;
	
	void Start ()
	{
		m_ShowCom = this.GetComponent<Text>();
		m_Timer = Time.realtimeSinceStartup;
		if (!string.IsNullOrEmpty(m_ShowWord))
		{
			m_Words=new string[]{m_ShowWord+".",m_ShowWord+"..",m_ShowWord+"..."};
			m_Length = m_Words.Length;
		}
	}
	
	void Update ()
	{
		if(string.IsNullOrEmpty(m_ShowWord))return;
		m_Timer += Time.deltaTime;
		divisivle = (int)( m_Timer / m_Interval);
		m_ShowCom.text = m_Words[divisivle % m_Length];
	}
}
