using UnityEngine;
using System.Collections;

public class PetStatus : MonoBehaviour
{
	public float moveSpeed;
	public float petStunTime;

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