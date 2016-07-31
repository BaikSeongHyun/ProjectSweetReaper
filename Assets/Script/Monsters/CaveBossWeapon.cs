using UnityEngine;
using System.Collections;

public class CaveBossWeapon : MonoBehaviour {

	public GameObject caveBoss;
	CaveBossFrogAI caveBossAI;

	bool attack;

	float damage = 0;

	MonsterHealth info;
	// Use this for initialization
	void Start () 
	{
<<<<<<< HEAD
		info = caveBoss.GetComponent<MonsterHealth> ();

		if (caveBoss.gameObject.name == "CaveBossFrog")
			caveBossAI = transform.GetComponent<CaveBossFrogAI> ();	
=======
		
		info = caveBoss.GetComponent<MonsterHealth> ();
		if (caveBoss.gameObject.name == "CaveBossFrog")
		{
			caveBossAI = transform.GetComponentInParent<CaveBossFrogAI> ();	
		}
					
	
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
	}
	
	// Update is called once per frame
	void Update () 
	{
<<<<<<< HEAD
		if (caveBoss.gameObject.name == "CaveBossFrog") 
		{
			attack = true;
			Debug.Log (attack);
=======


		if (caveBoss.gameObject.name == "CaveBossFrog") 
		{
			attack = caveBossAI.IsAttack;		
>>>>>>> 8f14c018e8fb2c2bd513c39e114fe68906259237
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
