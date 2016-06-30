using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoardEvent : MonoBehaviour {


	public Image boardQuest;//board PopUpImage
	public UserInterfaceManager ui;


	// Use this for initialization
	void Start () 
	{
		boardQuest = transform.Find ("BoardCanvas").Find ("BoardClickEvent").GetComponent<Image>();
		ui = GameObject.FindWithTag ("MainUI").GetComponent<UserInterfaceManager> ();

		ControlBoardImage (false);
	}

	public void ControlBoardImage(bool state)
	{
		boardQuest.enabled = state;
	}

	void OnMouseEnter()
	{
		ControlBoardImage (true);	

	}


	void OnMouseExit()
	{
		ControlBoardImage (false);

	}
	void OnMouseDown()
	{
		if (!ui.OnEnterDungeon)
		{
			ControlBoardImage (false);
			ui.ControlEnterDungeon (true);

			
		} 

	}


}
