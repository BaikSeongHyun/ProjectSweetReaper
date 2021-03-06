﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pet : MonoBehaviour
{

	public bool playerPet;

	public PetStatus petInfo;
	public int lane;

	//pet status
	public bool firstCycle;
	public bool onRace;
	public int grade;
	public int orderCounter;

	public Transform startPoint;
	public Transform goalPoint;

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
	public Pet attackTarget;
	public int targetCount;
	public float attackCycleTime;
	public GameObject stunThrowObject;

	public int randomPattern;
	public float randomPatternCycle;
	public float patternCycleTime;


	//property
	public bool OnRace
	{
		get{ return onRace; }	
	}

	public bool IsStun
	{
		get { return isStun; }
	}

	public bool PlayerPet
	{
		get { return playerPet; }
		set { playerPet = value; }
	}

	public int Grade
	{
		get { return grade; }
		set { grade = value; }
	}

	public int OrderCounter
	{
		get { return orderCounter; }	
	}

	//use minimap
	public float PresentPosition
	{
		get { return(1 - (goalPoint.position.z - transform.position.z) / (goalPoint.position.z - startPoint.position.z)); }
	}

	public void SetPetAttackTarget( Pet target )
	{
		attackTarget = target;
		onTarget = true;
	}

	public virtual void HitDamege( float _PetFrogDamege )
	{		
	}

	public virtual void UserOrder( string data )
	{		
	}

	public virtual void SetStatus( float myPetSpeed, float myPetAttack )
	{		
	}

	public void SetStartAndGoal( Transform start, Transform end )
	{
		startPoint = start;
		goalPoint = end;
	}

	public void SetLane( int data )
	{
		lane = data;	
	}
}
