using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TraningDummy : Monster
{
	public Animator dummyAnimator;
	AnimatorStateInfo dummyState;
	CharacterInformation info;

	//public float[] damegeReport;
	public LinkedList<float> DamageList = new LinkedList<float> ();
	float imageDelayTime;
	public int damagelist = 0;
	//float playerDamage = 0;

	float MonsterHealth;
	bool Attack;

	public float _MonsterHealth {
		get{ return MonsterHealth; }
		set{ MonsterHealth = value; }
	}


	//hp image

	public enum DummyPatternName
	{
		DummyIdle = 1,
		TakeDamage,
		Death}

	;

	// Use this for initialization
	void Start ()
	{
		dummyAnimator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		DummyPattern (DummyPatternName.DummyIdle);
	}



	void Update ()
	{	
		
		//if (searchRange > runRange && searchRange > runRange)
		DummyPattern (DummyPatternName.DummyIdle);

		dummyState = this.dummyAnimator.GetCurrentAnimatorStateInfo (0);

		//set default rotation
		//transform.rotation = new Quaternion(0f, transform.rotation.y, 0f, 0f);
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		transform.LookAt (player.transform.position);

		//update hp

			
	}


	public override void HitDamage (float _Damage)
	{
		Debug.Log ("hit");

		MonsterHealth -= _Damage;
		if (DamageList.Count <= 20) {
			DamageList.AddLast (_Damage);
		} else if (DamageList.Count == 20) {
			DamageList.RemoveFirst ();
			DamageList.AddLast (_Damage);
		}
	}

	public void DummyPattern (DummyPatternName state)
	{
		switch (state) {

		case DummyPatternName.DummyIdle:
			dummyAnimator.SetInteger ("state", 1);
			break;
		case DummyPatternName.TakeDamage:
			dummyAnimator.SetInteger ("state", 2);
			break;
		case DummyPatternName.Death:
			dummyAnimator.SetInteger ("state", 3);
			break;
		}
	}
}



