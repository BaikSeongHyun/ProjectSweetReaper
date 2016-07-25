using UnityEngine;
using System.Collections;

public class PetHealth : MonoBehaviour
{

	public float petHp;
	public float petDamage;

	public float PetHp
	{
		get	{ return  petHp; }
		set	{ petHp = value; }
	}

	public float PetDamage
	{
		get{ return petDamage; }
	}
}