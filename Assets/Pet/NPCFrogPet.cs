using UnityEngine;
using System.Collections;

public class NPCFrogPet : Pet 
{

	public Animator NPCFrogPetAiAnimator;




	public enum NPCFrogPetPatternName
	{
		NPCFrogIdle = 1,
		NPCFrogRun,
		NPCFrogSlow,
		NPCFrogAttack,
		NPCFrogHitDamege,
		NPCFrogWin,
		NPCFrogLose
	};

	// Use this for initialization
	void Start () 
	{
		NPCFrogPetAiAnimator = GetComponent<Animator> ();


	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (0, 0, 0);
		
	
	}
}
