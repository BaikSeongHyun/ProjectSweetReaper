using UnityEngine;
using System.Collections;

public class FrogHealth : MonoBehaviour
{
	public float frogHp = 100;
	public float frogDamage = 30;
	public float frogMaxHp = 100;

	public float FrogHp
	{
		get{ return frogHp; }
		set{ frogHp = value; }
	}

	public float FillFrogHp
	{
		get { return (frogHp / frogMaxHp); }
	}

	public float FrogDamage
	{
		get { return frogDamage; }
	}
}
