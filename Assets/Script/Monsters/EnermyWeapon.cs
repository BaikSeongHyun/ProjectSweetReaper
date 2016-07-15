using UnityEngine;
using System.Collections;

public class EnermyWeapon : MonoBehaviour
{
	public GameObject Mob;
	FrogBossAI BossFrog;
	FrogAI Frog;
	bool Attack;
	float damage = 0;
	MonsterHealth Info;
	// Use this for initialization
	void Start()
	{
		Info = Mob.GetComponent<MonsterHealth>();
		if (Mob.gameObject.name == "BossFrog")
			BossFrog = transform.GetComponentInParent<FrogBossAI>();
		else
			Frog = transform.GetComponentInParent<FrogAI>();		
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Mob.gameObject.name == "BossFrog")
			Attack = BossFrog.IsAttack;
		else
			Attack = Frog.IsAttack;
		
	}

	void OnTriggerEnter( Collider coll )
	{
		//IsAttack
		if (coll.gameObject.layer == LayerMask.NameToLayer( "Player" ))
		{
			CharacterFaye fayeObject = coll.gameObject.GetComponent<CharacterFaye>();
			if (fayeObject != null)
			{				
				if (Attack)
					damage = Info.MonsterDamage;
				
				if (damage != 0)
					fayeObject.HitDamage( damage );
				
				damage = 0;				
			}			
		}
	}
}
