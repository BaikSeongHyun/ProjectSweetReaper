using UnityEngine;
using System.Collections;

public class StunThrowObject : MonoBehaviour
{
	public Transform target;
	public bool chase;
	public float stunTime;

	// Update is called once per frame
	void Update()
	{
		if (chase)
			transform.position = Vector3.Slerp( transform.position, target.position + new Vector3(0f, 1f, 2f), Time.deltaTime * 4f );
	}

	public void SetTarget( Transform _target, float _stunTime )
	{
		chase = true;
		target = _target;
		stunTime = _stunTime;
	}

	void OnCollisionEnter( Collision col )
	{
		if (col.gameObject.CompareTag( "Pet" ))
			col.gameObject.GetComponent<Pet>().PetFrogHitDamege( stunTime );
		

		Destroy( this.gameObject );
	}
}
