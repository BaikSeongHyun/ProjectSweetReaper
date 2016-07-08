using UnityEngine;
using System.Collections;

public class EnermyWeapon : MonoBehaviour {
	public GameObject Mob;
	FrogBossAI BossFrog;
	FrogAI Frog;
	bool Attack;
	float damage=0;
	FrogHealth Info;
	// Use this for initialization
	void Start () {
		Info = Mob.GetComponent<FrogHealth> ();
		if (Mob.gameObject.name == "BossFrog") {
			BossFrog = transform.GetComponentInParent<FrogBossAI> ();
		} else {
			Frog = transform.GetComponentInParent<FrogAI> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Mob.gameObject.name == "BossFrog") {
			Attack = BossFrog._IsAttack;
		} else {
			Attack = Frog._IsAttack;
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		//IsAttack
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			Debug.Log (Attack);
			CharacterFaye fayeObject = coll.gameObject.GetComponent<CharacterFaye> ();
			if (fayeObject != null) {
				Debug.Log ("fayeObject");
				if (Attack) {
					damage = Info.frogBossDamage;
				}
				if (damage != 0) {
					fayeObject.HitDamage (damage);
					damage = 0;
				}
				return;
			}
			//if he ==0; deathAni call
		}
	}
}
