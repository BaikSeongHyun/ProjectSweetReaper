using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Nightmare : Monster
{
	Animator nightmareAnimator;
	float moveSpeed = 3.0f;
	float distance;
	float stateTime = 0.0f;
	bool hitTrigger = false;
	MonsterHealth info;
	public BoxCollider Hit;
	AnimatorStateInfo attackState;
	public GameObject returnObject;
	
	// Use this for initialization
	void Start()
	{
		expThrow = GameObject.FindWithTag( "GameController" ).GetComponent<GameController>();
		info = this.GetComponent<MonsterHealth>();
		Hit.size = new Vector3(0, 0, 0);
		player = GameObject.Find( "Faye" );
		nightmareAnimator = GetComponent<Animator>();
		nightmareAnimator.speed = 1.5f;
		health = transform.Find( "NightmareHpBar" ).GetComponent<Image>();
		exp = 16000f;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (isAlive)
		{
			ProcessTime();
			Process();
			
			health.fillAmount = info.FillFrogHp;
			RotateHealthBar();
		}
	}

	public void ChainTrigger()
	{
		isAttack = false;
		Hit.size = new Vector3(0, 0, 0);
	}

	public void ProcessTime()
	{
		if (hitTrigger)
		{
			stateTime += Time.deltaTime;
			if (stateTime >= 2.0f)
			{
				hitTrigger = false;
				stateTime = 0.0f;
			}
		}
	}

	public override void HitDamage( float damage )
	{
		if (isAlive)
		{
			Instantiate( hitEffect, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation );
			info.MonsterHp -= damage;
			if (info.MonsterHp > 0)
			{
				Hit.size = new Vector3(0, 0, 0);
				nightmareAnimator.SetTrigger( "PlayerHitTrigger" );
				stateTime = 0.0f;
				return;		
			}

			if (info.MonsterHp <= 0)
			{
				Hit.size = new Vector3(0, 0, 0);
				nightmareAnimator.SetTrigger( "PlayerDie" );
				isAlive = false;
				expThrow.ExpThrow( exp );
				Instantiate( returnObject, transform.position, transform.rotation );
			}
		}
	}

	public void ScytheSoundEffect()
	{
	}

	public void Process()
	{
		distance = Vector3.Distance( transform.position, player.transform.position );
		//Run
		if (distance >= 2f)
		{
			transform.LookAt( player.transform );
			nightmareAnimator.SetBool( "Run", true );
			transform.Translate( transform.forward * Time.deltaTime * moveSpeed, Space.World );
		}
		//Attack
		else
		{
			nightmareAnimator.SetBool( "Run", false );
			attackState = this.nightmareAnimator.GetCurrentAnimatorStateInfo( 0 );
			int nightMareState = Random.Range( 0, 5 );

			if (nightMareState == 0 && !hitTrigger)
			{
				nightmareAnimator.SetTrigger( "Bash" );
				isAttack = true;
				hitTrigger = true;
				Hit.size = new Vector3(0.5f, 1.5f, 1f);
			}
			else if (nightMareState == 1 && !hitTrigger)
			{
				nightmareAnimator.SetTrigger( "UpperScythe" );
				isAttack = true;
				hitTrigger = true;
				Hit.size = new Vector3(0.5f, 1.5f, 1f);
			}
			else if (nightMareState == 2 && !hitTrigger)
			{
				nightmareAnimator.SetTrigger( "TwinRush" );
				isAttack = true;
				hitTrigger = true;
				Hit.size = new Vector3(0.5f, 1.5f, 1f);
			}
			else if (nightMareState == 3 && !hitTrigger)
			{
				nightmareAnimator.SetTrigger( "CrescentCut" );
				isAttack = true;
				hitTrigger = true;
				Hit.size = new Vector3(0.5f, 1.5f, 1f);
			}
			else if (nightMareState == 4 && !hitTrigger)
			{
				nightmareAnimator.SetTrigger( "WheelScythe" );
				isAttack = true;
				hitTrigger = true;
				Hit.size = new Vector3(0.5f, 1.5f, 1f);
			}		
		}
	}
}
