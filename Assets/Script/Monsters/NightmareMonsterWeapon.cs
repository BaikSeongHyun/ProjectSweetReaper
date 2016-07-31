using UnityEngine;
using System.Collections;

public class NightmareMonsterWeapon : MonoBehaviour 
{
	public GameObject nightmareMonster;

	FrogAI nightmareFrog;

	FrogBossAI nightmareBossFrog;

	ThrowFrogAI nightmareThrowFrog;

	CaveBossFrogAI nightmareCaveBossFrog;

	bool attack;

	float damage = 0;

	MonsterHealth info;

	// Use this for initialization
	void Start () 
	{
		info = nightmareMonster.GetComponent<MonsterHealth> ();
		if (nightmareMonster.gameObject.name == "NightmareFrog")
		{
			nightmareFrog = transform.GetComponentInParent<FrogAI> ();	
		}

		else if (nightmareMonster.gameObject.name == "NightmareBossFrog")
		{
			nightmareBossFrog = transform.GetComponentInParent<FrogBossAI> ();	
		}

		else if (nightmareMonster.gameObject.name == "NightmareThrowFrog")
		{
			nightmareThrowFrog = transform.GetComponentInParent<ThrowFrogAI> ();	
		}

		else if (nightmareMonster.gameObject.name == "NightmareCaveBossFrog")
		{
			nightmareCaveBossFrog= transform.GetComponentInParent<CaveBossFrogAI> ();	
		}

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (nightmareMonster.gameObject.name == "NightmareFrog")
		{
			attack = nightmareFrog.IsAttack;
		}
		else if (nightmareMonster.gameObject.name == "NightmareBossFrog")
		{
			attack = nightmareBossFrog.IsAttack;

		}
		else if (nightmareMonster.gameObject.name == "NightmareThrowFrog")
		{
			attack = nightmareThrowFrog.IsAttack;
		}

		else if (nightmareMonster.gameObject.name == "NightmareCaveBossFrog")
		{
			attack = nightmareCaveBossFrog.IsAttack;
		}

	}



	void OnTriggerEnter( Collider coll )
	{

			//IsAttack
			if (coll.gameObject.layer == LayerMask.NameToLayer( "Player" ))
			{
				CharacterFaye fayeObject = coll.gameObject.GetComponent<CharacterFaye>();
				if (fayeObject != null)
				{				
					if (attack)
						damage = info.MonsterDamage;

					if (damage != 0)
						fayeObject.HitDamage( damage );

					damage = 0;				
				}			
			}
		}
}
