using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TraningDummy : Monster
{
	public GameObject player;
	public Animator dummyAnimator;
	AnimatorStateInfo dummyState;
	CharacterInformation info;


	float imageDelayTime;
	public int damagelist = 1;
	public float[,] damageArray = new float[19, 2];// damage arraylist

	public float MonsterHealth  = 1000000;
	bool Attack;



	//hp image

	public enum DummyPatternName
	{
		DummyIdle = 1,
		TakeDamage,
		Death}

	;

	// Use this for initialization
	void Start()
	{
		dummyAnimator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag( "Player" );
		DummyPattern( DummyPatternName.DummyIdle );
	}



	void Update()
	{	
		
			//if (searchRange > runRange && searchRange > runRange)
			DummyPattern( DummyPatternName.DummyIdle );

			dummyState = this.dummyAnimator.GetCurrentAnimatorStateInfo( 0 );

			//set default rotation
			//transform.rotation = new Quaternion(0f, transform.rotation.y, 0f, 0f);
			transform.position = new Vector3 (transform.position.x,0,transform.position.z);
			transform.LookAt(player.transform.position );

			//update hp

			
	}

//	public void SetAttackTime()
//	{
//		attackCycle = 0;
//	}
//
//	public override void HitDamage( float _Damage )
//	{
//		Instantiate( hitEffect, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation );
//		Instantiate( hitObject, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation );
//		frogInfo.MonsterHp -= _Damage;
//		dummyAnimator.SetTrigger( "" );
//
//	}
//
	public void DamageArray(float _Damage)
	{
		if(damagelist <20){
		damageArray [damagelist, 2] = _Damage;
			damagelist++;
		}

		else if (damagelist ==20){
			damagelist = 1;
			damageArray [damagelist, 2] = _Damage;
		}
	}
//
//	public void HitDamage(float _damage)
//	{
//		MonsterHealth -= _damage;
//		DamageArray (_damage);
//		dummyAnimator.SetTrigger ("OnDamage");
//		return;
//	}
//
	void OnCollisionEnter( Collision coll )
	{
		//IsAttack
		if (coll.gameObject.layer == LayerMask.NameToLayer( "Weapon" ))
		{
			Debug.Log("1");
			float playerDamage= coll.gameObject.GetComponent<Weapon>()._Damage;
			DamageArray (playerDamage);
			System.Console.WriteLine (damageArray[damagelist,2]	);
		}
	}

	public void DummyPattern( DummyPatternName state )
	{
		switch (state)
		{

		case DummyPatternName.DummyIdle:
			dummyAnimator.SetInteger( "state", 1 );
			break;
		case DummyPatternName.TakeDamage:
			dummyAnimator.SetInteger( "state", 2 );
			break;
		case DummyPatternName.Death:
			dummyAnimator.SetInteger( "state", 3 );
			break;
		}
	}
}



