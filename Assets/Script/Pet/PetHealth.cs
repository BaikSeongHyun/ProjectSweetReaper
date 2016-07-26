using UnityEngine;
using System.Collections;

public class PetHealth : MonoBehaviour
{

	public float petFear;
	public float maxFear;
	public float petBelligerence;
	public float moveSpeed;
	public float petStunTime;

	public float PetFear
	{
		get	{ return petFear; }
		set	{ petFear = value; }
	}

	public float MaxFear
	{
		get { return maxFear; }
		set { maxFear = value; }
	}

	public float PetBelligerence
	{
		get{ return petBelligerence; }
		set{ petBelligerence = value; }
	}

	public float MoveSpeed
	{
		get { return moveSpeed; }
		set { moveSpeed = value; }
	}

	public float PetStunTime
	{
		get { return petStunTime; }
		set { petStunTime = value; }
	}
}