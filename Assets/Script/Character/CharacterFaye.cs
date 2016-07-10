using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterFaye : MonoBehaviour
{
	public bool isStop = false;
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

	float moveSpeed = 4.0f;
	float skillChainWaitingTime = 0.0f;
	float skillChainWaitingTimeMax = 5.0f;
	public int skillingChainCount = 0;
	public bool runState = false;

	bool skillChainTrigger = false;
	bool skillUsingState = false;
	bool normalAttackState = false;
	bool isAlive = true;
	STATE presentState;

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

	public bool SkillUsingState
	{
		get { return skillUsingState; }
	}

	public bool IsStop
	{
		get { return  isStop; }
	}

	public bool IsAlive
	{
		get { return isAlive; }
	}

	public void Start()
	{
		respawnPoint = transform.position;
		destination = this.transform.position;
		animator = GetComponent<Animator>();
		charInfo = GetComponent<CharacterInformation>();
		Hit.size = new Vector3(0, 0, 0);
	}

	void Update()
	{
		if (skillingChainCount == 5)
			isStop = true;
		

		if (!skillUsingState)
			isStop = false;
		

		if (isStop == true)
			Time.timeScale = 0.1f;
		else
			Time.timeScale = 1.0f;
		

		if (isAlive)
		{
			if (normalAttackState || skillUsingState)
				Hit.size = new Vector3(0.5f, 1.5f, 1f);
			else
				Hit.size = new Vector3(0, 0, 0);
			
			if (skillChainTrigger == true)
			{
				//skillChaintWaitingTimeMax=4.0f (Default)
				if (skillChainWaitingTime >= skillChainWaitingTimeMax)
				{
					skillingChainCount = 0;
					skillChainWaitingTime = 0.0f;
					skillChainWaitingTimeMax = 5.0f;
					skillChainTrigger = false;	
					charInfo.ComboCounter = 0;
					charInfo.ComboTimeFill = 0f;
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

	void Move()
	{
		if (skillUsingState == true)
		{
			SetState( "Idle" );
		}
		else
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
		}
		normalAttackState = false;
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

	public void SkillCommand( string _command )
	{
		if (isAlive && charInfo.PresentResourcePoint >= 20f)
		{
			charInfo.PresentResourcePoint -= 20f;
			if (_command != "Evation")
			{
				skillChainTrigger = false;
				skillChainWaitingTimeMax = skillChainWaitingTimeMax - 1;
				if (skillingChainCount >= 5)
					skillingChainCount = 0;
				
				skillChainWaitingTime = 0.0f;
			}
			Effect.SetActive( true );
			animator.Play( "Idle" );
			destination = this.transform.position;
			switch (_command)
			{
				case "A":
					skillingChainCount++;
					SetState( "Skill_A" );
					skillUsingState = true;
					break;
				case "S":
					skillingChainCount++;
					SetState( "Skill_S" );
					skillUsingState = true;
					break;
				case "D":
					skillingChainCount++;
					SetState( "Skill_D" );
					skillUsingState = true;
					break;
				case "Q":
					skillingChainCount++;
					SetState( "Skill_Q" );
					skillUsingState = true;
					break;		
				case "Skill2":
					skillingChainCount++;
					SetState( "Skill_W" );
					skillUsingState = true;
					break;
				case "Skill3":
					skillingChainCount++;
					SetState( "Skill_E" );
					skillUsingState = true;
					break;
			}
		}
	}

	// method
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
			case "Skill_A":
				animator.SetTrigger( "Skill_A" );
				break;
			case "Skill_S":
				animator.SetTrigger( "Skill_S" );
				break;
			case "Skill_D":
				animator.SetTrigger( "Skill_D" );
				break;
			case "Skill_Q":
				animator.SetTrigger( "Skill_Q" );
				break;
			case "Skill_W":
				animator.SetTrigger( "Skill_W" );
				break;
			case "Skill_E":
				animator.SetTrigger( "Skill_E" );
				break;
		}
	}
	
	//
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