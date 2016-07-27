using UnityEngine;
using System.Collections;

public class NPCFrogPet : Pet
{

	public Animator NPCFrogPetAiAnimator;
	AnimatorStateInfo runStateNPCPetFrog;
	public PetState presentState;

	public enum NPCFrogPetPatternName
	{
		NPCFrogIdle = 1,
		NPCFrogRun,
		NPCFrogSlow,
		NPCFrogAttack,
		NPCFrogHitDamege,
		NPCFrogWin,
		NPCFrogLose,
		NPCFrogCounterAttack}
;

	public enum PetState
	{
		Run = 1,
		Attack = 2,
		Slow = 3,
		Idle = 4,
		Stun = 5}
;

	// Use this for initialization
	void Start()
	{
		NPCFrogPetAiAnimator = GetComponent<Animator>();
		NPCFrogPetPattern( NPCFrogPetPatternName.NPCFrogIdle );
		petInfo = GetComponent<PetHealth>();
		FindChaseTarget();
		firstCycle = true;
		onTarget = false;
		isStun = false;
		stunningTime = 0.0f;
		targetCount = 0;
		randomPattern = 10;
		presentState = PetState.Idle;
		onRace = true;
		patternCycleTime = 5f;
	}

	
	// Update is called once per frame
	void Update()
	{
		if (onRace)
		{
			randomPatternCycle += Time.deltaTime;

			if (randomPatternCycle >= patternCycleTime)
			{
				randomPattern = Random.Range( 0, 4 );
				randomPatternCycle = 0.0f;
			}
			else if (isStun)
			{
				stunningTime -= Time.deltaTime;
				if (stunningTime <= 0)
					isStun = false;
			}
			else
			{
				if (firstCycle)
				{
					presentState = PetState.Run;
					firstCycle = false;
				}
				else
				{
					//set pattern
					switch (randomPattern)
					{
						case 0:
							presentState = PetState.Idle;
							break;
						case 1:
							presentState = PetState.Run;
							break;
						case 2:
							presentState = PetState.Slow;
							break;
						case 3:						
							presentState = PetState.Attack;
							break;
					}

					// active pattern
					switch (presentState)
					{
						case PetState.Run:
							Run();
							break;		
						case PetState.Attack:
							Attack();
							break;		
						case PetState.Slow:
							Slow();
							break;
						case PetState.Idle:
							Idle();
							break;
					}
				}
			}
		}
	}

	public void FindChaseTarget()
	{
		GameObject[] temp = GameObject.FindGameObjectsWithTag( "Pet" );

		enemyPets = new Pet[temp.Length];

		for (int i = 0; i < enemyPets.Length; i++)
			enemyPets[i] = temp[i].GetComponent<Pet>();
	}

	void InitializeRaceData()
	{
		attackTarget = null;
		attackCycleTime = 0.0f;
	}

	public void Run()
	{
		NPCFrogPetPattern( NPCFrogPetPatternName.NPCFrogRun );

		if (runStateNPCPetFrog.IsName( "NPCFrogRun" ))
		{
			transform.LookAt( goalObject.transform );
			transform.Translate( transform.forward * ( Time.deltaTime * petInfo.MoveSpeed ) );	
		}
		runStateNPCPetFrog = this.NPCFrogPetAiAnimator.GetCurrentAnimatorStateInfo( 0 );
	}

	//find next target
	public void CheckChaseTarget()
	{
		if (enemyPets.Length == targetCount)
			targetCount = 0;

		while (!onTarget && !( enemyPets.Length == targetCount ))
		{
			if (enemyPets[targetCount] == null)
				targetCount++;
			else if (enemyPets[targetCount].isStun)
				targetCount++;
			else if (enemyPets[targetCount] == this)
				targetCount++;
			else
			{
				attackTarget = enemyPets[targetCount];
				targetCount++;
				onTarget = true;
			}
		}
	}

	//method - attack
	public void Attack()
	{
		attackCycleTime += Time.deltaTime;
		//set target
		if (!onTarget)
			CheckChaseTarget();

		//make throw object
		if (attackCycleTime >= petInfo.AttackCycle)
		{
			GameObject temp = (GameObject) Instantiate( stunThrowObject, transform.position, transform.rotation );
			temp.GetComponent<StunThrowObject>().SetTarget( attackTarget.transform.position, petInfo.PetStunTime );
			NPCFrogPetPattern( NPCFrogPetPatternName.NPCFrogAttack );
			attackCycleTime = 0.0f;
		}
	}

	public void Slow()
	{
		NPCFrogPetPattern( NPCFrogPetPatternName.NPCFrogSlow );

		if (runStateNPCPetFrog.IsName( "NPCFrogSlow" ))
		{
			transform.LookAt( goalObject.transform );
			transform.Translate( transform.forward * ( Time.deltaTime * petRunningSpeed / 2 ) );	
		}
		runStateNPCPetFrog = this.NPCFrogPetAiAnimator.GetCurrentAnimatorStateInfo( 0 );

	}

	public void Idle()
	{
		NPCFrogPetPattern( NPCFrogPetPatternName.NPCFrogIdle );		
	}

	public void NPCFrogPetPattern( NPCFrogPetPatternName NPCFrogState )
	{
		switch (NPCFrogState)
		{
			case NPCFrogPetPatternName.NPCFrogIdle:
				NPCFrogPetAiAnimator.SetInteger( "NPCFrogState", 1 );
				break;		
			case NPCFrogPetPatternName.NPCFrogRun:
				NPCFrogPetAiAnimator.SetInteger( "NPCFrogState", 2 );
				break;		
			case NPCFrogPetPatternName.NPCFrogSlow:
				NPCFrogPetAiAnimator.SetInteger( "NPCFrogState", 3 );
				break;		
			case NPCFrogPetPatternName.NPCFrogAttack:
				NPCFrogPetAiAnimator.SetInteger( "NPCFrogState", 4 );
				break;
			case NPCFrogPetPatternName.NPCFrogHitDamege:
				NPCFrogPetAiAnimator.SetInteger( "NPCFrogState", 5 );
				break;
			case NPCFrogPetPatternName.NPCFrogWin:
				NPCFrogPetAiAnimator.SetInteger( "NPCFrogState", 6 );
				break;
			case NPCFrogPetPatternName.NPCFrogLose:
				NPCFrogPetAiAnimator.SetInteger( "NPCFrogState", 7 );
				break;			
		}
	}

	public override void UserOrder( string data )
	{
		if (data == "Attack")
		{

		}
	}

	public override void PetFrogHitDamege( float _stunningTime )
	{
		
//		Instantiate( petHitEffect, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation );
//		Instantiate( petHitObject, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation );
				
		stunningTime = _stunningTime;
		isStun = true;
		NPCFrogPetAiAnimator.SetTrigger( "PetHitTrigger" );
	}
}
