using UnityEngine;
using System.Collections;

public class SkillWeapon : MonoBehaviour
{
	public GameObject character;
	public CharacterFaye faye;
	public CharacterInformation info;
	float skillMoveSpeed = 3.0f;
	bool skillTrigger;
	float damage = 0;
	float skillTime;

	public float _Damage
	{
		get { return damage; }
	}

	// Use this for initialization
	void Start()
	{
		skillTime = 0.0f;
		character = GameObject.FindWithTag( "Player" );
		faye = character.GetComponent<CharacterFaye>();
		info = character.GetComponent<CharacterInformation>();
		transform.forward = character.transform.forward;
	}

	// Update is called once per frame
	void Update()
	{
		skillTrigger = faye.SkillTrigger;
		if (skillTrigger)
		{
			skillTime += Time.deltaTime;
			transform.Translate( transform.forward * Time.deltaTime * skillMoveSpeed, Space.World );
		}
	}

	void OnCollisionStay( Collision coll )
	{
		//IsAttack
		if (skillTime >= 0.2f)
		{
			Debug.Log( damage );
			if (coll.gameObject.layer == LayerMask.NameToLayer( "Enemy" ))
			{
				Monster monsterDamege = coll.gameObject.GetComponent<Monster>();
				damage = info.Damage;
				monsterDamege.HitDamage( damage );
				Camera.main.GetComponent<Shaking>().ShakeCamera( 0.1f );				
			}
			skillTime = 0.0f;
		}
	}
}
