using UnityEngine;
using System.Collections;

public class nightMare : MonoBehaviour {

	GameObject player;
	Animator nightmareAnimator;
	public GameObject hitEffect;
	float moveSpeed=3.0f;
	float distance;
	float stateTime = 0.0f;
	bool hitTrigger = false;
	bool isAttack = false;
	bool isAlive=true;
	MonsterHealth Info;
	public BoxCollider Hit;
	AnimatorStateInfo attackState;

	//finish
	public GameObject finishSkillEffect;
	public GameObject skillEffect;
	bool useDemonicCyclone = false;
	bool useSpecialActive=false;
	int finishSkillcount = 0;
	float animatorSpeed = 0.6f;

	public bool IsAttack{
		get{
			return isAttack;
		}
	}
	// Use this for initialization
	void Start () {
		Info = this.GetComponent<MonsterHealth>();
		Hit.size = new Vector3(0,0,0);
		player = GameObject.Find("Faye");
		nightmareAnimator = GetComponent<Animator> ();
		nightmareAnimator.speed = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive) {
			UseSpecialActive();
			ProcessTime ();
			Process ();
		}
	}

	public void ChainTrigger(){
		isAttack = false;
		Hit.size = new Vector3 (0, 0, 0);
	}
	public void ProcessTime(){
		if (hitTrigger) {
			stateTime += Time.deltaTime;
			if (stateTime >= 2.0f) {
				hitTrigger = false;
				stateTime = 0.0f;
			}
		}
	}

	public void HitDamage( float _damage )
	{
		if (isAlive) {
			Instantiate( hitEffect, new Vector3 ( transform.position.x, transform.position.y + 1, transform.position.z ), transform.rotation );
			Info.MonsterHp -= _damage;
			if (Info.MonsterHp > 0) {
				Hit.size = new Vector3(0,0,0);
				nightmareAnimator.SetTrigger ("PlayerHitTrigger");
				stateTime = 0.0f;
				return;		
			}

			if (Info.MonsterHp <= 0) {
				Hit.size = new Vector3(0,0,0);
				nightmareAnimator.SetTrigger ("PlayerDie");
				isAlive = false;
			}
		}
	}

	public void UseSpecialActive()
	{
		if (useDemonicCyclone)
		{
			if (finishSkillcount == 0) {
				nightmareAnimator.speed = animatorSpeed;
			}

			if (finishSkillcount == 1 && !isAttack)
			{
				Instantiate( finishSkillEffect, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation );
				skillEffect.name = "DemonicScythe";
			}

			if (finishSkillcount == 9 && !isAttack)
			{
				nightmareAnimator.speed= 1.5f;
				isAttack = true;
			}

			if (finishSkillcount < 9 && !isAttack)
			{
				Debug.Log (animatorSpeed);
				animatorSpeed = animatorSpeed + 0.4f;
				nightmareAnimator.speed = animatorSpeed;
				finishSkillcount++;
				isAttack = true;
			}
		}
	}

	public void AfterDemonicCyclone()
	{
		useDemonicCyclone = false;
		finishSkillcount = 0;
		animatorSpeed = 0.6f;
	}

	public void ScytheSoundEffect(){
	}

	public void Process(){
		distance = Vector3.Distance (transform.position, player.transform.position);
		//Run
		if (distance >= 2f) {
			transform.LookAt (player.transform);
			nightmareAnimator.SetBool ("Run",true);
			transform.Translate (transform.forward * Time.deltaTime * moveSpeed, Space.World);
		}
		//Attack
		else {
			nightmareAnimator.SetBool ("Run",false);
			attackState = this.nightmareAnimator.GetCurrentAnimatorStateInfo( 0 );
			int nightMareState = Random.Range (0, 5);

			if (nightMareState == 0 && !hitTrigger) {
				nightmareAnimator.SetTrigger ("Bash");
				isAttack = true;
				hitTrigger = true;
				Hit.size = new Vector3 (0.5f, 1.5f, 1f);
			} else if (nightMareState == 1 && !hitTrigger) {
				nightmareAnimator.SetTrigger ("UpperScythe");
				isAttack = true;
				hitTrigger = true;
				Hit.size = new Vector3 (0.5f, 1.5f, 1f);
			} else if (nightMareState == 2 && !hitTrigger) {
				nightmareAnimator.SetTrigger ("TwinRush");
				isAttack = true;
				hitTrigger = true;
				Hit.size = new Vector3 (0.5f, 1.5f, 1f);
			} else if (nightMareState == 3 && !hitTrigger) {
				nightmareAnimator.SetTrigger ("CrescentCut");
				isAttack = true;
				hitTrigger = true;
				Hit.size = new Vector3 (0.5f, 1.5f, 1f);
			}else if (nightMareState == 4 && !hitTrigger) {
				nightmareAnimator.SetTrigger ("WheelScythe");
				isAttack = true;
				hitTrigger = true;
				Hit.size = new Vector3 (0.5f, 1.5f, 1f);
			}else if (nightMareState == 5 && !hitTrigger) {
				if (!useSpecialActive) {
					finishSkillcount = 0;
					nightmareAnimator.SetTrigger ("DemonicCyclone");
					useSpecialActive = true;
					isAttack = true;
				}
				hitTrigger = true;
				Hit.size = new Vector3 (0.5f, 1.5f, 1f);
			}
		}
	}
}
