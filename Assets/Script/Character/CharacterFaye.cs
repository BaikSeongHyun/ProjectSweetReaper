using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterFaye : MonoBehaviour
{

	//UI
	public GameObject Effect;
	public Image SkillChainProgressBar;

	//Vector3
	Vector3 destination;
	Vector3 Pos;

	//Animation
	AnimatorStateInfo attackState;
	Animator animator;

	float moveSpeed = 4.0f;
	//int skillSlotCount = 1;
	public bool runState = false;
	STATE presentState;
	int skillingChainCount = 0;
	float skillChainWaitingTime = 0.0f;
	float skillChainWaitingTimeMax = 4.0f;
	bool skillChainTrigger = false;
	bool skillusingState = false;
	bool normalAttackState = false;
	//State Event
	public enum STATE
	{
		Default,
		Idle,
		Run}
	;

	public void Start()
	{
		SkillChainProgressBar.gameObject.SetActive( false );
		destination = this.transform.position;
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		if (skillChainTrigger == true)
		{
			//skillChaintWaitingTimeMax=4.0f (Default)
			if (skillChainWaitingTime >= skillChainWaitingTimeMax)
			{
				skillingChainCount = 0;
				skillChainWaitingTime = 0.0f;
				skillChainWaitingTimeMax = 4.0f;
				skillChainTrigger = false;
				SkillChainProgressBar.gameObject.SetActive( false );
			}
			else
			{
				SkillChainProgressBar.gameObject.SetActive( true );
				skillChainWaitingTime += Time.deltaTime;
				SkillChainProgressBar.fillAmount = 1 - ( skillChainWaitingTime / skillChainWaitingTimeMax );
			}
		}
		//fixed Y
		transform.position = new Vector3 ( transform.position.x, 0, transform.position.z );
		Move();
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

	public void skillCommand( string _command )
	{
		if (_command != "Evation")
		{
			skillChainTrigger = false;
			skillChainWaitingTimeMax = skillChainWaitingTimeMax - skillingChainCount;
			if (skillingChainCount >= 4)
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
			case "Evation":
				SetState( "Evation" );
				break;
		}
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

	public void Attack()
	{
		Effect.SetActive( false );
		destination = this.transform.position;
		normalAttackState = true;
		SetState( "NormalAttack" );

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

	void SetStateDefault()
	{
		animator.SetBool( "Idle", false );
		animator.SetBool( "Run", false );
	}

	//property
	public STATE State
	{
		get { return presentState; }
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
			case "Evation":
				animator.SetTrigger( "Evation" );
				break;
		}
	}

	void OnCollisionEnter( Collision Coll )
	{
		if (Coll.gameObject.layer == LayerMask.NameToLayer("Enermy"))
		{

			if (skillusingState || normalAttackState)
			{
			}
			else
			{
			}
		}
	}

	void OnCollisionStay( Collision Coll )
	{
		if (Coll.gameObject.layer == 12)
		{
			destination = this.transform.position;
			transform.position = new Vector3 ( transform.position.x, 0, transform.position.z );
		}
	}
}