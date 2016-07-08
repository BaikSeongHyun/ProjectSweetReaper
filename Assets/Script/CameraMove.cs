using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	GameObject faya;
	Vector3 cameraDistance;

	// initialize this script
	void Start()
	{
		faya = GameObject.FindWithTag( "Player" );	
		cameraDistance = new Vector3 ( 0f, 7.5f, -6f );
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.Lerp( transform.position, faya.transform.position + cameraDistance, Time.deltaTime * 20 );
	}
}
