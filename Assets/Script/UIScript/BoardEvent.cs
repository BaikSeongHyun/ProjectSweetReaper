using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoardEvent : MonoBehaviour
{
	//board PopUpImage
	public Image boardQuest;

	public UserInterfaceManager mainUI;


	// initialize this script
	void Start()
	{
		boardQuest = transform.Find( "BoardCanvas" ).Find( "BoardClickEvent" ).GetComponent<Image>();
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();

		ControlBoardImage( false );
	}

	public void ControlBoardImage( bool state )
	{
		boardQuest.enabled = state;
	}

	void OnMouseEnter()
	{
		ControlBoardImage( true );	
	}


	void OnMouseExit()
	{
		ControlBoardImage( false );
	}

	void OnMouseDown()
	{
		if (!mainUI.OnEnterDungeon)
		{
			ControlBoardImage( false );
			mainUI.ControlEnterDungeon( true );			
		} 
	}
}
