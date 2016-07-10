using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FrogAI : MonoBehaviour
{
	public GameObject HitObject;
	public GameObject HitEffect;
	public GameObject player;
	public Animator frogAiAnimator;
	AnimatorStateInfo attackStateBoss;
	public FrogHealth frogInfo;

	//Boss Pattern Range
	int bossAngryPattern = 0;
	public float runRange = 10.0f;
	public float attackRange = 2.5f;
	public float attackCycle;
	public float frogBossSpeed = 0.5f;

	//Boss Angry Image or Warning
	public Image angryImage;
	Image warningImage;
	float imageDelayTime;
	public float warningRange = 30.0f;	
	bool isAlive = true;
	bool isAttack = false;
	
	//hp image
	public Image health;
	public GameObject dropItem;
	public GameObject dropGold;

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
		frogInfo = GetComponent<FrogHealth>();
		frogAiAnimator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag( "Player" );
		FrogPattern( FrogPatternName.AttackIdle );
		angryImage = transform.Find( "StoneFrogAngryImage" ).GetComponent<Image>();
		angryImage.enabled = false;
		health = transform.Find("StoneFrogHpBar").GetComponent<Image>();
		
	}

	public bool IsAttack
	{
		get{ return isAttack; }
	}

	public void AttackTrigger()
	{
		isAttack = false;
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
			transform.rotation = new Quaternion(0f, transform.rotation.y, 0f, 0f);
			transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
			transform.LookAt( player.transform.position );
			
			//update hp
			health.fillAmount = frogInfo.FillFrogHp;
		}
	}

	public void SetAttackTime()
	{
		attackCycle = 0;
	}

	public void HitDamage( float _Damage )
	{
		Instantiate( HitEffect, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation );
		Instantiate( HitObject, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation );
		if (isAlive)
		{
			frogInfo.frogHp -= _Damage;
			if (frogInfo.FrogHp > 0)
			{
				frogAiAnimator.SetTrigger( "MonsterHitTrigger" );
				return;
			}

			if (frogInfo.FrogHp <= 0)
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

				frogAiAnimator.SetTrigger( "MonsterDie" );
				isAlive = false;
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
