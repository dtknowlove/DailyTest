using System;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class Hero
{
    public int ID;
    public float Attack;
    public float Defence;
    public string Name;
    [NonSerialized]
    protected float powerRank;

    public Hero()
    {
        
    }

    public Hero(int id,float attack,float defence,string name)
    {
        this.ID = id;
        this.Attack = attack;
        this.Defence = defence;
        this.Name = name;
        this.powerRank = id + attack * 0.5f + defence * 0.7f;
        Debug.Log("Wrong:"+powerRank);
    }

    public override string ToString()
    {
        return string.Format("id:{0} attack:{1} defence:{2} name:{3} powerRank:{4}",this.ID,this.Attack,this.Defence,this.Name,this.powerRank);
    }
    
    [OnDeserialized]
    void CaculateRightPowerRank(StreamingContext context)
    {
        Debug.Log("Call DeSerialize Fuction!");
        this.powerRank = this.ID + this.Attack * 0.1f + this.Defence * 0.1f;
    }
}
[Serializable]
public class CommonPeople : Hero
{
    public CommonPeople()
    {
        
    }

    public CommonPeople(int id,float attack,float defence,string name):base(id,attack,defence,name)
    {
        
    }
}
