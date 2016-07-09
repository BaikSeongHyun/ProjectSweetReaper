using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterFaye : MonoBehaviour
{

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
	//int skillSlotCount = 1;
	public int skillingChainCount = 0;
	public bool runState = false;

	bool skillChainTrigger = false;
	bool skillusingState = false;
	bool normalAttackState = false;
	bool deadOrAlive = true;

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

	public Vector3 _destinaton
	{
		get {
			return destination;
		}set
		{
			destination = value;
		}
	}

	public bool _normalAttackState
	{
		get {
			return normalAttackState;
		}
	}

	public bool _skillusingState
	{
		get {
			return skillusingState;
		}
	}

	public void Start()
	{
		respawnPoint = transform.position;
		destination = this.transform.position;
		animator = GetComponent<Animator>();
		charInfo = GetComponent<CharacterInformation>();
		Hit.size = new Vector3 (0, 0, 0);
	}

	void Update()
	{
		if (deadOrAlive)
		{
			if (normalAttackState || skillusingState) {
				Hit.size = new Vector3 (0.5f, 1.5f, 1f);
			} else {
				Hit.size = new Vector3 (0, 0, 0);
			}
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
		}
	}

	void Move()
	{
		if (skillusingState == true)
		{
			SetState( "Idle" );
		}
		else
		{
			attackState = this.animator.GetCurrentAnimatorStateInfo( 0 );
			if (attackState.IsName( "Evation" ))
			{
				Effect.SetActive( false );
				transform.Translate( transform.forward * Time.deltaTime * moveSpeed, Space.World );
				destination = this.transform.position;
			}

			//Cancel Attack
			if (attackState.IsName( "NormalAttack" ) && Vector3.Distance( transform.position, destination ) >= 0.1f)
			{
				normalAttackState = false;
				animator.Play( "Idle" );
			}
			if (Vector3.Distance( destination, transform.position ) <= 0.1f)
			{
				SetState( "Idle" );
			}
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
		animator.Play( "Idle" );
		deadOrAlive = true;
	}

	public void ChainTrigger()
	{
		if (skillusingState == true)
		{
			skillChainTrigger = true;
			skillusingState = false;
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
		if (deadOrAlive)
		{
			if (charInfo.PresentHealthPoint > 0)
			{
				this.charInfo.presentHealthPoint -= _damage;
				animator.SetTrigger( "PlayerHitTrigger" );
			}
			if (charInfo.PresentHealthPoint <= 0)
			{
				animator.SetTrigger( "PlayerDie" );
				deadOrAlive = false;
			}
		}
	}

	void OnCollisionEnter( Collision coll )
	{
		destination = transform.position;
	}

	public void SkillCommand( string _command )
	{
		if (_command != "Evation")
		{
			skillChainTrigger = false;
			skillChainWaitingTimeMax = skillChainWaitingTimeMax - 1;
			if (skillingChainCount >= 5)
			{
				skillingChainCount = 0;
			}
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
				skillusingState = true;
				break;
			case "S":
				skillingChainCount++;
				SetState( "Skill_S" );
				skillusingState = true;
				break;
			case "D":
				skillingChainCount++;
				SetState( "Skill_D" );
				skillusingState = true;
				break;
			case "Q":
				skillingChainCount++;
				SetState( "Skill_Q" );
				skillusingState = true;
				break;
		
			case "Skill2":
				skillingChainCount++;
				SetState( "Skill_W" );
				skillusingState = true;
				break;

			case "Skill3":
				skillingChainCount++;
				SetState( "Skill_E" );
				skillusingState = true;
				break;

			case "Evation":
				SetState( "Evation" );
				break;
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
			case "Evation":
				animator.SetTrigger( "Evation" );
				break;
		}
	}
}