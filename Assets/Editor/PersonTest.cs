using UnityEngine;
using NUnit.Framework;

public class PersonTest 
{
	[Test]
	public void PersonTest_Hp() {
		//Arrange
		Person p=new Person(100);
			
		//Act
		//Try to rename the GameObject
		p.TakeDamage(20);

		//Assert
		//The object has a new name
		Assert.AreEqual(80,p.curHP);
	}
}
