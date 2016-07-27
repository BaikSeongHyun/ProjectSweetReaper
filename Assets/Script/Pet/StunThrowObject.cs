using UnityEngine;
using System.Collections;

public class StunThrowObject : MonoBehaviour
{
	public Vector3 target;
	public float moveSpeed;
	public bool chase;
	float stunTime;

	void Start()
	{
		chase = false;
	}


	// Update is called once per frame
	void Update()
	{
		if(chase)
			transform.Translate( target * Time.deltaTime * moveSpeed );
	}

	public void SetTarget(Vector3 _target, float _stunTime)
	{
		target = _target;
		stunTime = _stunTime;
		moveSpeed = 2f;
		chase = true;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag( "Pet" ))
		{
			col.gameObject.GetComponent<Pet>().PetFrogHitDamege( stunTime );
			Destroy( this.gameObject );
		}
	}
}
