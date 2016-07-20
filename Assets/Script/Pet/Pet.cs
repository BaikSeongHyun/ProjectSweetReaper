using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pet : MonoBehaviour {

	public bool playerPet;
	//pet status
	public float petRunningSpeed;
	public float petAttackcycle;

	public int petFear;
	public int petBelligerence;
	public int petLiking;

	//pet violence of peace
	public bool disposition;


	public Image violenceImage;
	public Image peaceImage;

	//pet Attack or hitDamege
	public GameObject petHitObject;
	public GameObject petHitEffect;
	public bool petIsAttack;

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
	public virtual void PetFrogHitDamege(float _PetFrogDamege)
	{
		
	}

	public virtual void UserOrder(string data)
	{
	}

}
