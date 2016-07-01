using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GameController : MonoBehaviour
{

	//simple data field
	public bool mouseModeUI;

	//complex data field
	public CharacterFaye faye;
	public UserInterfaceManager mainUI;
	public CharacterInformation info;

	// initialize this script
	void Start( )
	{
		faye = GameObject.FindWithTag( "Player" ).GetComponent<CharacterFaye>();
		info = GameObject.FindWithTag( "Player" ).GetComponent<CharacterInformation>();
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
	}
	
	// Update is called once per frame
	void Update( )
	{
		//charaecter section
		if (Input.GetMouseButton( 0 ))
			MakeMovePoint();
		
		//ui section
		//always update
		mainUI.UpdateQuickStatus();

		if (Input.GetKeyDown( KeyCode.C ))
			mainUI.ControlStatusUI( !mainUI.OnStatusUI );

		if (Input.GetKeyDown( KeyCode.I ))
			mainUI.ControlInventory( !mainUI.OnInventory );

		if (Input.GetKeyDown( KeyCode.Escape ))
			mainUI.ClearUI();
	}

	//another method

	//set destination for player
	void MakeMovePoint( )
	{
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			mainUI.ClearUI();
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hitInfo;

			if (Physics.Raycast( ray, out hitInfo, Mathf.Infinity, 1 << LayerMask.NameToLayer( "Terrain" ) ))
			{
				faye._destinaton = hitInfo.point;
			}
		}
	}
}
