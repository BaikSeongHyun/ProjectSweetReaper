using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThrowFrogAI : Monster 
{

	// Use this for initialization

	public Animator throwFrogAiAnimator;
	AnimatorStateInfo throwFrogState;
	public GameObject throwObject;

	public Vector3 targetPos;

	public bool throwTrigger;

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
		health = transform.Find ("ThrowFrogHpBar").GetComponent<Image> ();
		throwTrigger = false;
//		health = transform.Find ("").GetComponent<Image> ();
	}

	public void ThrowTrigger()
	{
		throwTrigger = true;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (isAlive)
		{
			float searchRange = Vector3.Distance( player.transform.position, transform.position );

			if (searchRange < attackRange)
			{
				if (attackCycle >= 5 && !throwFrogState.IsName ("ThrowFrogTakeDamage")) 
				{

					ThrowFrogPattern (ThrowFrogPatternName.ThrowFrogAttack);


					if (throwTrigger) 
					{
						
						GameObject throwTemp = (GameObject)Instantiate (throwObject, transform.position + new Vector3 (1.3f, 0f, 0f), transform.rotation);
						targetPos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);

						Destroy (throwTemp, 4.0f);

						throwTemp.GetComponent<ThrowFrogObject> ().IsAttackCheck (targetPos);

						attackCycle = 0;

						ThrowFrogPattern (ThrowFrogPatternName.ThrowFrogIdle);



					}
				} 
				else 
				{
					throwTrigger = false;					

					ThrowFrogPattern (ThrowFrogPatternName.ThrowFrogIdle);
					attackCycle += Time.deltaTime;
					Debug.Log ("in");
				}

			}
			else if (searchRange <= runRange || searchRange<= attackRange)
			{

				ThrowFrogPattern (ThrowFrogPatternName.ThrowFrogWalk);
				if (throwFrogState.IsName ("ThrowFrogWalk"))
				{
					transform.LookAt (player.transform.position);
					transform.position = Vector3.Lerp (transform.position, player.transform.position, Time.deltaTime * frogBossSpeed);

				}
			}
//			else if (searchRange > attackRange)
//			{
//				
//			}

			if (searchRange > runRange) 

				ThrowFrogPattern (ThrowFrogPatternName.ThrowFrogIdle);
				throwFrogState = this.throwFrogAiAnimator.GetCurrentAnimatorStateInfo (0);

				transform.rotation = new Quaternion (0f, transform.rotation.y, 0f, 0f);
				transform.position = new Vector3 (transform.position.x, 0f, transform.position.z);
				transform.LookAt (player.transform.position);
			
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
				throwFrogAiAnimator.SetInteger ("state", 3);
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
