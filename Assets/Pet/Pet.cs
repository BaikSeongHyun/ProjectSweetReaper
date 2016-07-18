using UnityEngine;
using System.Collections;

public class Pet : MonoBehaviour {

	public float petRunningSpeed;
	public float petAttackcycle;
	public int petLiking;
	public int disposition;
	public int petFear;

	public GameObject petHitObject;
	public GameObject petHitEffect;
	public bool petIsAttack;

	// Use this for initialization

	public bool PetIsAttack
	{
		get{ return petIsAttack; }

	}

	public void PetAttackTrigger()
	{
		petIsAttack = false;
	}



}
