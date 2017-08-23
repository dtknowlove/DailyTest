using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
	public int curHP;

	public Person (int hp)
	{
		curHP = hp;
	}

	public void TakeDamage(int damage)
	{
		curHP -= damage;
	}
}
