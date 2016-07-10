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
	public GameObject exitDungeonPopUp;
	public QuickStatus quickStatus;
	public QuickSkillChain quickSkillChain;
	public QuickSkill quickSkill;
	public SystemUI systemUI;
	public ItemInformationPopUpControl itemPopUp;
	public SkillInformationPopUpControl skillPopUp;
	public Image presentSelectItem;
	public SkillElement presentSelectSkill;
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

	public SkillElement PresentSelectSkill
	{
		get { return presentSelectSkill; }
		set { presentSelectSkill = value; }
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
		exitDungeonPopUp = GameObject.Find( "ExitDungeonPopUp" );
		quickStatus = GameObject.Find( "QuickStatus" ).GetComponent<QuickStatus>();
		quickSkillChain = GameObject.Find( "QuickSkillChain" ).GetComponent<QuickSkillChain>();
		quickSkill = GameObject.Find( "QuickSkill" ).GetComponent<QuickSkill>();
		systemUI = GameObject.Find( "SystemUI" ).GetComponent<SystemUI>();
		itemPopUp = GameObject.Find( "ItemPopUp" ).GetComponent<ItemInformationPopUpControl>();
		itemPopUp.LinkComponent();
		skillPopUp = GameObject.Find( "SkillPopUp" ).GetComponent<SkillInformationPopUpControl>();
		skillPopUp.LinkComponent();
		presentSelectItem = transform.Find( "PresentSelectItem" ).GetComponent<Image>();
		presentSelectItem.enabled = false;
		presentSelectSkill = transform.Find( "PresentSelectSkill" ).GetComponent<SkillElement>();
		presentSelectSkill.gameObject.GetComponent<Image>().enabled = false;
		info = GameObject.FindWithTag( "Player" ).GetComponent<CharacterInformation>();
	}

	//control ui element
	// inventory
	public void ControlInventory( bool state )
	{
		inventory.SetActive( state );

		if (state)
		{
			Inventory temp = inventory.GetComponent<Inventory>();
			temp.InitializeElement();
			temp.LinkElement();
			temp.UpdateInventory( info );
		}
		else
			itemPopUp.ControlComponent( state );
	}

	//skill ui
	public void ControlSkillUI( bool state )
	{
		skillUI.SetActive( state );
		
		if (state)
		{
			SkillUI temp = skillUI.GetComponent<SkillUI>();
			temp.InitializeElement();
			temp.LinkElement();
			temp.UpdateSkillUI( info );
		}
		else
			skillPopUp.ControlComponent( state );			
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
	}

	// death pop up
	public void ControlDeathPopUp( bool state )
	{
		deathPopUp.SetActive( state );
	}
	
	// exit dungeon pop up
	public void ControlExitDungeonPopUp( bool state )
	{
		exitDungeonPopUp.SetActive( state );
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
			case "ExitDungeonPopUp":
				ControlExitDungeonPopUp( false );
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
		ControlExitDungeonPopUp( false );
		itemPopUp.ControlComponent( false );
	}

	//update by inventory
	public void UpdateItemInformationByInventory( Inventory inventory )
	{
		info.TopInstall = inventory.TopInstall.ItemInfo;
		info.BottomInstall = inventory.BottomInstall.ItemInfo;
		info.BladeInstall = inventory.BladeInstall.ItemInfo;
		info.HandleInstall = inventory.handleInstall.ItemInfo;

		for (int i = 0; i < info.CharacterItem.Length; i++)
			info.CharacterItem[i] = inventory.ItemSlot[i].ItemInfo;
	}
	
	//update by quick skill
	public void UpdateInstallSkillInfomationByQuickSkill( QuickSkill quickSkill )
	{
		for (int i = 0; i < info.InstallSkill.Length; i++)
			info.InstallSkill[i] = quickSkill.InstallSkill[i].SkillInfo;	
	}
	
	//skill install in quick skill
	public void InstallQuickSkill()
	{
		if (PresentSelectSkill.SkillInfo.Name != "Default")
			quickSkill.InstallQuickSkill( PresentSelectSkill.SkillInfo );
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
	
	//update system UI
	public void AsynchronousSystemUI(string data)
	{
		systemUI.AddData(data);
		systemUI.UpdateSystem();
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
		
		if (!info.InstalledItem)
			info.InstallDefaultItem();		
	}

}
