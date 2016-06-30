using UnityEngine;
using System.Collections;

public class UserInterfaceManager : MonoBehaviour
{
	//child UI
	public GameObject inventory;
	public GameObject skillUI;
	public GameObject statusUI;
	public GameObject enterDungeon;

	//initialize this script
	void Start( )
	{
		inventory = GameObject.Find( "Inventory" );
		skillUI = GameObject.Find( "SkillUI" );
		statusUI = GameObject.Find( "StatusUI" );
		enterDungeon = GameObject.Find( "EnterDungeon" );


		ControlInventory( false );
		ControlSkillUI( false );
		ControlStatusUI( false );
		ControlEnterDungeon( false );
	}

	//property
	public bool OnEnterDungeon
	{
		get { return enterDungeon.activeInHierarchy; }
	}

	// control UI 
	//inventory
	public void ControlInventory(bool state)
	{
		inventory.SetActive( state );
	}
	//skill ui
	public void ControlSkillUI(bool state)
	{
		skillUI.SetActive( state );
	}
	//status ui
	public void ControlStatusUI(bool state)
	{
		statusUI.SetActive( state );
		if(state)
			statusUI.GetComponent<StatusUI>().UpdateStatusInfo();
	}
	// enter dungeon
	public void ControlEnterDungeon(bool state)
	{
		enterDungeon.SetActive( state );
	}

	// close ui
	public void CloseScreen(string name)
	{
		switch(name)
		{
			case "EnterDungeon":
				ControlEnterDungeon( false );
				break;
			case "StatusUI":
				ControlStatusUI(false);
				break;
			case "Inventory":
				ControlInventory(false);
				break;
			case "SkillUI":
				ControlSkillUI(false);
				break;
		}
	}
		
}
