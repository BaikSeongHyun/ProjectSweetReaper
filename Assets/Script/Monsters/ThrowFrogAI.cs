using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThrowFrogAI : Monster 
{

	// Use this for initialization

	public Animator throwFrogAiAnimator;
	AnimatorStateInfo throwFrogState;

	public enum ThrowFrogPatternName
	{
		ThrowFrogIdle = 1,
		ThrowFrogWalk,
		ThrowFrogAttack,
		ThrowFrogTakeDamage,
		ThrowFrogDeath
				
	};

	void Start () 
	{
		frogInfo = GetComponent<MonsterHealth> ();
		throwFrogAiAnimator = GetComponent<Animator> ();	
		player = GameObject.FindGameObjectWithTag ("Player");
		ThrowFrogPattern (ThrowFrogPatternName.ThrowFrogIdle);

//		health = transform.Find ("").GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (isAlive)
		{
			float searchRange = Vector3.Distance( player.transform.position, transform.position );

			if (searchRange < attackRange) {
				if (attackCycle >= 2 && !throwFrogState.IsName ("TakeDamage")) {
					ThrowFrogPattern (ThrowFrogPatternName.ThrowFrogAttack);
					attackCycle = 0;
				} else {
					ThrowFrogPattern (ThrowFrogPatternName.ThrowFrogIdle);
					attackCycle += Time.deltaTime;
				}
			} else if (searchRange <= runRange) {
				ThrowFrogPattern (ThrowFrogPatternName.ThrowFrogWalk);
				if (throwFrogState.IsName ("Walk")) {
					transform.LookAt (player.transform.position);
					transform.position = Vector3.Lerp (transform.position, player.transform.position, Time.deltaTime * frogBossSpeed);

				}
			}

			if (searchRange > runRange) 

				ThrowFrogPattern (ThrowFrogPatternName.ThrowFrogIdle);
				throwFrogState = this.throwFrogAiAnimator.GetCurrentAnimatorStateInfo (0);

				transform.rotation = new Quaternion(0f, transform.rotation.y, 0f, 0f);
				transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
				transform.LookAt( player.transform.position );

				//update hp
				health.fillAmount = frogInfo.FillFrogHp;
				RotateHealthBar ();





			}
			


	}


	public void SetAttackTime()
	{
		attackCycle = 0;
	}

	


	public override void HitDamage( float _Damage )
	{
		//Instantiate( hitEffect, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation );
		//Instantiate( hitObject, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation );
		frogInfo.MonsterHp -= _Damage;
		if (isAlive)
		{
			frogInfo.monsterHp -= _Damage;


			if (frogInfo.MonsterHp > 0)
			{
				throwFrogAiAnimator.SetTrigger( "MonsterHitTrigger" );
				return;
			}

			if (frogInfo.MonsterHp <= 0)
			{
				health.fillAmount = 0;
				int randomItem = Random.Range( 0, 3 );

				if (randomItem == 0)
				{
					var item = Instantiate( dropItem, transform.position, new Quaternion(0, 0, 0, 0) );
					item.name = "DropItem";
				}
				else if (randomItem == 1)
				{
					var gold = Instantiate( dropGold, transform.position, new Quaternion(0, 0, 0, 0) );
					gold.name = "DropGold";
				}
				else
				{
					var item = Instantiate( dropItem, transform.position, new Quaternion(0, 0, 0, 0) );
					item.name = "DropItem";
					var gold = Instantiate( dropGold, transform.position, new Quaternion(0, 0, 0, 0) );					
					gold.name = "DropGold";
				}

				throwFrogAiAnimator.SetTrigger( "MonsterDie" );
				isAlive = false;
				Destroy( this.gameObject, 3.0f );
				return;
			}
		}
	}

	public void ThrowFrogPattern(ThrowFrogPatternName state)
	{
		switch (state) 
		{
			case ThrowFrogPatternName.ThrowFrogIdle:
				throwFrogAiAnimator.SetInteger ("state", 1);
				break;

			case ThrowFrogPatternName.ThrowFrogWalk:
				throwFrogAiAnimator.SetInteger ("state",2);
				break;

			case ThrowFrogPatternName.ThrowFrogAttack:
				throwFrogAiAnimator.SetInteger ("state",3);
				break;

			case ThrowFrogPatternName.ThrowFrogTakeDamage:
				throwFrogAiAnimator.SetInteger ("state",4);
				break;

			case ThrowFrogPatternName.ThrowFrogDeath:
				throwFrogAiAnimator.SetInteger ("state", 5);
				break;	
		}
		
	}




}
