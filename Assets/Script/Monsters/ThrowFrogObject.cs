using UnityEngine;
using System.Collections;

public class ThrowFrogObject : MonoBehaviour 
{
	public GameObject Mob;
	public Vector3 target;
	public bool isAttack;
	public float damege;
	MonsterHealth Info;
	// Update is called once per frame

	void Start()
	{
		Info = Mob.GetComponent<MonsterHealth> ();
	}
	void Update () 
	{
		if (isAttack) 
		{
			
			
			transform.position = Vector3.Slerp (transform.position, target, Time.deltaTime * 2f);

		}
			
	}

	public void IsAttackCheck(Vector3 _Player)
	{
		isAttack = true;
		target = _Player;
	}

	void OnCollisionEnter( Collision col )
	{

		if (col.gameObject.layer == LayerMask.NameToLayer( "Player" ))
		{
			

			CharacterFaye fayeObject = col.gameObject.GetComponent<CharacterFaye>();
			damege = Info.MonsterDamage;

			if (damege != 0) 
			{
				fayeObject.HitDamage (damege);
				
			}

		}

		Destroy (this.gameObject);
	}
}
