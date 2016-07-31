using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SuicideFrogAI : Monster
{
	public Animator suicideFrogAIAnimator;

	AnimatorStateInfo suicideFrogState;

	FrogBombObject bombObject;
	public GameObject BombEffect;
	int effectCount;

	public enum SuicideFrogPatternName
	{
		SuicideFrogIdle = 1,
		SuicideFrogRun,
		SuicideFrogAttack,
		SuicideFrogTakeDamage,
		SuicideFrogDeath}

	;

	// Use this for initialization
	void Start()
	{
		frogInfo = this.GetComponent<MonsterHealth>();
		suicideFrogAIAnimator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag( "Player" );
		health = transform.Find( "SuicideFrogHpBar" ).GetComponent<Image>();

	}
	// Update is called once per frame
	void Update()
	{
		if (isAlive)
		{
			float searchRange = Vector3.Distance( player.transform.position, transform.position );

			if (searchRange < attackRange)
			{

				SuicideFrogAttack();	
				Destroy( this.gameObject, 4f );					

			}
			else if (searchRange <= runRange)
			{
				SuicideFrogPattern( SuicideFrogPatternName.SuicideFrogRun );

				if (suicideFrogState.IsName( "SuicideFrogRun" ))
				{
					transform.LookAt( player.transform.position );
					transform.position = Vector3.Lerp( transform.position, player.transform.position, Time.deltaTime * frogBossSpeed );

				}

			}

			if (searchRange > runRange)
				SuicideFrogPattern( SuicideFrogPatternName.SuicideFrogIdle );

			suicideFrogState = this.suicideFrogAIAnimator.GetCurrentAnimatorStateInfo( 0 );


			//set default rotation
			transform.rotation = new Quaternion(0f, transform.rotation.y, 0f, 0f);
			transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
			transform.LookAt( player.transform.position );

			//update hp
			health.fillAmount = frogInfo.FillFrogHp;
			RotateHealthBar();
		}	
	}



	public void SetAttackTime()
	{
		attackCycle = 0;
	}



	public override void HitDamage( float _Damage )
	{
		if (isAlive)
		{
			//Instantiate( hitEffect, new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z), transform.rotation );
			//Instantiate( hitObject, new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z), transform.rotation );
			frogInfo.MonsterHp -= _Damage;
			if (frogInfo.MonsterHp > 0)
			{
				suicideFrogAIAnimator.SetTrigger( "MonsterHitTrigger" );
				return;
			}

			if (frogInfo.MonsterHp <= 0)
			{				
				health.fillAmount = 0;
				int randomItem = Random.Range( 0, 3 );

				suicideFrogAIAnimator.SetTrigger( "MonsterDie" );
				isAlive = false;
				Destroy( this.gameObject, 3.0f );
				return;
			}
		}
	}





	public void SuicideFrogPattern( SuicideFrogPatternName state )
	{
		switch (state)
		{
			case SuicideFrogPatternName.SuicideFrogIdle:
				suicideFrogAIAnimator.SetInteger( "state", 1 );
				break;
			case SuicideFrogPatternName.SuicideFrogRun:
				suicideFrogAIAnimator.SetInteger( "state", 2 );
				break;
			case SuicideFrogPatternName.SuicideFrogAttack:
				suicideFrogAIAnimator.SetInteger( "state", 3 );
				break;
			case SuicideFrogPatternName.SuicideFrogTakeDamage:
				suicideFrogAIAnimator.SetInteger( "state", 4 );
				break;
			case SuicideFrogPatternName.SuicideFrogDeath:
				suicideFrogAIAnimator.SetInteger( "state", 5 );
				break;
		}
	}

	public void SuicideFrogAttack()
	{
		if (!suicideFrogState.IsName( "SuicideFrogTakeDamage" ))
		{
			SuicideFrogPattern( SuicideFrogPatternName.SuicideFrogAttack );
			if (effectCount < 1)
			{
				effectCount++;
				GameObject bomb = (GameObject)Instantiate( BombEffect, this.transform.position, transform.rotation );
				bomb.GetComponent<FrogBombObject>().BombDamege( frogInfo.MonsterDamage );
				//	bombObject.BombDamege =  frogInfo.MonsterDamage;
			}
		}	
	}
}