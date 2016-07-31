using UnityEngine;
using System.Collections;

public class FrogBombObject : MonoBehaviour
{
	public float damege;

	void OnCollisionEnter( Collision col )
	{
		if (col.gameObject.layer == LayerMask.NameToLayer( "Player" ))
		{
			CharacterFaye fayeObject = col.gameObject.GetComponent<CharacterFaye>();
			if (damege != 0)
				fayeObject.HitDamage( damege );
		}
	}

	public void BombDamege( float _Damege )
	{
		damege = _Damege;
	}
}