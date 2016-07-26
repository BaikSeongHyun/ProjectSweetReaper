using UnityEngine;
using System.Collections;

public class PetWeapon : MonoBehaviour 
{
	public Pet root;
	float petDamege = 0;
	public bool petAttack;
	PetHealth petInfo;


	public float _PetDamage
	{
		get { return petDamege; }
	}

	// Use this for initialization
	void Start ()
	{
		root = transform.GetComponentInParent<Pet> ();
	}

	void Update()
	{
		petAttack = root.petIsAttack;
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.CompareTag("Pet") && root.PetIsAttack)
		{
			Pet temp = coll.gameObject.GetComponent<Pet>();
			if(!temp.IsStun)
				temp.PetFrogHitDamege( root.petInfo.PetStunTime );
		}
	}
}
