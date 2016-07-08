using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserInterfaceManager : MonoBehaviour
{
	//child UI
	public GameObject inventory;
	public GameObject skillUI;
	public GameObject statusUI;
	public GameObject enterDungeon;
	public GameObject deathPopUp;
	public QuickStatus quickStatus;
	public QuickSkillChain quickSkillChain;
	public ItemInformationPopUpControl itemPopUp;
	public Image presentSelectItem;
	public CharacterInformation info;

	//initialize this script
	void Start()
	{
		LinkElement();
		ClearUI();
	}

	//property
	public bool OnEnterDungeon
	{
		get { return enterDungeon.activeSelf; }
	}

	public bool OnStatusUI
	{
		get { return statusUI.activeSelf; }
	}

	public bool OnSkillUI
	{
		get { return skillUI.activeSelf; }
	}

	public bool OnInventory
	{
		get { return inventory.activeSelf; }
	}

	public Image PresentSelectItem
	{
		get { return presentSelectItem; }
	}

	//another method
	//data link
	public void LinkElement()
	{
		inventory = GameObject.Find( "Inventory" );
		skillUI = GameObject.Find( "SkillUI" );
		statusUI = GameObject.Find( "StatusUI" );
		enterDungeon = GameObject.Find( "EnterDungeon" );
		deathPopUp = GameObject.Find( "DeathPopUp" );
		quickStatus = GameObject.Find( "QuickStatus" ).GetComponent<QuickStatus>();
		quickSkillChain = GameObject.Find( "QuickSkillChain" ).GetComponent<QuickSkillChain>();
		itemPopUp = GameObject.FindWithTag( "ItemPopUp" ).GetComponent<ItemInformationPopUpControl>();
		itemPopUp.LinkComponent();
		presentSelectItem = transform.Find( "PresentSelectItem" ).GetComponent<Image>();
		presentSelectItem.enabled = false;
		
		info = GameObject.FindWithTag( "Player" ).GetComponent<CharacterInformation>();
	}

	//control ui element
	// inventory
	public void ControlInventory( bool state )
	{
		inventory.SetActive( state );

		if (state)
		{
			inventory.GetComponent<Inventory>().InitializeElement();
			inventory.GetComponent<Inventory>().LinkElement();
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
		{
			statusUI.GetComponent<StatusUI>().LinkElement();
			statusUI.GetComponent<StatusUI>().UpdateStatusInfo();
		}
	}

	// enter dungeon
	public void ControlEnterDungeon( bool state )
	{
		enterDungeon.SetActive( state );

		if (state)
			Debug.Log( "Active Enter Dungeon" );
	}

	// death pop up
	public void ControlDeathPopUp( bool state )
	{
		deathPopUp.SetActive( state );
	}

	// close ui
	public void CloseScreen( string name )
	{
		switch (name)
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
			case "DeathPopUp":
				ControlDeathPopUp( false );
				break;
		}
	}

	//close present item / skill
	public void ClosePresentElement()
	{
		presentSelectItem.enabled = false;
	}

	//all element close
	public void ClearUI()
	{
		ControlInventory( false );
		ControlSkillUI( false );
		ControlStatusUI( false );
		ControlEnterDungeon( false );
		ControlDeathPopUp( false );
		itemPopUp.ControlComponent( false );

	}

	// on click event - quick button
	public void QuickButtonEvent( string name )
	{
		switch (name)
		{
			case "StatusUI":
				ControlStatusUI( !OnStatusUI );
				break;
			case "Inventory":
				ControlInventory( !OnInventory );
				break;
			case "SkillUI":
				ControlSkillUI( !OnSkillUI );
				break;	
		}
	}


	//direct update
	//quick status update
	public void UpdateMainUI()
	{
		//update quick status
		quickStatus.UpdateQuickStatusInfo( info );

		//update quick skill chain
		quickSkillChain.UpdateSkillChain( info );
		
		//update present select item
		if (presentSelectItem.enabled)
			presentSelectItem.transform.position = Input.mousePosition;		
	}

}
