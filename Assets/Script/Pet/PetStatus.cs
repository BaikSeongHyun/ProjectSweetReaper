using UnityEngine;
using System.Collections;

[System.Serializable]
public class PetStatus
{
	public float moveSpeed;
	public float petStunTime;
	
	//no parameter - default
	public PetStatus()
	{
		moveSpeed = Random.Range(8.0f, 12.0f);	
		petStunTime = Random.Range(2f, 4f);
	}
	
	public PetStatus(float myPetSpeed, float myPetAttack)
	{
		moveSpeed = myPetSpeed;
		petStunTime = myPetAttack;
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