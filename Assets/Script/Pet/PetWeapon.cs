using UnityEngine;
using System.Collections;

public class PetWeapon : MonoBehaviour 
{
	public GameObject pet;
	float petDamege = 0;
	Pet NPCPet;
	public bool petAttack;
	PetHealth petInfo;


	public float _PetDamage
	{
		get { return petDamege; }
	}

	// Use this for initialization
	void Start ()
	{
		petInfo = pet.GetComponent<PetHealth>();

		if (pet.gameObject.tag == "Pet")
			NPCPet = transform.GetComponentInParent<Pet> ();
	}

	void Update()
	{

		petAttack = NPCPet.petIsAttack;
			


	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.CompareTag("Pet"))
		{
			Pet petObject = coll.gameObject.GetComponent<NPCFrogPet> ();
	
			if (petObject != null) 
			{
				if (petAttack) 
				{
					petDamege = petInfo.PetDamage;
				}

				if (petDamege != 0) 
				{
					petObject.PetFrogHitDamege (petDamege);



				}

				petDamege = 0;
			}

		}

	}
}
