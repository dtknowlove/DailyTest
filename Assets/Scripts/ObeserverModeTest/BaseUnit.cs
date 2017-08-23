using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
	Normal,	//普A
	Critical //暴击
}

public enum HPShowType
{
	None,
	Damage,
	Miss
}
/// <summary>
/// 主体
/// </summary>
public class BaseUnit:MonoBehaviour
{
	public delegate void SubHpHander(BaseUnit source, float subHp, DamageType damageType, HPShowType hpShowType);
	public event SubHpHander OnSubHp;

	public void BeAttacked()
	{
		bool isCritical = UnityEngine.Random.value > 0.5f;
		bool isMiss = UnityEngine.Random.value > 0.5f;
		float harmNum = UnityEngine.Random.value*1000;
		if (isCritical)
			harmNum = 2000f;
		OnBeAttacked(harmNum,isCritical,isMiss);
	}

	protected void OnBeAttacked(float harmNum, bool isCritical, bool isMiss)
	{
		DamageType damageType= DamageType.Normal;
		HPShowType hpShowType= HPShowType.Damage;
		if(isCritical)
			damageType=DamageType.Critical;
		if(isMiss)
			hpShowType= HPShowType.Miss;
		if (OnSubHp != null)
			OnSubHp(this,harmNum,damageType,hpShowType);
	}
}
