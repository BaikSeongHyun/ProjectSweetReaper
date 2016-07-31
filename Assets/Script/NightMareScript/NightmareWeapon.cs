using UnityEngine;
using System.Collections;

public class NightmareWeapon : MonoBehaviour
{
	public GameObject Mob;
	nightMare nightmareAI;
	bool Attack;
	float damage = 0;
	MonsterHealth Info;
	// Use this for initialization
	void Start()
	{
		nightmareAI = Mob.GetComponent<nightMare> ();
		Info = Mob.GetComponent<MonsterHealth>();

	}
	
	// Update is called once per frame
	void Update()
	{
		if (nightmareAI.IsAttack) {
			Attack = true;
		} else {
			Attack = false;
		}
		Debug.Log (nightmareAI.IsAttack);
	}

	void OnTriggerEnter( Collider coll )
	{
		//IsAttack
		if (coll.gameObject.layer == LayerMask.NameToLayer( "Player" ))
		{
			if (Attack) {
				damage = Info.MonsterDamage;
				coll.gameObject.SendMessage ("HitDamage", damage);
			} else {
				damage = 0;
			}
		}
	}
}
