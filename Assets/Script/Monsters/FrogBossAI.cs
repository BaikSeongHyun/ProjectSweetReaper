using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FrogBossAI : Monster
{
	public Animator bossAiAnimator;

	AnimatorStateInfo attackStateBoss;


	//Boss Pattern Range
	int bossAngryPattern = 0;

	//Boss Angry Image or Warning
	public Image bossAngryImage;

	public enum BossPatternName
	{
		BossIdle = 1,
		Angry,
		Run,
		BossNormalAttack,
		BossCriticalAttack,
		AttackIdle,
		TakeDamage,
		Death}

	;


	// Use this for initialization
	void Start()
	{
		frogInfo = this.GetComponent<MonsterHealth>();
		bossAiAnimator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag( "Player" );
		BossPattern( BossPatternName.AttackIdle );
		bossAngryImage.gameObject.SetActive( false );
		health = transform.Find( "BossFrogHpBar" ).GetComponent<Image>();
		exp = 2000.0f;
	}

	void Update()
	{
		if (isAlive)
		{
			float searchRange = Vector3.Distance( player.transform.position, transform.position );

			if (searchRange < attackRange)
			{
				if (attackCycle >= 2 && !attackStateBoss.IsName( "TakeDamage" ))
				{
					BossPattern( BossPatternName.BossNormalAttack );
					attackCycle = 0;
				}
				else
				{
					BossPattern( BossPatternName.BossIdle );
					attackCycle += Time.deltaTime;
				}
			}
			else if (searchRange <= runRange && bossAngryPattern == 0)
			{			
			
				bossAngryImage.gameObject.SetActive( true );
				BossPattern( BossPatternName.Angry );
				bossAngryPattern = 1;		
			}
			else if (searchRange <= runRange && bossAngryPattern == 1)
			{

				BossPattern( BossPatternName.Run );

				if (attackStateBoss.IsName( "Run" ))
				{
					bossAngryImage.gameObject.SetActive( false );
					transform.LookAt( player.transform.position );
					transform.position = Vector3.Lerp( transform.position, player.transform.position, Time.deltaTime * frogBossSpeed );
				}
			}

			if (searchRange > runRange && searchRange > runRange)
				BossPattern( BossPatternName.BossIdle );
			
			attackStateBoss = this.bossAiAnimator.GetCurrentAnimatorStateInfo( 0 );

			//set default rotation
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
		if (isAlive)
		{
			Instantiate( hitEffect, new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z), transform.rotation );
			Instantiate( hitObject, new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z), transform.rotation );
			frogInfo.MonsterHp -= _Damage;
			if (frogInfo.MonsterHp > 0)
			{
				bossAiAnimator.SetTrigger( "MonsterHitTrigger" );
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

				bossAiAnimator.SetTrigger( "MonsterDie" );
				isAlive = false;
				Destroy( this.gameObject, 3.0f );
				return;
			}
		}
	}

	public void BossPattern( BossPatternName state )
	{
		switch (state)
		{

			case BossPatternName.BossIdle:
				bossAiAnimator.SetInteger( "state", 1 );
				break;

			case BossPatternName.Angry:
				bossAiAnimator.SetInteger( "state", 2 );
				break;

			case BossPatternName.Run:
				bossAiAnimator.SetInteger( "state", 3 );
				break;

			case BossPatternName.BossNormalAttack:
				bossAiAnimator.SetInteger( "state", 4 );
				isAttack = true;
				break;

			case BossPatternName.BossCriticalAttack:
				bossAiAnimator.SetInteger( "state", 5 );
				break;

			case BossPatternName.AttackIdle:
				bossAiAnimator.SetInteger( "state", 6 );
				break;

			case BossPatternName.TakeDamage:
				bossAiAnimator.SetInteger( "state", 7 );
				break;

			case BossPatternName.Death:
				bossAiAnimator.SetInteger( "state", 8 );
				break;
		}
	}
}
