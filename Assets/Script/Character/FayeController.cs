using UnityEngine;
using System.Collections;

public class FayeController : MonoBehaviour
{

	public CharacterFaye faye;
	public UserInterfaceManager uI;
	
	// initialize this script
	void Start()
	{
		faye = GetComponent<CharacterFaye>();
		uI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
	}

	void MakeMovePoint()
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
	void Update()
	{
		if (Input.GetMouseButtonDown( 1 ))
		{
			faye.Attack();
		}
		else if (Input.GetKeyDown( KeyCode.A ))
		{
			faye.SkillCommand( "A" );
		}
		else if (Input.GetKeyDown( KeyCode.S ))
		{
			faye.SkillCommand( "S" );
		}
		else if (Input.GetKeyDown( KeyCode.D ))
		{
			faye.SkillCommand( "D" );
		}
		else if (Input.GetKeyDown( KeyCode.Q ))
		{
			faye.SkillCommand( "Q" );
		}
		else if (Input.GetKeyDown( KeyCode.LeftControl ))
		{
			faye.SkillCommand( "Evation" );
		}
		else if (Input.GetMouseButton( 0 ))
		{
			MakeMovePoint();
		}
	}


}