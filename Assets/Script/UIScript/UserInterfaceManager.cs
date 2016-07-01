using UnityEngine;
using System.Collections;

public class UserInterfaceManager : MonoBehaviour
{
	//child UI
	public GameObject inventory;
	public GameObject skillUI;
	public GameObject statusUI;
	public GameObject enterDungeon;
	public QuickStatus quickStatus;

	//initialize this script
	void Start( )
	{
		LinkElement();

		ClearUI();
	}

	//property
	public bool OnEnterDungeon
	{
		get { return enterDungeon.activeInHierarchy; }
	}

	public bool OnStatusUI
	{
		get { return statusUI.activeInHierarchy; }
	}

	public bool OnSkillUI
	{
		get { return skillUI.activeInHierarchy; }
	}

	public bool OnInventory
	{
		get { return inventory.activeInHierarchy; }
	}

	//another method
	//data link
	public void LinkElement( )
	{
		inventory = GameObject.Find( "Inventory" );
		skillUI = GameObject.Find( "SkillUI" );
		statusUI = GameObject.Find( "StatusUI" );
		enterDungeon = GameObject.Find( "EnterDungeon" );
		quickStatus = GameObject.Find( "QuickStatus" ).GetComponent<QuickStatus>();
	}

	//control ui element
	// inventory
	public void ControlInventory( bool state )
	{
		inventory.SetActive( state );

		if (state)
		{
			inventory.GetComponent<Inventory>().UpdateInventory();
		}
	}

	//skill ui
	public void ControlSkillUI( bool state )
	{
		skillUI.SetActive( state );
	}

	//status ui
	public void ControlStatusUI( bool state )
	{
		statusUI.SetActive( state );

		if (state)
			statusUI.GetComponent<StatusUI>().UpdateStatusInfo();
	}

	// enter dungeon
	public void ControlEnterDungeon( bool state )
	{
		enterDungeon.SetActive( state );
	}

	// close ui
	public void CloseScreen( string name )
	{
		switch(name)
		{
			case "EnterDungeon":
				ControlEnterDungeon( false );
				break;
			case "StatusUI":
				ControlStatusUI( false );
				break;
			case "Inventory":
				ControlInventory( false );
				break;
			case "SkillUI":
				ControlSkillUI( false );
				break;
		}
	}

	//all element close
	public void ClearUI( )
	{
		ControlInventory( false );
		ControlSkillUI( false );
		ControlStatusUI( false );
		ControlEnterDungeon( false );
	}


	//direct update
	//quick status update
	public void UpdateQuickStatus( )
	{
		quickStatus.UpdateQuickStatusInfo();
	}

}
