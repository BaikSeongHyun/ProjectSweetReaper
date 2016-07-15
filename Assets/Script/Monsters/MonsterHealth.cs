using UnityEngine;
using System.Collections;

public class MonsterHealth : MonoBehaviour
{
	public float monsterHp = 100;
	public float monsterDamage = 30;
	public float monsterMaxHp = 100;

	public float MonsterHp
	{
		get{ return monsterHp; }
		set{ monsterHp = value; }
	}

	public float FillFrogHp
	{
		get { return (monsterHp / monsterMaxHp); }
	}

	public float MonsterDamage
	{
		get { return monsterDamage; }
	}
}
