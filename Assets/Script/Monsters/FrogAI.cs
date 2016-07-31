using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FrogAI : Monster
{
	
	public Animator frogAiAnimator;
	AnimatorStateInfo attackStateBoss;

	//Boss Pattern Range
	int bossAngryPattern = 0;
	
	//Boss Angry Image or Warning
	public Image angryImage;
	float imageDelayTime;
	public float warningRange = 30.0f;
	
	//public GameObject mesh;
	public GameObject myObject;
	Renderer colorRenderer;
	Color TempColor;
	
	//hp image
	bool colorChanage = false;
	float colorTime = 0.0f;

	public enum FrogPatternName
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
		expThrow = GameObject.FindWithTag( "GameController" ).GetComponent<GameController>();
		colorRenderer = myObject.GetComponent<Renderer>();
		frogInfo = GetComponent<MonsterHealth>();
		frogAiAnimator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag( "Player" );
		FrogPattern( FrogPatternName.AttackIdle );
		angryImage = transform.Find( "StoneFrogAngryImage" ).GetComponent<Image>();
		angryImage.enabled = false;
		health = transform.Find( "StoneFrogHpBar" ).GetComponent<Image>();
		TempColor = colorRenderer.material.color;
		exp = 1000.0f;
	}



	void Update()
	{	
		if (isAlive)
		{
			float searchRange = Vector3.Distance( player.transform.position, transform.position );
			if (!colorChanage)
			{
				colorTime += Time.deltaTime;
				if (colorTime >= 0.4f)
				{
					colorRenderer.material.color = Color.white;
					colorTime = 0.0f;
					colorChanage = false;
				}
			}
			if (searchRange < attackRange)
			{
				if (attackCycle >= 2 && !attackStateBoss.IsName( "TakeDamage" ))
				{
					FrogPattern( FrogPatternName.BossNormalAttack );
					attackCycle = 0;
				}
				else
				{
					FrogPattern( FrogPatternName.BossIdle );
					attackCycle += Time.deltaTime;
				}
			}
			else if (searchRange <= runRange && bossAngryPattern == 0)
			{			
				angryImage.enabled = true;
				FrogPattern( FrogPatternName.Angry );
				bossAngryPattern = 1;		
			}
			else if (searchRange <= runRange && bossAngryPattern == 1)
			{
				FrogPattern( FrogPatternName.Run );

				if (attackStateBoss.IsName( "Run" ))
				{
					angryImage.enabled = false;
					transform.LookAt( player.transform.position );
					transform.position = Vector3.Lerp( transform.position, player.transform.position, Time.deltaTime * frogBossSpeed );
				}
			}

			if (searchRange > runRange && searchRange > runRange)
				FrogPattern( FrogPatternName.BossIdle );
			
			attackStateBoss = this.frogAiAnimator.GetCurrentAnimatorStateInfo( 0 );

			//set default rotation
			transform.rotation = new Quaternion ( 0f, transform.rotation.y, 0f, 0f );
			transform.position = new Vector3 ( transform.position.x, 0f, transform.position.z );
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

	public override void HitDamage( float _damage )
	{
		Instantiate( hitEffect, new Vector3 ( transform.position.x, transform.position.y + 1, transform.position.z ), transform.rotation );
		frogInfo.MonsterHp -= _damage;

		colorRenderer.material.color = new Color ( 255, 255, 255, 255 );

		if (isAlive)
		{
			
			frogInfo.monsterHp -= _damage;

			if (frogInfo.MonsterHp > 0)
			{				
				frogAiAnimator.SetTrigger( "MonsterHitTrigger" );
				return;		
			}

			if (frogInfo.MonsterHp <= 0)
			{
				health.fillAmount = 0;
				int randomItem = Random.Range( 0, 3 );

				if (randomItem == 0)
				{
					var item = Instantiate( dropItem, transform.position, new Quaternion ( 0, 0, 0, 0 ) );
					item.name = "DropItem";
				}
				else if (randomItem == 1)
				{
					var gold = Instantiate( dropGold, transform.position, new Quaternion ( 0, 0, 0, 0 ) );
					gold.name = "DropGold";
				}
				else
				{
					var item = Instantiate( dropItem, transform.position, new Quaternion ( 0, 0, 0, 0 ) );
					item.name = "DropItem";
					var gold = Instantiate( dropGold, transform.position, new Quaternion ( 0, 0, 0, 0 ) );					
					gold.name = "DropGold";
				}
				colorRenderer.material.color = Color.white;
				frogAiAnimator.SetTrigger( "MonsterDie" );
				isAlive = false;
				expThrow.ExpThrow( exp );
				Destroy( this.gameObject, 3.0f );
				return;
			}
		}
	}

	public void FrogPattern( FrogPatternName state )
	{
		switch (state)
		{

			case FrogPatternName.BossIdle:
				frogAiAnimator.SetInteger( "state", 1 );
				break;
			case FrogPatternName.Angry:
				frogAiAnimator.SetInteger( "state", 2 );
				break;
			case FrogPatternName.Run:
				frogAiAnimator.SetInteger( "state", 3 );
				break;
			case FrogPatternName.BossNormalAttack:
				frogAiAnimator.SetInteger( "state", 4 );
				isAttack = true;
				break;
			case FrogPatternName.BossCriticalAttack:
				frogAiAnimator.SetInteger( "state", 5 );
				break;
			case FrogPatternName.AttackIdle:
				frogAiAnimator.SetInteger( "state", 6 );
				break;
			case FrogPatternName.TakeDamage:
				frogAiAnimator.SetInteger( "state", 7 );
				break;
			case FrogPatternName.Death:
				frogAiAnimator.SetInteger( "state", 8 );
				break;
		}
	}
}
