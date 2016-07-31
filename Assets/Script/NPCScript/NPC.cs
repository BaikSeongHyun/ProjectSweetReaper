using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{
	public GameController mainControl;

	// initialize this script
	void Start()
	{
		mainControl = GameObject.FindWithTag( "GameController" ).GetComponent<GameController>();
	}

	void OnTriggerEnter( Collider coll )
	{
		
	}

	void OnTriggerStay( Collider coll )
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer( "Player" ))
			this.transform.LookAt( coll.gameObject.transform.position, Vector3.up );		
	}

	void OnTriggerExit()
	{
		
	}
}
