using System;
using System.Collections;
using System.Collections.Generic;
using ProtoBuf;
using UnityEngine;

public class JsonUtilityTest : MonoBehaviour {

	void Start ()
	{
//		string json="{\"name\":\"Napleon\",\"age\":18,\"attack\":1239.34}";
//		PlayerInfo p= new PlayerInfo();
//		p.name = "Napleon";
//		p.age = 18;
//		p.attack = 1233.34f;
//		Debug.Log(SerializeHelper.ToJson<PlayerInfo>(p));
//		SerializeHelper.SaveJson<PlayerInfo>(p,"TestJson.json");
//		p=SerializeHelper.LoadJson<PlayerInfo>("TestJson.json");
//		p.age = 22;
//		Debug.Log(p.name+" "+p.age+" "+p.attack);
		
		PeopleInfo pi=new PeopleInfo()
		{
			Name = "Neack",
			Age = 29,
			SaveTime =DateTime.Now,
			Address =new Address()
			{
				Line1 = "Shanghai Pudong",
				Line2 = "Jiangsu Nanjing"
			}
		};
		
//		using (var file=System.IO.File.Create("TestProtoBuf.bin"))
//		{	
//			Serializer.Serialize(file,pi);
//		}
//		PeopleInfo pp=new PeopleInfo();
//		using (var file=System.IO.File.OpenRead("TestProtoBuf.bin"))
//		{	
//			pp=Serializer.Deserialize<PeopleInfo>(file);
//		}
//		Debug.Log(pp.ToString());
//		PeopleInfo pp=SerializeHelper.LoadProtoBuf<PeopleInfo>("TestPortoBuf.bin");
//		Debug.Log(pp.ToString());
//		pp.Age = 30;
		SerializeHelper.SaveProtoBuf<PeopleInfo>(pi,"TestPortoBuf.protobuf");
		PeopleInfo pp=SerializeHelper.LoadProtoBuf<PeopleInfo>("TestPortoBuf.protobuf");
		Debug.Log(pp.ToString());
	}
	
	void Update () 
	{
		
	}
}

[Serializable]
public class PlayerInfo
{
	public string name;
	public int age;
	public float attack;

	public static PlayerInfo LoadFromJson(string json)
	{
		return JsonUtility.FromJson<PlayerInfo>(json);
	}
}

[ProtoContract]
public class PeopleInfo
{
	[ProtoMember(1)]
	public string Name { get; set; }
	[ProtoMember(2)]
	public int Age { get; set; }
	[ProtoMember(3)]
	public DateTime SaveTime { get; set; }
	[ProtoMember(4)]
	public Address Address { get; set; }

	public override string ToString()
	{
		return string.Format("Name:{0} Age:{1} SaveTime:{2} Address:{3}", Name, Age, SaveTime, Address);
	}
}
[ProtoContract]
public class Address
{
	[ProtoMember(1)]
	public string Line1 { get; set; }
	[ProtoMember(2)]
	public string Line2 { get; set; }
	
	public override string ToString()
	{
		return string.Format("Line1:{0} Line2:{1}", Line1,Line2);
	}
}