using UnityEngine;
using System.Collections;

public class ReturnBase : MonoBehaviour
{
	//main UI
	public UserInterfaceManager mainUI;

	// initialize this script
	void Start()
	{
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
	}

	void OnMouseDown()
	{
		mainUI.ControlExitDungeonPopUp( true );
	}
}
