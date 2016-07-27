using UnityEngine;
using System.Collections;

public class PetHealth : MonoBehaviour
{
	public float attackCycle;
	public float moveSpeed;
	public float petStunTime;

	public float AttackCycle
	{
		get{ return attackCycle; }
		set{ attackCycle = value; }
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