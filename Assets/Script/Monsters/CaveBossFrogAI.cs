using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CaveBossFrogAI : Monster
{
	public Animator caveBossFrogAiAnimator;

	AnimatorStateInfo caveBossState;

	public GameObject suicideFrogSummon;

	public bool summonTrigger;

<<<<<<< HEAD
=======
	public int summonCount;

	public GameObject[] SummonFrog;

>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
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
<<<<<<< HEAD

=======
	
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
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
<<<<<<< HEAD

=======
			SummonFrog = GameObject.FindGameObjectsWithTag ("SuicideFrog");
			
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
			float searchRange = Vector3.Distance (player.transform.position, transform.position);
			int summonPattern = Random.Range (0,5);

			if (searchRange < attackRange)
			{
<<<<<<< HEAD
				if (!caveBossState.IsName ("ThrowFrogTakeDamage") && summonPattern == 4)
				{
					caveBossFrogAiAnimator.SetTrigger ("CaveBossSummon");
					//CaveBossFrogPattern (CaveBossFrogPatternName.CaveBossFrogSummon);

					Instantiate (suicideFrogSummon, transform.position + new Vector3 (0f, 10f, 0f), transform.rotation);


				}

				else if (attackCycle >= 5 && !caveBossState.IsName ("ThrowFrogTakeDamage"))
				{
=======
				
				
				if (attackCycle >= 1 && !caveBossState.IsName ("ThrowFrogTakeDamage") )
				{

					if (summonPattern == 4)
					{
						
						SummonSkill ();
					}
					
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237

					CaveBossFrogPattern (CaveBossFrogPatternName.CaveBossFrogAttack);

					attackCycle = 0;
				}
				else
				{
<<<<<<< HEAD

					CaveBossFrogPattern(CaveBossFrogPatternName.CaveBossFrogIdle);


=======
					
					CaveBossFrogPattern(CaveBossFrogPatternName.CaveBossFrogIdle);
				
				
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
				}



			}
			else if (searchRange <= runRange || searchRange <= attackRange)
			{

<<<<<<< HEAD
=======

>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
				CaveBossFrogPattern (CaveBossFrogPatternName.CaveBossFrogRun);
				if (caveBossState.IsName ("CaveBossFrogRun"))
				{
					transform.LookAt (player.transform.position);
					transform.position = Vector3.Lerp (transform.position, player.transform.position, Time.deltaTime * frogBossSpeed);

				}
			}
<<<<<<< HEAD

=======
		
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237

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

<<<<<<< HEAD
=======
	public void SummonSkill()
	{
		int summonPos = Random.Range (1,5);

		if (SummonFrog.Length <= 3)
		{
			 Instantiate (suicideFrogSummon, transform.position + new Vector3 ((1* summonPos), 0f,(1 * summonPos)), transform.rotation);

		}

	}

>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
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
<<<<<<< HEAD
			{            
=======
			{				
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
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
<<<<<<< HEAD
					var gold = Instantiate( dropGold, transform.position, new Quaternion(0, 0, 0, 0) );               
=======
					var gold = Instantiate( dropGold, transform.position, new Quaternion(0, 0, 0, 0) );					
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
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
<<<<<<< HEAD
				caveBossFrogAiAnimator.SetInteger ("state", 1);
=======
			caveBossFrogAiAnimator.SetInteger ("state", 1);
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
				break;


			case CaveBossFrogPatternName.CaveBossFrogRun:
<<<<<<< HEAD
				caveBossFrogAiAnimator.SetInteger ("state", 2);
=======
			caveBossFrogAiAnimator.SetInteger ("state", 2);
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
				break;


			case CaveBossFrogPatternName.CaveBossFrogAttack:
<<<<<<< HEAD
				caveBossFrogAiAnimator.SetInteger ("state", 3);
=======
			caveBossFrogAiAnimator.SetInteger ("state", 3);
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
				isAttack = true;
				break;

			case CaveBossFrogPatternName.CaveBossFrogTakeDamage:
<<<<<<< HEAD
				caveBossFrogAiAnimator.SetInteger ("state", 4);
				break;

			case CaveBossFrogPatternName.CaveBossFrogSummon:
				caveBossFrogAiAnimator.SetInteger ("state", 5);
				break;

			case CaveBossFrogPatternName.CaveBossFrogDeath:
				caveBossFrogAiAnimator.SetInteger ("state", 6);
=======
			caveBossFrogAiAnimator.SetInteger ("state", 4);
				break;
			
			case CaveBossFrogPatternName.CaveBossFrogSummon:
			caveBossFrogAiAnimator.SetInteger ("state", 5);
				break;
		
			case CaveBossFrogPatternName.CaveBossFrogDeath:
			caveBossFrogAiAnimator.SetInteger ("state", 6);
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
				break;

		}

	}

<<<<<<< HEAD
}
=======
}
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
