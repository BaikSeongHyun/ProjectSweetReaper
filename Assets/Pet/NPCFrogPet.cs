using UnityEngine;
using System.Collections;

public class NPCFrogPet : Pet 
{

	public Animator NPCFrogPetAiAnimator;

	AnimatorStateInfo runStateNPCPetFrog;

	public enum NPCFrogPetPatternName
	{
		NPCFrogIdle = 1,
		NPCFrogRun,//2
		NPCFrogSlow,//3
		NPCFrogAttack,//4
		NPCFrogHitDamege,//5
		NPCFrogWin,//6
		NPCFrogLose//7
	};

	// Use this for initialization
	void Start () 
	{
		NPCFrogPetAiAnimator = GetComponent<Animator> ();
//		peaceImage.gameObject.SetActive (false);
//		violenceImage.gameObject.SetActive (false);
		NPCFrogPetPattern(NPCFrogPetPatternName.NPCFrogIdle);


	}
	
	// Update is called once per frame
	void Update () 
	{
		//NPCFrogPetRandomPatternCycle += Time.deltaTime;

		NPCFrogPetPattern (NPCFrogPetPatternName.NPCFrogRun);

		if (runStateNPCPetFrog.IsName ("NPCFrogRun"))
		{
			petRunningSpeed = 4.0f;
			//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z+ petRunningSpeed);
			transform.Translate(transform.forward * (Time.deltaTime* petRunningSpeed));	
		}

		runStateNPCPetFrog = this.NPCFrogPetAiAnimator.GetCurrentAnimatorStateInfo( 0 );


//		if (NPCFrogPetRandomPatternCycle <= 5)
//		{
//			NPCFrogPetRandomPattern = Random.Range (0,2);
//		
//
//			if (NPCFrogPetRandomPattern == 0)
//			{
//				NPCFrogPetPattern (NPCFrogPetPatternName.NPCFrogSlow);
//				petRunningSpeed = 0.0f;
//
//				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + petRunningSpeed);
//	
//			} 
//			else if (NPCFrogPetRandomPattern == 2)
//			{
//				Debug.Log ("Attack");
//			}
//
//			NPCFrogPetRandomPatternCycle = 0;
//
//		}
//

	
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
		}
	}

}
