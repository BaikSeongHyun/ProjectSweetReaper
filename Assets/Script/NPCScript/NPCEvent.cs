using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCEvent : MonoBehaviour
{
	//board PopUpImage
	public Image boardQuest;

	public UserInterfaceManager mainUI;


	// initialize this script
	void Start()
	{
		//boardQuest = transform.Find( "NPCCanvas" ).Find( "NPCUI" ).GetComponent<Image>();
		//mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();

		ControlBoardImage( true);
	}

	public void ControlBoardImage( bool state )
	{
		boardQuest.enabled = state;
	}

	void OnTriggerEnter(Collider coll){
		ControlBoardImage( true );

	}

	/*
	void OnMouseEnter()
	{
		ControlBoardImage( true );	
	}


	void OnMouseExit()
	{
		ControlBoardImage( false );
	}
*/
	void OnMouseDown()
	{
	}
}
