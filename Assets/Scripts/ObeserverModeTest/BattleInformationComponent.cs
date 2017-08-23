using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 观察者
/// </summary>
public class BattleInformationComponent : MonoBehaviour
{

	private BaseUnit unit;
	
	void Start ()
	{
		unit = this.GetComponent<BaseUnit>();
		if (null == unit)
			unit = gameObject.AddComponent<BaseUnit>();
		unit.OnSubHp += OnSubHp;
		Debug.Log("lalalal ");
	}

	void OnDestroy()
	{
		
	}

	void OnSubHp(BaseUnit source,float harmNum,DamageType damageType,HPShowType hpShowType)
	{
		string unitName, damageTypeStr, hpShowTypeStr,damageHpStr;
		string missStr = "闪避";
		if (hpShowType == HPShowType.Miss)
		{
			Debug.Log(missStr);
			return;
		}
		unitName = "英雄";
		damageTypeStr = damageType == DamageType.Critical ? "暴击" : "普A";
		damageHpStr=harmNum.ToString();
		Debug.Log(unitName+damageTypeStr+damageHpStr);
	}

}
