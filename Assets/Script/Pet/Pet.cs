using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pet : MonoBehaviour {

	public bool playerPet;

	public PetHealth petInfo;

	//pet status
	public float petRunningSpeed;
	public float petAttackcycle;
	public int petLiking;
	public bool petStart;
	public bool petAlive;
	public GameObject goalObject;
	public GameObject startObject;

	//check pet chase another pet
	public bool onChase;

	//check Fall back per
	public bool isFallBack;


	//pet violence of peace
	public bool disposition;

	public Image violenceImage;
	public Image peaceImage;

	//pet Attack or hitDamege
	public GameObject petHitObject;
	public GameObject petHitEffect;
	public bool petIsAttack;
	public float chaseDistance;

	public bool isStun;
	public float stunningTime;

	//for chase
	public Pet[] enemyPets;
	public Pet chaseTarget;
	public int targetCount;



	public int randomPattern = 1;
	public float randomPatternCycle;

	// Use this for initialization

	public bool PetIsAttack
	{
		get{ return petIsAttack; }

	}

	public void PetAttackTrigger()
	{
		petIsAttack = false;
	}

	//property
	public bool IsStun
	{
		get { return isStun; }
	}

	public void AttackTrigger()
	{
		petIsAttack = false;

	}
	public virtual void PetFrogHitDamege(float _PetFrogDamege)
	{
		
	}

	public virtual void UserOrder(string data)
	{
		
	}

}
