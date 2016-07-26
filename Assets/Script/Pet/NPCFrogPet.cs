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
		FindChaseTarget();
		onChase = false;
		isFallBack = false;
		isStun = false;
		stunningTime = 0.0f;
		targetCount = 0;
		petInfo = GetComponent<PetHealth>();
		randomPattern = 10;
		presentState = PetState.Idle;
		petStart = true;
		petAlive = true;
		goalObject = GameObject.FindGameObjectWithTag( "PetRaceGoal" );
		startObject = GameObject.FindGameObjectWithTag( "StartPosition" );
	}

	
	// Update is called once per frame
	void Update()
	{
		if (isStun)
		{
			stunningTime -= Time.deltaTime;
			if (stunningTime <= 0)
				isStun = false;
		}
		else if (petAlive)
		{
			if (petStart)
			{
				presentState = PetState.Run;
				petStart = false;
			}
			else
			{
				randomPatternCycle += Time.deltaTime;

				if (randomPatternCycle >= 10)
				{
					randomPattern = Random.Range( 0, 101 );

					if (( 0 <= randomPattern ) && ( randomPattern <= 61 ))
					{
						randomPattern = 1;					
					}
					else if (( 61 < randomPattern ) && ( randomPattern <= 71 ))
					{
						randomPattern = 2;
					}
					else if (( 71 < randomPattern ) && ( randomPattern <= 81 ))
					{
						randomPattern = 0;
					}
					else
					{
						randomPattern = 3;
					}

					randomPatternCycle = 0;			
				}

			
				petIsAttack = false;
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
						petIsAttack = true;
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
		else
		{
			FallBack();
		}
	
	}


	public void Attack()
	{
		//set target
		if (!onChase)
			CheckChaseTarget();

		//use distance and attack
		chaseDistance = Vector3.Distance( chaseTarget.transform.position, transform.position );

		if (chaseDistance <= 5f && chaseTarget.isStun)
		{
			onChase = false;
		}
		else if (chaseDistance >= 5f)
		{
			NPCFrogPetPattern( NPCFrogPetPatternName.NPCFrogRun );
			transform.LookAt( chaseTarget.transform );

			transform.Translate( transform.forward * ( Time.deltaTime * ( petRunningSpeed + 10 ) ), Space.World );
		}
		else if (chaseDistance <= 5f && !chaseTarget.isFallBack && !chaseTarget.isStun)
		{
			NPCFrogPetPattern( NPCFrogPetPatternName.NPCFrogAttack );
		}
		else
		{
			onChase = false;
		}
	}

	public void FindChaseTarget()
	{
		GameObject[] temp = GameObject.FindGameObjectsWithTag( "Pet" );

		enemyPets = new Pet[temp.Length];

		for (int i = 0; i < enemyPets.Length; i++)
			enemyPets[i] = temp[i].GetComponent<Pet>();
	}

	public void CheckChaseTarget()
	{
		

		if (enemyPets.Length == targetCount)
			targetCount = 0;
		
		while (!onChase && !( enemyPets.Length == targetCount ))
		{
			if (enemyPets[targetCount] == null)
				targetCount++;
			else if (enemyPets[targetCount].isFallBack)
				targetCount++;
			else if (enemyPets[targetCount].isStun)
				targetCount++;
			else if (enemyPets[targetCount] == this)
				targetCount++;
			else
			{
				chaseTarget = enemyPets[targetCount];
				targetCount++;
				onChase = true;
			}
		}
	}


	public void Run()
	{
		NPCFrogPetPattern( NPCFrogPetPatternName.NPCFrogRun );

		if (runStateNPCPetFrog.IsName( "NPCFrogRun" ))
		{
			petRunningSpeed = 4.0f;
			//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z+ petRunningSpeed);

			transform.LookAt( goalObject.transform );

			transform.Translate( transform.forward * ( Time.deltaTime * petRunningSpeed ) );	
		}

		runStateNPCPetFrog = this.NPCFrogPetAiAnimator.GetCurrentAnimatorStateInfo( 0 );

		
	}

	public void Slow()
	{
		NPCFrogPetPattern( NPCFrogPetPatternName.NPCFrogSlow );

		if (runStateNPCPetFrog.IsName( "NPCFrogSlow" ))
		{
			petRunningSpeed = 2.0f;
			transform.LookAt( goalObject.transform );
			//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z+ petRunningSpeed);
			transform.Translate( transform.forward * ( Time.deltaTime * petRunningSpeed ) );	
		}
		runStateNPCPetFrog = this.NPCFrogPetAiAnimator.GetCurrentAnimatorStateInfo( 0 );

	}

	public void Idle()
	{
		NPCFrogPetPattern( NPCFrogPetPatternName.NPCFrogIdle );
		
	}





	public void FallBack()
	{
		transform.LookAt( startObject.transform );

		transform.Translate( transform.forward * ( Time.deltaTime * petRunningSpeed ) ); 
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
				petIsAttack = true;
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

			case NPCFrogPetPatternName.NPCFrogCounterAttack:
				NPCFrogPetAiAnimator.SetInteger( "NPCFrogState", 8 );
				break;

		}
	}

	public override void UserOrder( string data )
	{
		if (data == "Run")
		{
			//NPCFrogPetPattern (NPCFrogPetPatternName.NPCFrogRun);

		}
	}

	public override void PetFrogHitDamege( float _stunningTime )
	{
		
//		Instantiate( petHitEffect, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation );
//		Instantiate( petHitObject, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation );
				
		stunningTime = _stunningTime;
		isStun = true;
		petInfo.PetFear++;
		petInfo.PetBelligerence++;

		if (( petInfo.PetFear <= petInfo.PetBelligerence ))
		{
			isStun = false;
			NPCFrogPetAiAnimator.SetTrigger( "PetCountTrigger" );
			petInfo.PetBelligerence = 0;
		}
		else if (petInfo.PetFear > petInfo.MaxFear)
		{
			isFallBack = true;
			petAlive = false;
		}
		else if (isStun)
		{
			NPCFrogPetAiAnimator.SetTrigger( "PetHitTrigger" );
			return;			
		}	
	}
}
