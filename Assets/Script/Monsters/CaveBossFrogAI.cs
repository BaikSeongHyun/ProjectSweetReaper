using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CaveBossFrogAI : Monster
{
	public Animator caveBossFrogAiAnimator;

	AnimatorStateInfo caveBossState;

	public GameObject suicideFrogSummon;

	public bool summonTrigger;

	public enum CaveBossFrogPatternName
	{
		CaveBossFrogIdle =1,
		CaveBossFrogRun,
		CaveBossFrogAttack,
		CaveBossFrogTakeDamage,
		CaveBossFrogSummon,
		CaveBossFrogDeath
	};



	// Use this for initialization
	void Start () 
	{
		frogInfo = this.GetComponent<MonsterHealth> ();
		caveBossFrogAiAnimator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");

		health = transform.Find ("CaveBossFrogHpBar").GetComponent<Image> ();

	}

	public void SummonTrigger()
	{
		summonTrigger = true;
	}
	// Update is called once per frame
	void Update () 
	{
		attackCycle += Time.deltaTime;
		if (isAlive)
		{

			float searchRange = Vector3.Distance (player.transform.position, transform.position);
			int summonPattern = Random.Range (0,5);

			if (searchRange < attackRange)
			{
				if (!caveBossState.IsName ("ThrowFrogTakeDamage") && summonPattern == 4)
				{
					caveBossFrogAiAnimator.SetTrigger ("CaveBossSummon");
					//CaveBossFrogPattern (CaveBossFrogPatternName.CaveBossFrogSummon);

					Instantiate (suicideFrogSummon, transform.position + new Vector3 (0f, 10f, 0f), transform.rotation);


				}

				else if (attackCycle >= 5 && !caveBossState.IsName ("ThrowFrogTakeDamage"))
				{

					CaveBossFrogPattern (CaveBossFrogPatternName.CaveBossFrogAttack);

					attackCycle = 0;
				}
				else
				{

					CaveBossFrogPattern(CaveBossFrogPatternName.CaveBossFrogIdle);


				}



			}
			else if (searchRange <= runRange || searchRange <= attackRange)
			{

				CaveBossFrogPattern (CaveBossFrogPatternName.CaveBossFrogRun);
				if (caveBossState.IsName ("CaveBossFrogRun"))
				{
					transform.LookAt (player.transform.position);
					transform.position = Vector3.Lerp (transform.position, player.transform.position, Time.deltaTime * frogBossSpeed);

				}
			}


			if (searchRange > runRange)
				CaveBossFrogPattern (CaveBossFrogPatternName.CaveBossFrogIdle);
			caveBossState = this.caveBossFrogAiAnimator.GetCurrentAnimatorStateInfo (0);

			transform.rotation = new Quaternion (0f, transform.rotation.y, 0f, 0f);
			transform.position = new Vector3 (transform.position.x, 0f, transform.position.z);
			transform.LookAt (player.transform.position);

			//update hp
			health.fillAmount = frogInfo.FillFrogHp;
			RotateHealthBar ();
		}

	}

	public void SetAttackTime()
	{
		attackCycle = 0;
	}

	public override void HitDamage( float _Damage )
	{
		if (isAlive)
		{
			frogInfo.MonsterHp -= _Damage;
			if (frogInfo.MonsterHp > 0)
			{
				caveBossFrogAiAnimator.SetTrigger ("MonsterHitTrigger");
				//bossAiAnimator.SetTrigger( "MonsterHitTrigger" );
				return;
			}

			if (frogInfo.MonsterHp <= 0)
			{            
				health.fillAmount = 0;
				int randomItem = Random.Range( 0, 3 );

				if (randomItem == 0)
				{
					var item = Instantiate( dropItem, transform.position, new Quaternion(0, 0, 0, 0) );
					item.name = "DropItem";
				}
				else if (randomItem == 1)
				{
					var gold = Instantiate( dropGold, transform.position, new Quaternion(0, 0, 0, 0) );
					gold.name = "DropGold";
				}
				else
				{
					var item = Instantiate( dropItem, transform.position, new Quaternion(0, 0, 0, 0) );
					item.name = "DropItem";
					var gold = Instantiate( dropGold, transform.position, new Quaternion(0, 0, 0, 0) );               
					gold.name = "DropGold";
				}

				caveBossFrogAiAnimator.SetTrigger( "MonsterDie" );
				isAlive = false;
				Destroy( this.gameObject, 3.0f );
				return;
			}
		}
	}

	public void CaveBossFrogPattern(CaveBossFrogPatternName state)
	{
		switch (state)
		{
			case CaveBossFrogPatternName.CaveBossFrogIdle:
				caveBossFrogAiAnimator.SetInteger ("state", 1);
				break;


			case CaveBossFrogPatternName.CaveBossFrogRun:
				caveBossFrogAiAnimator.SetInteger ("state", 2);
				break;


			case CaveBossFrogPatternName.CaveBossFrogAttack:
				caveBossFrogAiAnimator.SetInteger ("state", 3);
				isAttack = true;
				break;

			case CaveBossFrogPatternName.CaveBossFrogTakeDamage:
				caveBossFrogAiAnimator.SetInteger ("state", 4);
				break;

			case CaveBossFrogPatternName.CaveBossFrogSummon:
				caveBossFrogAiAnimator.SetInteger ("state", 5);
				break;

			case CaveBossFrogPatternName.CaveBossFrogDeath:
				caveBossFrogAiAnimator.SetInteger ("state", 6);
				break;

		}

	}

}