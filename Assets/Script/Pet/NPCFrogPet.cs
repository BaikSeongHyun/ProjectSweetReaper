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
		NPCFrogRun,//2
		NPCFrogSlow,//3
		NPCFrogAttack,//4
		NPCFrogHitDamege,//5
		NPCFrogWin,//6
		NPCFrogLose,//7
		NPCFrogCounterAttack//8


	};

	public enum PetState
	{
		Run =1,
		Attack=2,
		Slow=3,
		Idle=4
	};

	// Use this for initialization
	void Start () 
	{
		NPCFrogPetAiAnimator = GetComponent<Animator> ();
//		peaceImage.gameObject.SetActive (false);
//		violenceImage.gameObject.SetActive (false);
		NPCFrogPetPattern(NPCFrogPetPatternName.NPCFrogIdle);
		FindChaseTarget ();
		onChase = false;
		isFallBack = false;
		targetCount = 0;
		petInfo = GetComponent<PetHealth>();

	}

	
	// Update is called once per frame
	void Update () 
	{
		
		NPCFrogPetRandomPatternCycle += Time.deltaTime;

		if (NPCFrogPetRandomPatternCycle >= 5) 
		{
			NPCFrogPetRandomPattern = Random.Range (0, 2);

			NPCFrogPetRandomPatternCycle = 0;
			
		}

		if (NPCFrogPetRandomPattern == 0) 
		{
			presentState = PetState.Run;
		}


		else if (NPCFrogPetRandomPattern == 1) 
		{
			presentState = PetState.Attack;
		}

		else if (NPCFrogPetRandomPattern == 2) 
		{
			presentState = PetState.Slow;
		}


		else if (NPCFrogPetRandomPattern == 3) 
		{
			presentState = PetState.Idle;
		}


		switch (presentState) 
		{

		case PetState.Run:
			Run ();
			break;
		
		case PetState.Attack:
			Attack ();
			break;
		
		case PetState.Slow:
			Slow ();
			break;

		case PetState.Idle:
			Idle();
			break;
		}
	
	}


	public void Attack()
	{
		//set target
		if (!onChase)
			CheckChaseTarget ();

		//use distance and attack
		chaseDistance = Vector3.Distance(chaseTarget.transform.position ,transform.position);

		if (chaseDistance >= 5f) {
			NPCFrogPetPattern (NPCFrogPetPatternName.NPCFrogRun);
			transform.LookAt (chaseTarget.transform);

			transform.Translate (transform.forward * (Time.deltaTime * petRunningSpeed),Space.World);
		} else if (chaseDistance <= 5f && !chaseTarget.isFallBack) {
			NPCFrogPetPattern (NPCFrogPetPatternName.NPCFrogAttack);
		} else {
			onChase = false;
		}
	}

	public void FindChaseTarget()
	{
		GameObject[] temp = GameObject.FindGameObjectsWithTag ("Pet");

		enemyPets = new Pet[temp.Length];

		for (int i = 0; i < enemyPets.Length; i++)
			enemyPets [i] = temp [i].GetComponent<Pet>();
	}

	public void CheckChaseTarget ()
	{
		while (!onChase && !(enemyPets.Length == targetCount)) {
			if (enemyPets [targetCount] == null)
				targetCount++;
			else if (enemyPets [targetCount].isFallBack)
				targetCount++;
			else if (enemyPets [targetCount] == this)
				targetCount++;
			else {
				chaseTarget = enemyPets [targetCount];
				targetCount++;
				onChase = true;
			}
		}
	}


	public void Run()
	{
		NPCFrogPetPattern (NPCFrogPetPatternName.NPCFrogRun);

		if (runStateNPCPetFrog.IsName ("NPCFrogRun"))
		{
			petRunningSpeed = 4.0f;
			//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z+ petRunningSpeed);
			transform.Translate(transform.forward * (Time.deltaTime* petRunningSpeed));	
		}

		runStateNPCPetFrog = this.NPCFrogPetAiAnimator.GetCurrentAnimatorStateInfo( 0 );

		
	}

	public void Slow()
	{
		NPCFrogPetPattern (NPCFrogPetPatternName.NPCFrogSlow);

		if (runStateNPCPetFrog.IsName ("NPCFrogSlow"))
		{
			petRunningSpeed = 2.0f;
			//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z+ petRunningSpeed);
			transform.Translate(transform.forward * (Time.deltaTime* petRunningSpeed));	
		}
		runStateNPCPetFrog = this.NPCFrogPetAiAnimator.GetCurrentAnimatorStateInfo( 0 );

	}
		
	public void Idle()
	{
		NPCFrogPetPattern (NPCFrogPetPatternName.NPCFrogIdle);
		
	}





	public void FallBack()
	{
		transform.Translate (-transform.forward * (Time.deltaTime * petRunningSpeed)); 
	}


	public void NPCFrogPetPattern( NPCFrogPetPatternName NPCFrogState)
	{

		switch (NPCFrogState) 
		{
		case NPCFrogPetPatternName.NPCFrogIdle:
			NPCFrogPetAiAnimator.SetInteger ("NPCFrogState", 1);
			break;
		
		case NPCFrogPetPatternName.NPCFrogRun:
			NPCFrogPetAiAnimator.SetInteger ("NPCFrogState", 2);
			break;
		
		case NPCFrogPetPatternName.NPCFrogSlow:
			NPCFrogPetAiAnimator.SetInteger ("NPCFrogState", 3);
			break;
		
		case NPCFrogPetPatternName.NPCFrogAttack:
			NPCFrogPetAiAnimator.SetInteger ("NPCFrogState", 4);
			petIsAttack = true;
			break;
		case NPCFrogPetPatternName.NPCFrogHitDamege:
			NPCFrogPetAiAnimator.SetInteger ("NPCFrogState", 5);
			break;

		case NPCFrogPetPatternName.NPCFrogWin:
			NPCFrogPetAiAnimator.SetInteger ("NPCFrogState", 6);
			break;

		case NPCFrogPetPatternName.NPCFrogLose:
			NPCFrogPetAiAnimator.SetInteger ("NPCFrogState", 7);
			break;

		case NPCFrogPetPatternName.NPCFrogCounterAttack:
			NPCFrogPetAiAnimator.SetInteger ("NPCFrogState", 8);
			break;

		}
	}

	public override void UserOrder(string data)
	{
		if (data == "Run") 
		{
			//NPCFrogPetPattern (NPCFrogPetPatternName.NPCFrogRun);

		}
	}

	public override void PetFrogHitDamege(float PetDamage)
	{

//		Instantiate( petHitEffect, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation );
//		Instantiate( petHitObject, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation );
//				
		petInfo.PetHp -= PetDamage;

		Debug.Log (petInfo.PetHp);
		if (petInfo.PetHp<= 0) 
		{
			//if peaceful countattack 
	//		NPCFrogPetAiAnimator.SetTrigger ("PetCountTrigger");	

			//else

			//Fallback coding

		}
		if (petInfo.PetHp > 0) 
		{
			NPCFrogPetAiAnimator.SetTrigger ("PetHitTrigger");
			return;
			
		}

	}
}
