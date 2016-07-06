using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public GameObject character;
	public CharacterFaye faye;
	public CharacterInformation info;
	bool normalAttack;
	bool skillAttack;
	float damage=30;

	public bool _normalAttack{
		get{
			return normalAttack;
		}
	}

	public float _Damage {
		get { return damage; }
	}

	public bool _skillAttack{
		get{ return skillAttack;}
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
		normalAttack = faye._normalAttackState;
		skillAttack = faye._skillusingState;
	}

	void OnCollisionEnter( Collision Coll )
	{
		if (Coll.gameObject.layer == 12)
		{
			if (faye._skillusingState || faye._normalAttackState)
			{
				Debug.Log( "Hit" );
				//DAMAGE
			}
			else
			{
				Debug.Log( "Coll" );
			}
		}
	}
}
