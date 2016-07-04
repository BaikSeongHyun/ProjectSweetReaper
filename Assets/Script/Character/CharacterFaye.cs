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
	int skillingChainCount=0;
	float skillChainWaitingTime=0.0f;
	float skillChaintWaitingTimeMax=4.0f;
	bool skillChainTrigger=false;
	bool skillusingState=false;
	//State Event
	public enum STATE
	{
		Default,
		Idle,
		Run}

	;

	public void Start ()
	{
		SkillChainProgressBar.gameObject.SetActive (false);
		destination = this.transform.position;
		animator = GetComponent<Animator> ();
	}

<<<<<<< HEAD
	void Update ()
=======
	void Update()
>>>>>>> 2f13fb3a30f2e2c3cf3234623c2b038aac13ed0e
	{
		if (skillChainTrigger == true) {
			//skillChaintWaitingTimeMax=4.0f (Default)
			if (skillChainWaitingTime >= skillChaintWaitingTimeMax) {
				skillingChainCount = 0;
				skillChainWaitingTime = 0.0f;
				skillChaintWaitingTimeMax = 4.0f;
				skillChainTrigger = false;
				SkillChainProgressBar.gameObject.SetActive (false);
			} else {
				SkillChainProgressBar.gameObject.SetActive (true);
				skillChainWaitingTime += Time.deltaTime;
				SkillChainProgressBar.fillAmount = 1 - (skillChainWaitingTime / skillChaintWaitingTimeMax);
			}
		}
		//fixed Y
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		Move ();
	}

<<<<<<< HEAD
	public void skillCommand (string _command)
=======
	public void ChainTrigger(){
		skillChainTrigger = true;
		skillusingState = false;
	}

	public void skillCommand( string _command )
>>>>>>> 2f13fb3a30f2e2c3cf3234623c2b038aac13ed0e
	{
		if (_command != "Evation") {
			skillChainTrigger = false;
			skillChaintWaitingTimeMax = skillChaintWaitingTimeMax - skillingChainCount;
			if (skillingChainCount >= 4) {
				skillingChainCount = 0;
			}
			skillChainWaitingTime = 0.0f;
		}
		Effect.SetActive (true);
		animator.Play ("Idle");
		destination = this.transform.position;
		switch (_command) {
		case "A":
<<<<<<< HEAD
			SetState ("Skill_A");
			break;
		case "S":
			SetState ("Skill_S");
			break;
		case "D":
			SetState ("Skill_D");
			break;
		case "Q":
			SetState ("Skill_Q");
=======
			skillingChainCount++;
			SetState ("Skill_A");
			skillusingState = true;
			break;
		case "S":
			skillingChainCount++;
			SetState ("Skill_S");
			skillusingState = true;
			break;
		case "D":
			skillingChainCount++;
			SetState ("Skill_D");
			skillusingState = true;
			break;
		case "Q":
			skillingChainCount++;
			SetState ("Skill_Q");
			skillusingState = true;
>>>>>>> 2f13fb3a30f2e2c3cf3234623c2b038aac13ed0e
			break;
		case "Evation":
			SetState ("Evation");
			break;
		}
	}

	public Vector3 _destinaton {
		get {
			return destination;
		}set {
			destination = value;
		}
	}

	public void Attack ()
	{
		Effect.SetActive (false);
		destination = this.transform.position;
		SetState ("NormalAttack");

	}

<<<<<<< HEAD
	void Move ()
	{
		attackState = this.animator.GetCurrentAnimatorStateInfo (0);
		if (attackState.IsName ("Evation")) {
			//Effect.SetActive (false);
			transform.Translate (transform.forward * Time.deltaTime * moveSpeed, Space.World);
			destination = this.transform.position;
		}
		if (attackState.IsName ("NormalAttack") && Vector3.Distance (transform.position, destination) >= 0.1f) {
			animator.Play ("Idle");
		}
		if (Vector3.Distance (destination, transform.position) <= 0.1f) {
=======
	void Move()
	{
		if (skillusingState == true) {
>>>>>>> 2f13fb3a30f2e2c3cf3234623c2b038aac13ed0e
			SetState ("Idle");
		} else {
			attackState = this.animator.GetCurrentAnimatorStateInfo (0);
			if (attackState.IsName ("Evation")) {
				Effect.SetActive (false);
				transform.Translate (transform.forward * Time.deltaTime * moveSpeed, Space.World);
				destination = this.transform.position;
			}
			if (attackState.IsName ("NormalAttack") && Vector3.Distance (transform.position, destination) >= 0.1f) {
				animator.Play ("Idle");
			}
			if (Vector3.Distance (destination, transform.position) <= 0.1f) {
				SetState ("Idle");
			} else {
				SetState ("Run");
				if (attackState.IsName ("Run")) {
					//Effect.SetActive (false);
					Vector3 direction = destination - this.transform.position;
					this.transform.LookAt (destination);
					direction.Normalize ();
					transform.Translate (direction * Time.deltaTime * moveSpeed, Space.World);
				}
			}
		}
	}

	void SetStateDefault ()
	{
		animator.SetBool ("Idle", false);
		animator.SetBool ("Run", false);
	}
		
	//property
	public STATE State {
		get { return presentState; }
	}


	// method
	public void SetState (string state)
	{
		SetStateDefault ();
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
		case "Skill_A":
			animator.SetTrigger ("Skill_A");
			break;

		case "Skill_S":
			animator.SetTrigger ("Skill_S");
			break;

		case "Skill_D":
			animator.SetTrigger ("Skill_D");
			break;

		case "Skill_Q":
			animator.SetTrigger ("Skill_Q");
			break;
		case "Evation":
			animator.SetTrigger ("Evation");
			break;
		}
	}

	void OnCollistionEnter (Collision Coll)
	{
		if (Coll.gameObject) {
		}
	}
}
