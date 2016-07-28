using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;


public class CharacterFaye : MonoBehaviour
{
	public bool isStop = false;
	AudioSource audioSource;
	public AudioClip soundEffect;
	public GameObject finishSkillEffect;
	public GameObject skillEffect;
	//UI
	public GameObject Effect;
	public BoxCollider Hit;
	//Vector3
	Vector3 destination;
	Vector3 Pos;
	Vector3 respawnPoint;

	//Animation
	AnimatorStateInfo attackState;
	CharacterInformation charInfo;
	Animator animator;
	float moveSpeed = 5.0f;
	float skillChainWaitingTime = 0.0f;
	float skillChainWaitingTimeMax = 6.0f;
	public int skillingChainCount = 0;
	public bool runState = false;
	public int skillCount = 6;
	bool skillChainTrigger = false;
	bool skillUsingState = false;
	bool normalAttackState = false;

	bool isSoundTrigger = false;

	//finish Skill
	bool isAlive = true;
	bool finish = false;
	int finishSkillcount = 0;
	float animatorSpeed = 0.6f;
	STATE presentState;

	//skill
	
	public bool skillTrigger = false;


	//State Event
	public enum STATE
	{
		Default,
		Idle,
		Run}
	;

	//property
	public STATE State
	{
		get { return presentState; }
	}

	public Vector3 Destinaton
	{
		get { return destination; }
		set	{ destination = value; }
	}

	public bool NormalAttackState
	{
		get { return normalAttackState; }
	}

	public bool SkillTrigger
	{
		get { return skillTrigger; }
	}

	public bool SkillUsingState
	{
		get { return skillUsingState; }
	}

	public bool IsStop
	{
		get { return isStop; }
	}

	public bool IsAlive
	{
		get { return isAlive; }
	}

	public void Start()
	{
		audioSource = GetComponent<AudioSource>();		
		animator = GetComponent<Animator>();
		charInfo = GetComponent<CharacterInformation>();
		InitializeData();		
	}

	void Update()
	{
		
		SkillCoolTime();
		if (finish)
		{
			isStop = true;

			if (finishSkillcount == 1 && !skillUsingState)
			{
				Instantiate( finishSkillEffect, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation );
				skillEffect.name = "DemonicScythe";
			}

			if (finishSkillcount >= 10)
			{
				isSoundTrigger = false;
			}
			else if (finishSkillcount == 9 && !skillUsingState)
			{
				isSoundTrigger = false;
				this.GetComponent<Animator>().speed = 1.5f;
				finishSkillcount++;
				skillUsingState = true;
			}
			else if (finishSkillcount < 9 && !skillUsingState)
			{
				isSoundTrigger = false;
				animatorSpeed = animatorSpeed + 0.4f;
				this.GetComponent<Animator>().speed = animatorSpeed;
				finishSkillcount++;
				skillUsingState = true;
			}
		}

		if (Input.GetKeyDown( KeyCode.Z ))
		{
			SetState( "DemonicScythe" );
		}

		if (!skillUsingState)
			isStop = false;		

		if (isStop == true)
			Time.timeScale = 0.01f;
		else
			Time.timeScale = 1.0f;
		

		if (isAlive)
		{
			if (normalAttackState || skillUsingState)
			{
				Hit.size = new Vector3(0.5f, 1.5f, 1f);
			}
			else
				Hit.size = new Vector3(0, 0, 0);
			
			if (skillChainTrigger == true)
			{
				//skillChaintWaitingTimeMax=4.0f (Default)
				if (skillChainWaitingTime >= skillChainWaitingTimeMax)
				{
					skillingChainCount = 0;
					charInfo.ComboCounter = 0;
					skillChainWaitingTimeMax = 5.0f;
					charInfo.ComboTimeFill = 0f;	
					skillChainWaitingTime = 0.0f;
					skillChainTrigger = false;	
				}
				else
				{				
					skillChainWaitingTime += Time.deltaTime;
					charInfo.ComboCounter = skillingChainCount;
					charInfo.ComboTimeFill = 1 - (skillChainWaitingTime / skillChainWaitingTimeMax);
				}
			}
			//fixed Y
			transform.position = new Vector3(transform.position.x, 0, transform.position.z);
			Move();
			
			if (charInfo.PresentResourcePoint <= charInfo.OriginResourcePoint)
				charInfo.PresentResourcePoint += 10f * Time.deltaTime;
		}
	}

	void InitializeData()
	{
		respawnPoint = transform.position;
		destination = this.transform.position;
		Hit.size = new Vector3(0, 0, 0);
		this.GetComponent<Animator>().speed = 1.5f;		
	}

	void Move()
	{
		if (!skillUsingState)
		{
			attackState = this.animator.GetCurrentAnimatorStateInfo( 0 );

			//Cancel Attack
			if (attackState.IsName( "NormalAttack" ) && Vector3.Distance( transform.position, destination ) >= 0.1f)
			{
				normalAttackState = false;
				animator.Play( "Idle" );
			}
			if (Vector3.Distance( destination, transform.position ) <= 0.1f)
				SetState( "Idle" );
			else
			{
				SetState( "Run" );
				if (attackState.IsName( "Run" ))
				{
					//Effect.SetActive (false);
					Vector3 direction = destination - this.transform.position;
					this.transform.LookAt( destination );
					direction.Normalize();
					transform.Translate( direction * Time.deltaTime * moveSpeed, Space.World );
				}
			}
		}
	}

	public void ScytheSoundEffect()
	{
		if (isSoundTrigger == false)
		{
			audioSource.PlayOneShot( soundEffect );
		}
	}


	public void SpecialSkill()
	{
		finish = false;
		isStop = false;
		finishSkillcount = 0;
		animatorSpeed = 0.6f;
		skillTrigger = true;
	}

	public void BashHitBoxIncease()
	{
		normalAttackState = false;
	}

	public void SkillCoolTime()
	{
		for (int i = 0; i < charInfo.OnSkill.Length; i++)
		{
			if (charInfo.OnSkill[i])
			{
				charInfo.SkillCoolTime[i] += Time.deltaTime;
				try
				{
					if (charInfo.SkillCoolTime[i] >= charInfo.installSkill[i].CoolTime)
					{
						charInfo.OnSkill[i] = false;
						charInfo.SkillCoolTime[i] = 0.0f;
					}
				}
				catch (NullReferenceException e)
				{
					Debug.Log( e.InnerException );
					charInfo.SkillCoolTime[i] = 0.0f;
				}
			}
		}
	}

	public void Respawn()
	{
		charInfo.presentHealthPoint = charInfo.OriginHealthPoint;
		transform.position = respawnPoint;
		destination = transform.position;
		animator.Play( "Idle" );
		isAlive = true;
	}

	public void ChainTrigger()
	{
		if (skillUsingState)
		{
			skillChainTrigger = true;
			skillUsingState = false;
			isSoundTrigger = true;
		}

		destination = transform.position;
	}

	public void Attack()
	{
		Effect.SetActive( false );
		destination = this.transform.position;
		normalAttackState = true;
		SetState( "NormalAttack" );

	}

	void SetStateDefault()
	{
		animator.SetBool( "Idle", false );
		animator.SetBool( "Run", false );
	}

	public void HitDamage( float _damage )
	{
		if (isAlive)
		{
			if (charInfo.PresentHealthPoint > 0)
			{
				this.charInfo.PresentHealthPoint -= _damage;
				animator.SetTrigger( "PlayerHitTrigger" );
			}
			if (charInfo.PresentHealthPoint <= 0)
			{
				animator.SetTrigger( "PlayerDie" );
				isAlive = false;
			}
		}
	}

	void OnCollisionEnter( Collision coll )
	{
		destination = transform.position;
	}

	public void SkillCommand( int index )
	{
		if (isAlive && !skillUsingState)
		{
			//check active skill -> exit
			if ((charInfo.InstallSkill[index] == null) || (charInfo.InstallSkill[index].Name == "Default"))
				return;
			else if (!charInfo.OnSkill[index] && charInfo.CheckSkillResource(index))
			{
				//set faye idle
				Effect.SetActive( true );
				SetState( "Idle" );
				
				//animator force move
				animator.Play( "Idle" );
				destination = this.transform.position;
				
				//action skill
				charInfo.PresentResourcePoint -= charInfo.InstallSkill[index].SkillResource;
				isSoundTrigger = false;
				skillChainTrigger = false;
				SetState( charInfo.InstallSkill[index].Name );
				skillUsingState = true;
				charInfo.OnSkill[index] = true;
			}

			
			//skill chain section
			if (skillUsingState)
				skillChainWaitingTime = 0.0f;				
			

			if (skillingChainCount < 4 && skillUsingState)
			{
				skillChainWaitingTimeMax = skillChainWaitingTimeMax - 1;
				skillingChainCount++;
			}
			else if (skillingChainCount >= 4 && skillUsingState)
			{
				if (!finish)
				{
					skillingChainCount = 4;
				}
				else
				{
					finish = false;
					skillingChainCount = 0;
					charInfo.ComboCounter = 0;
					skillChainWaitingTimeMax = 5.0f;
				}
			}


		}
	}

	public void SetState( string state )
	{
		SetStateDefault();
		switch (state)
		{
			case "Idle":
				presentState = STATE.Idle;
				animator.SetBool( "Idle", true );
				break;

			case "Run":
				presentState = STATE.Run;
				animator.SetBool( "Run", true );
				break;

			case "NormalAttack":
				animator.SetTrigger( "NormalAttack" );
				break;

			case "Bash":
				Instantiate( skillEffect, new Vector3(transform.position.x, 0.3f, transform.position.z), transform.rotation );
				animator.SetTrigger( "Bash" );
				break;

			case "TwinRush":
				Instantiate( skillEffect, new Vector3(transform.position.x, 0.3f, transform.position.z), transform.rotation );
				animator.SetTrigger( "TwinRush" );
				break;

			case "CrescentCut":
				Instantiate( skillEffect, new Vector3(transform.position.x, 0.3f, transform.position.z), transform.rotation );
				animator.SetTrigger( "CrescentCut" );
				break;

			case "LandCrush":
				Instantiate( skillEffect, new Vector3(transform.position.x, 0.3f, transform.position.z), transform.rotation );
				animator.SetTrigger( "LandCrush" );
				break;

			case "WheelScythe":
				Instantiate( skillEffect, new Vector3(transform.position.x, 0.3f, transform.position.z), transform.rotation );
				animator.SetTrigger( "WheelScythe" );
				break;

			case "UpperScythe":
				Instantiate( skillEffect, new Vector3(transform.position.x, 0.3f, transform.position.z), transform.rotation );
				animator.SetTrigger( "UpperScythe" );
				break;

			case "Skill_E":
				Instantiate( skillEffect, new Vector3(transform.position.x, 0.3f, transform.position.z), transform.rotation );
				animator.SetTrigger( "Skill_E" );
				break;

			case "Kick":
				animator.SetTrigger( "Kick" );
				break;

			case "DemonicScythe":
				if (skillingChainCount >= 4)
				{
					skillTrigger = false;
					Instantiate( skillEffect, new Vector3(transform.position.x, 0.2f, transform.position.z), transform.rotation );

					isSoundTrigger = false;
					Effect.SetActive( false );
					animator.SetTrigger( "DemonicScythe" );
					this.GetComponent<Animator>().speed = animatorSpeed;
					finish = true;
					skillUsingState = true;
					skillingChainCount = 0;
				}
				break;
		}
	}

	public bool AcquireItem( DropItem item, UserInterfaceManager mainUI )
	{
		if (item.gameObject.name == "DropGold")
		{			
			charInfo.Money += item.Gold;
			mainUI.AsynchronousSystemUI( item.Gold.ToString() + " 골드를 획득하셨습니다." );
			return true;
		}
		else if (item.gameObject.name == "DropItem")
		{
			mainUI.AsynchronousSystemUI( item.ItemInfo.Name + "를(을) 획득하셨습니다." );
			return charInfo.AddItem( item.ItemInfo );			
		}
		else
			return false;
		
	}
}