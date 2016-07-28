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
		petInfo = GetComponent<PetStatus>();
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
			if(Vector3.Distance(transform.position, goalPoint.position) <= 0.5f)
			{
				onRace = false;	
			}
			if (randomPatternCycle >= patternCycleTime)
			{
				randomPattern = Random.Range( 1, 4 );
				randomPatternCycle = 0.0f;

				//set pattern
				switch (randomPattern)
				{						
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
			}
			else if (isStun)
			{
				stunningTime -= Time.deltaTime;
				if (stunningTime <= 0)
				{
					isStun = false;
					NPCFrogPetAiAnimator.SetBool( "Stun", false );
					stunningTime = 0.0f;
				}
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
					}
				}
			}
		}
	}

	public void Run()
	{
		NPCFrogPetPattern( NPCFrogPetPatternName.NPCFrogRun );
		transform.LookAt( goalPoint.transform );
		transform.Translate( transform.forward * ( Time.deltaTime * petInfo.MoveSpeed ) );	
	}

	//method - attack
	public void Attack()
	{
		//make throw object
		if(onTarget)
		{			
			NPCFrogPetPattern( NPCFrogPetPatternName.NPCFrogAttack );
			GameObject temp = (GameObject) Instantiate( stunThrowObject, transform.position + new Vector3 ( 0f, 10f, 0f ), transform.rotation );
			temp.GetComponent<StunThrowObject>().SetTarget( attackTarget.transform, petInfo.PetStunTime );
			presentState = PetState.Run;
		}
	}

	public void Slow()
	{
		NPCFrogPetPattern( NPCFrogPetPatternName.NPCFrogSlow );
		transform.LookAt( goalPoint.transform );
		transform.Translate( transform.forward * ( Time.deltaTime * petInfo.MoveSpeed / 4 ) );	
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
				NPCFrogPetAiAnimator.SetTrigger( "PetAttack" );
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
		Debug.Log( data );
		if (data == "Attack")
			presentState = PetState.Attack;
		
		else if(data == "Run")
			presentState = PetState.Run;
	}

	public override void HitDamege( float _stunningTime )
	{
		stunningTime = _stunningTime;
		isStun = true;
		NPCFrogPetAiAnimator.Play( "NPCFrogHitDamage", -1, 0f );
		NPCFrogPetAiAnimator.SetBool( "Stun", true );
	}
}
