using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pet : MonoBehaviour {

	public bool playerPet;

	//pet status
	public float petRunningSpeed;
	public float petAttackcycle;
	public int petFear;
	public int petBelligerence;
	public int petLiking;

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
	public bool isAttack;
	public float chaseDistance;

	//for chase
	public Pet[] enemyPets;
	public Pet chaseTarget;
	public int targetCount;

	public int NPCFrogPetRandomPattern = 1;
	public float NPCFrogPetRandomPatternCycle;

	// Use this for initialization

//	public bool PetIsAttack
//	{
//		get{ return petIsAttack; }
//
//	}
//
//	public void PetAttackTrigger()
//	{
//		petIsAttack = false;
//	}
//

	public void AttackTrigger()
	{
		isAttack = false;

	}
	public virtual void PetFrogHitDamege(float _PetFrogDamege)
	{
		
	}

	public virtual void UserOrder(string data)
	{
	}

}
