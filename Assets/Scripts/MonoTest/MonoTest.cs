using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random=UnityEngine.Random;

public class MonoTest : MonoBehaviour 
{
	
	ArrayList al=new ArrayList();
	void Start()
	{
		Debug.Log("Start 1");
		People a=new People(113);
		People b=new People(24);
		People c=new People(67);
//		Debug.Log((a+b).age);
//		Vector3 v=new Vector3(1,2,3);
//		Debug.Log(v[0]);
//		Debug.Log(this.ToString());
//
//
//		int aa = 2;
//		int bb = 3;
//
//		al.Add(aa);
//		al.Add(bb);
//
//		int c = (int)al[0];
//		c = 98;
//		aa = 99;
//		
//		Debug.Log(aa);
//		Debug.Log((int)(al[0]));
//		Debug.Log(c);

//		List<People> ps=new List<People>(){a,b,c};
//		ps.Sort();
//		foreach (People people in ps)
//		{
//			Debug.Log(people.age);			
//		}
//		Debug.Log(a.CompareTo(b));
//		Debug.Log(a.Equals(b));
		
//		MyDelegate d1=new MyDelegate(PrintNum);
//		MyDelegate d2=new MyDelegate(PrintDoubleNum);
//		MyDelegate d3=new MyDelegate(PrintTripleNum);
//
//		MyDelegate myDelegates = null;
//		myDelegates =(MyDelegate)Delegate.Combine(myDelegates, d1);
//		myDelegates =(MyDelegate)Delegate.Combine(myDelegates, d2);
//		myDelegates =(MyDelegate)Delegate.Combine(myDelegates, d3);
//		
//		this.Print(20,myDelegates);
//
//		myDelegates = (MyDelegate) Delegate.Remove(myDelegates, d2);
//		this.Print(200,myDelegates);

		Action<int> anoymousMethod= delegate(int i)
		{
			Debug.Log(testNum);
		};

		anoymousMethod(0);
		testNum = 70;
				
		anoymousMethod(0);
		Console.WriteLine("12121211111");

	}

	private int testNum = 100;

	void Update()
	{
//		Debug.Log("[执行ing...]");
	}

	void OnDrawGizmos()
	{
		Gizmos.color = mGizmosColor;
		Gizmos.DrawCube(transform.position,new Vector3(1,1,1));
	}

	void OnBecameVisible()
	{
		enabled = true;
		Debug.Log(111);
	}

	void OnBecameInvisible()
	{
		enabled = false;
		Debug.Log(222);
	}

	void OnGUI()
	{
//		if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
//			print("You clicked the button!");
		if (GUILayout.RepeatButton("Increase max\nSlider Value"))
			maxSilderValue += 3.0f * Time.deltaTime;
		GUILayout.Box("Silder value: "+Mathf.Round(sliderValue));
		sliderValue = GUILayout.HorizontalSlider(sliderValue, 0.0f, maxSilderValue);
	}

	void OnEnable()
	{
		Debug.Log("Enable 2");
	}

	void OnDisable()
	{
		Debug.Log("Disable 3");		
	}

	void OnMouseDown()
	{
		Debug.Log("Click it!");
		mGizmosColor=new Color(Random.Range(0,1.0f),Random.Range(0,1.0f),Random.Range(0,1.0f),Random.Range(0,1.0f));
	}

	public override string ToString()
	{
		return "Cnameinafmoa";
	}

	private static System.Object CreateInstance(Type type)
	{
		System.Object obj = null;
		try
		{
			obj = Activator.CreateInstance(type);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
		return obj;
	}
	
	private void Print(int value, MyDelegate md)
	{
		if(md!=null)
			md.Invoke(value);
		else
			Debug.Log("MyDelegate is null");
	}

	private void PrintNum(int value)
	{
		Debug.Log("1 result num:"+value);
	}
	
	private void PrintDoubleNum(int value)
	{
		Debug.Log("2 result num:"+value*2);
	}
	
	private void PrintTripleNum(int value)
	{
		Debug.Log("3 result num:"+value*3);
	}

	private float sliderValue = 1f;
	private float maxSilderValue = 10f;
	private Color mGizmosColor=Color.blue;
	private delegate void MyDelegate(int num);
}

public class People:IComparable<People>
{
	public int age;

	public People(int _age)
	{
		this.age = _age;
	}

	public static People operator +(People a, People b)
	{
		return  new People(a.age+b.age);
	}
	
	public int CompareTo(People other)
	{
		return age - other.age;
	}
}
