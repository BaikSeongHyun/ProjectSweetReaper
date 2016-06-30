using UnityEngine;
using System.Collections;

public class CharacterFaye : MonoBehaviour
{

	public float moveSpeed = 8.0f;
	//Default : 4
	public int skillCouunt = 1;
	public bool runState = false;
	public STATE presentState;
	Animator animator;
	Vector3 Pos;
	AnimatorStateInfo attackState;
	public Vector3 destination;
	//State Event
	public enum STATE
	{
		Default,
		Idle,
		Run}

	;

	public void Start( )
	{
		destination = this.transform.position;
		animator = GetComponent<Animator>();
	}

	void Update( )
	{
		Move();
	}

	public void skillCommand( string _command )
	{
		destination = this.transform.position;
		switch(_command)
		{
			case "A":
				SetState( "Skill_A" );
				break;
			case "S":
				SetState( "Skill_S" );
				break;
			case "D":
				SetState( "Skill_D" );
				break;
			case "Q":
				SetState( "Skill_Q" );
				break;
		}
	}

	public Vector3 _destinaton
	{
		get {
			return destination;
		}set {
			destination = value;
		}
	}

	public void Attack( )
	{
		destination = this.transform.position;
		SetState( "Idle" );
		SetState( "NormalAttack" );
	}

	void Move( )
	{
		attackState = this.animator.GetCurrentAnimatorStateInfo( 0 );
		if (attackState.IsName( "Idle" ) || attackState.IsName( "Run" ))
		{
			if (Vector3.Distance( destination, transform.position ) <= 0.1f)
			{
				SetState( "Idle" );
			}
			else
			{
				Vector3 direction = destination - this.transform.position;
				this.transform.LookAt( destination );
				direction.Normalize();
				SetState( "Run" );
				transform.Translate( direction * Time.deltaTime * moveSpeed, Space.World );
			}
		}
	}

	void SetStateDefault( )
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
		switch(state)
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
		}
	}
}
