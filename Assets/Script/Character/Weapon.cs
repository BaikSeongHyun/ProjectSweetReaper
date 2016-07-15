using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public GameObject character;
	public CharacterFaye faye;
	public CharacterInformation info;
	bool normalAttack;
	bool skillAttack;
	float damage = 0;

	public bool _normalAttack
	{
		get{
			return normalAttack;
		}
	}

	public float _Damage
	{
		get { return damage; }
	}

	public bool _skillAttack
	{
		get{ return skillAttack; }
	}
	// Use this for initialization
	void Start()
	{
		character = GameObject.FindWithTag( "Player" );
		faye = character.GetComponent<CharacterFaye>();
		info = character.GetComponent<CharacterInformation>();
	}
	
	// Update is called once per frame
	void Update()
	{
		normalAttack = faye.NormalAttackState;
		skillAttack = faye.SkillUsingState;
	}

	void OnCollisionEnter( Collision coll )
	{
		//IsAttack
		if (coll.gameObject.layer == LayerMask.NameToLayer( "Enemy" ))
		{

			Monster monsterDamege = coll.gameObject.GetComponent<Monster> ();

			if (monsterDamege != null) 
			{
				if (normalAttack)
				{
					damage = info.Damage;

				} 
				else if (skillAttack)
				{
					damage = info.Damage;
				}
				if (damage != 0)
				{
					monsterDamege.HitDamage (damage);
					damage = 0;
				}
			}




//			FrogBossAI BossAI = coll.gameObject.GetComponent<FrogBossAI>();
//			if (BossAI != null)
//			{
//				if (normalAttack)
//					damage = info.Damage;
//				else if (skillAttack)
//					damage = info.Damage;
//				
//				if (damage != 0)
//				{
//					BossAI.HitDamage( damage );
//					damage = 0;
//				}
//			}
//			else
//			{
//				FrogAI MonsterAI = coll.gameObject.GetComponent<FrogAI>();
//				if (MonsterAI != null)
//				{
//					if (normalAttack)
//						damage = info.Damage;
//					else if (skillAttack)
//						damage = info.Damage;
//					
//					if (damage != 0)
//					{
//						MonsterAI.HitDamage( damage );
//						damage = 0;
//					}
//				}
//			}
		}
	}
}
