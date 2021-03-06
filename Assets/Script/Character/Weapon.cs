﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public GameObject character;
	public CharacterFaye faye;
	public CharacterInformation info;
	bool normalAttack;
	bool skillAttack;
	float damage = 0;
	public AudioClip hit;
	AudioSource hitSound;
	bool soundTrigger = false;
	float soundTime = 0.0f;

	public bool NormalAttack
	{
		get{ return normalAttack; }
	}

	public float Damage
	{
		get { return damage; }
	}

	public bool SkillAttack
	{
		get{ return skillAttack; }
	}
	// Use this for initialization
	void Start()
	{
		hitSound = GetComponent<AudioSource>();
		character = GameObject.FindWithTag( "Player" );
		faye = character.GetComponent<CharacterFaye>();
		info = character.GetComponent<CharacterInformation>();
	}
	
	// Update is called once per frame
	void Update()
	{
		normalAttack = faye.NormalAttackState;
		skillAttack = faye.SkillUsingState;
		if (soundTrigger)
		{
			soundTime += Time.unscaledDeltaTime;
			if (soundTime >= 0.5f)
			{
				soundTrigger = false;
				soundTime = 0.0f;
			}
		}
	}

	void OnCollisionEnter( Collision coll )
	{

		//IsAttack
		if (coll.gameObject.layer == LayerMask.NameToLayer( "Enemy" ))
		{

			Monster monsterDamege = coll.gameObject.GetComponent<Monster>();
			if (monsterDamege != null)
			{
				if (normalAttack)
					damage = info.Damage * faye.PercentDamage;
				else if (skillAttack)
					damage = info.Damage * faye.PercentDamage;
				Debug.Log( damage );
				
				if (damage != 0)
				{
					monsterDamege.HitDamage( damage );
					damage = 0;
					Camera.main.GetComponent<Shaking>().ShakeCamera( 0.1f );
					if (!soundTrigger)
					{
						hitSound.PlayOneShot( hit );
						soundTrigger = true;
					}
				}
			}
			else
			{
				Nightmare nightmare = coll.gameObject.GetComponent<Nightmare>();
				if (nightmare != null)
				{
					if (normalAttack)
						damage = info.Damage;
					else if (skillAttack)
						damage = info.Damage;
					
					if (damage != 0)
					{
						nightmare.HitDamage( damage );
						damage = 0;
						Camera.main.GetComponent<Shaking>().ShakeCamera( 0.1f );
						if (!soundTrigger)
						{
							hitSound.PlayOneShot( hit );
							soundTrigger = true;
						}
					}
				}
			}
		}
	}
}
