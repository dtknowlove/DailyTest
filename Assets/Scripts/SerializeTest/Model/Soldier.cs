using System;

[Serializable]
public class Soldier 
{
    public int ID;
    public float Attack;
    public float Defence;
    public string Name;
    
    public Soldier()
    {
        
    }

    public Soldier(int id,float attack,float defence,string name)
    {
        this.ID = id;
        this.Attack = attack;
        this.Defence = defence;
        this.Name = name;
    }
    public override string ToString()
    {
        return string.Format("id:{0} attack:{1} defence:{2} name:{3}",this.ID,this.Attack,this.Defence,this.Name);
    }
}
