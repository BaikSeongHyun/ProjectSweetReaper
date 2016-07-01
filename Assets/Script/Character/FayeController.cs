using UnityEngine;
using System.Collections;

public class FayeController : MonoBehaviour
{

	public CharacterFaye faye;
	public UserInterfaceManager uI;

	void Start( )
	{
		faye = GetComponent<CharacterFaye>();
		uI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
	}



	void MakeMovePoint( )
	{
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit Hit;

		//Ray
		if (Physics.Raycast( ray, out Hit, Mathf.Infinity, 1 << LayerMask.NameToLayer( "Terrain" ) ))
		{
			faye._destinaton = Hit.point;
		}
	}

	// Update is called once per frame
	void Update( )
	{
		if (Input.GetMouseButtonDown( 1 ))
		{
			faye.Attack();
		}
		else if (Input.GetKeyDown( KeyCode.A ))
		{
			faye.skillCommand( "A" );
		}
		else if (Input.GetKeyDown( KeyCode.S ))
		{
			faye.skillCommand( "S" );
		}
		else if (Input.GetKeyDown( KeyCode.D ))
		{
			faye.skillCommand( "D" );
		}
		else if (Input.GetKeyDown( KeyCode.Q ))
		{
			faye.skillCommand( "Q" );
		}
		else if (Input.GetKeyDown( KeyCode.LeftControl ))
		{
			faye.skillCommand( "Evation" );
		}
		else if (Input.GetMouseButton( 0 ))
		{
			MakeMovePoint();
		}
	}


}