using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializeTest : MonoBehaviour
{
	private Hero mHeroIns;
	private Soldier mSoldierIns;
	private Hero mCommonPeopleIns;
	
	void Start () 
	{
		mHeroIns=new Hero(1,10000,90000,"Napoleon");
		mSoldierIns=new Soldier(2,90,900,"ItemOne");
		mCommonPeopleIns=new CommonPeople(3,30000,330000,"CommonNapoleon");
	}
	
	void OnGUI () 
	{
		if (GUILayout.Button("save(Serialize)", GUILayout.Width(200)))
		{
			
			FileStream fs=new FileStream("HeroAndSoldierData.lll",FileMode.Open);
			BinaryFormatter bf=new BinaryFormatter();
			Debug.Log(bf.Context.Context);
			Debug.Log(bf.Context.State);
			try
			{
				if (mHeroIns != null)
					bf.Serialize(fs, mHeroIns);
				if (mSoldierIns != null)
					bf.Serialize(fs, mSoldierIns);
				if (mCommonPeopleIns != null)
					bf.Serialize(fs, mCommonPeopleIns);
				Debug.Log("Serialize Success!");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			finally
			{
				fs.Close();
				mHeroIns = null;
				mSoldierIns = null;
				mCommonPeopleIns = null;
			}
		}
		if (GUILayout.Button("load(Deserialize)", GUILayout.Width(200)))
		{
			Debug.Log("=========Before==========");
			Debug.Log(mHeroIns);
			Debug.Log(mSoldierIns);
			FileStream fs=new FileStream("HeroAndSoldierData.lll",FileMode.Open);
			BinaryFormatter bf=new BinaryFormatter();
			try
			{
				mHeroIns = bf.Deserialize(fs) as Hero;
				mSoldierIns = bf.Deserialize(fs) as Soldier;
				mCommonPeopleIns = bf.Deserialize(fs) as CommonPeople;
				Debug.Log("Deserialize Success!");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			finally
			{
				fs.Close();
				Debug.Log("=========After==========");
				Debug.Log(mHeroIns.ToString());
				Debug.Log(mSoldierIns.ToString());
				Debug.Log(mCommonPeopleIns.ToString());
			}
		}
	}
}
