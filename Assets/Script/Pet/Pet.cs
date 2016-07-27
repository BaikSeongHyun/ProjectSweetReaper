using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pet : MonoBehaviour {

	public bool playerPet;

	public PetStatus petInfo;

	//pet status
	public bool firstCycle;
	public bool onRace;

	public GameObject goalObject;

	//pet violence of peace
	public bool disposition;

	public Image violenceImage;
	public Image peaceImage;

	//pet Attack or hitDamege
	public GameObject petHitObject;
	public GameObject petHitEffect;

	public bool isStun;
	public float stunningTime;

	//for attack
	public bool onTarget;
	public Pet[] enemyPets;
	public Pet attackTarget;
	public int targetCount;
	public float attackCycleTime;
	public GameObject stunThrowObject;

	public int randomPattern;
	public float randomPatternCycle;
	public float patternCycleTime;


	//property
	public bool IsStun
	{
		get { return isStun; }
	}

	public virtual void PetFrogHitDamege(float _PetFrogDamege)
	{
		
	}

	public virtual void UserOrder(string data)
	{
		
	}

}
