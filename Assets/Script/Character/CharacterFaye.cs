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
	float moveSpeed = 5.0f;
	float skillChainWaitingTime = 0.0f;
	float skillChainWaitingTimeMax = 6.0f;
	public int skillingChainCount = 0;
	public bool runState = false;
	public int skillCount=6;
	bool skillChainTrigger = false;
	bool skillUsingState = false;
	bool normalAttackState = false;

	//finish Skill
	bool isAlive = true;
	bool finish = false;
	int finishSkillcount = 0;
	float animatorSpeed = 0.6f;
	STATE presentState;

	//skill

	bool bash=false;
	bool twinRush=false;
	bool crescentCut=false;
	bool kick=false;
	bool landCrush=false;
	bool wheelScythe=false;
	bool upperScythe=false;

	float kickCooltime=0.0f;
	float bashCooltime=0.0f;
	float twinRushCooltime=0.0f;
	float landCrushCooltime=0.0f;
	float crescentCutCooltime=0.0f;
	float WheelScythebashCooltime=0.0f;
	float upperScytheCooltime=0.0f;

	//State Event
	public enum STATE
	{
		Default,
		Idle,
		Run
	}
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
		this.GetComponent<Animator> ().speed = 1.5f;
	}

	void Update()
	{
		SkillCoolTime ();
		if (finish) {
			isStop = true;
			if (finishSkillcount >= 10) {
				finishSkillcount = 0;
				animatorSpeed = 0.6f;
				finish = false;
				isStop = false;
			} else if (finishSkillcount == 9 && !skillUsingState) {
				this.GetComponent<Animator> ().speed = 1.5f;
				finishSkillcount++;
				skillUsingState = true;
			}else if (finishSkillcount < 9 && !skillUsingState) {
				animatorSpeed = animatorSpeed + 0.4f;
				this.GetComponent<Animator> ().speed = animatorSpeed;
				finishSkillcount++;
				skillUsingState = true;
				Debug.Log (finishSkillcount);
			}
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			SetState ("DemonicScythe");
		}

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

	public void BashHitBoxIncease(){
		normalAttackState = false;
	}

	public void SkillCoolTime(){
		if (bash) {
			bashCooltime += Time.deltaTime;
			if (bashCooltime >= 5.0f) {
				bash = false;
				bashCooltime = 0.0f;
			}
		}

		if (twinRush) {
			twinRushCooltime += Time.deltaTime;
			if (twinRushCooltime >= 5.0f) {
				twinRush = false;
				twinRushCooltime = 0.0f;
			}
		}

		if (crescentCut) {
			crescentCutCooltime += Time.deltaTime;
			if (crescentCutCooltime >= 5.0f) {
				crescentCut = false;
				crescentCutCooltime = 0.0f;
			}
		}

		if (landCrush) {
			landCrushCooltime += Time.deltaTime;
			if (landCrushCooltime >= 5.0f) {
				landCrush = false;
				landCrushCooltime = 0.0f;
			}
		}

		if (wheelScythe) {
			WheelScythebashCooltime += Time.deltaTime;
			if (WheelScythebashCooltime >= 5.0f) {
				wheelScythe = false;
				WheelScythebashCooltime = 0.0f;
			}
		}

		if (upperScythe) {
			upperScytheCooltime += Time.deltaTime;
			if (upperScytheCooltime >= 5.0f) {
				upperScythe = false;
				upperScytheCooltime = 0.0f;
			}
		}

		if (kick) {
			kickCooltime += Time.deltaTime;
			if (kickCooltime >= 5.0f) {
				kick = false;
				kickCooltime = 0.0f;
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

	public void SkillCommand( string _command )
	{
		if (isAlive && charInfo.PresentResourcePoint >= 20f && !skillUsingState) {

			Effect.SetActive (true);
			animator.Play ("Idle");
			destination = this.transform.position;

			switch (_command) {
			case "A":
				if (!bash) {
					skillChainTrigger = false;
					SetState ("Bash");
					skillUsingState = true;
					bash = true;
				}
				break;

			case "S":
				if (!twinRush) {
					skillChainTrigger = false;
					SetState ("TwinRush");
					skillUsingState = true;
					twinRush = true;
				}
				break;

			case "D":
				if (!landCrush) {
					skillChainTrigger = false;
					SetState ("LandCrush");
					skillUsingState = true;
					landCrush = true;
				}
				break;

			case "Skill8":
				if (!kick) {
					skillChainTrigger = false;
					SetState ("Kick");
					skillUsingState = true;
					kick = true;
				}
				break;

			case "Q":
				if (!wheelScythe) {
					skillChainTrigger = false;
					SetState ("WheelScythe");
					skillUsingState = true;
					wheelScythe = true;
				}
				break;

			case "Skill2":
				if (!upperScythe) {
					skillChainTrigger = false;
					SetState ("UpperScythe");
					skillUsingState = true;
					upperScythe = true;
				}
				break;

			case "Skill3":
				if (!crescentCut) {
					skillChainTrigger = false;
					SetState ("CrescentCut");
					skillUsingState = true;
					crescentCut = true;
					//finish = true;
				}
				break;

			}

			if (skillUsingState) {
				skillChainWaitingTime = 0.0f;
				charInfo.PresentResourcePoint -= 20f;
			}

			if (skillingChainCount < 4 && skillUsingState) {
				skillChainWaitingTimeMax = skillChainWaitingTimeMax - 1;
				skillingChainCount++;
			} else if (skillingChainCount >=4 && skillUsingState) {
				if (!finish) {
					skillingChainCount = 4;
				} else {
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
		switch (state) {
		case "Idle":
			presentState = STATE.Idle;
			animator.SetBool ("Idle", true);
			break;

		case "Run":
			presentState = STATE.Run;
			animator.SetBool ("Run", true);
			break;

		case "NormalAttack":
			animator.SetTrigger ("NormalAttack");
			break;

		case "Bash":
			animator.SetTrigger ("Bash");
			break;

		case "TwinRush":
			animator.SetTrigger ("TwinRush");
			break;

		case "CrescentCut":
			animator.SetTrigger ("CrescentCut");
			break;

		case "LandCrush":
			animator.SetTrigger ("LandCrush");
			break;

		case "WheelScythe":
			animator.SetTrigger ("WheelScythe");
			break;

		case "UpperScythe":
			animator.SetTrigger ("UpperScythe");
			break;

		case "Skill_E":
			animator.SetTrigger ("Skill_E");
			break;

		case "Kick":
			animator.SetTrigger ("Kick");
			break;

		case "DemonicScythe":
			if (skillingChainCount >= 4) {
				Effect.SetActive (false);
				animator.SetTrigger ("DemonicScythe");
				this.GetComponent<Animator> ().speed = animatorSpeed;
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