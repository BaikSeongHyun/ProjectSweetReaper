using UnityEngine;
using System.Collections;

public class FrogBombObject : MonoBehaviour 
{
	
	public float damege;

	// Use this for initialization


	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionStay( Collision col )
	{
		if (col.gameObject.layer == LayerMask.NameToLayer( "Player" ))
		{


			CharacterFaye fayeObject = col.gameObject.GetComponent<CharacterFaye>();

			if (damege != 0) 
			{
				fayeObject.HitDamage (damege);

			}

		}

	}

	public void BombDamege(float _Damege)
	{
		damege = _Damege;
		
	}


}
