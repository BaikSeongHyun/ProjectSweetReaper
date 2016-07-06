using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public GameObject character;
	public CharacterFaye faye;
	public CharacterInformation info;
	// Use this for initialization
	void Start () {
		character = GameObject.FindWithTag ("Player");
		faye = character.GetComponent<CharacterFaye> ();
		info = character.GetComponent<CharacterInformation> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter( Collision Coll )
	{
		if (Coll.gameObject.layer == 12) {
			if (faye._skillusingState || faye._normalAttackState) {
				Debug.Log ("Hit");
				//DAMAGE
			} else {
				Debug.Log ("Coll");
			}
		}
	}
}
