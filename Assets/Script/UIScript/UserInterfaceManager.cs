using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UserInterfaceManager : MonoBehaviour
{
	//ui mode
	public Mode presentMode;
	public bool itemSell;
	public bool itemBuy;
	public bool onClickMouse;

	//child UI & data - use neutral
	public GameObject inventory;
	public Inventory inventoryLogic;

	public GameObject skillUI;
	public SkillUI skillUILogic;

	public GameObject enterDungeon;
	public EnterDungeon enterDungeonLogic;

	public GameObject quickStatus;
	public QuickStatus quickStatusLogic;

	public GameObject expGauge;
	public ExpGauge expGaugeLogic;

	public GameObject quickSkillChain;
	public QuickSkillChain quickSkillChainLogic;

	public GameObject quickSkill;
	public QuickSkill quickSkillLogic;

	public GameObject quickSlot;

	public GameObject systemUI;
	public SystemUI systemUILogic;

	public GameObject itemPopUp;
	public ItemInformationPopUpControl itemPopUpLogic;

	public GameObject skillPopUp;
	public SkillInformationPopUpControl skillPopUpLogic;

	public GameObject skillCutScene;
	public SkillCutScene skillCutSceneLogic;

	public Image presentSelectItem;
	public SkillElement presentSelectSkill;
	public GameObject deathPopUp;
	public GameObject exitDungeonPopUp;
	public GameObject quickButton;

	//child UI & data - use npc
	public GameObject storeUI;
	public StoreUI storeUILogic;

	//child UI & data - use race
	public GameObject raceMiniMap;
	public RaceMiniMap raceMiniMapLogic;

	public GameObject racePetStatus;
	public RacePetStatus racePetStatusLogic;

	public GameObject raceAnotherPetStatus;
	public RaceAnotherPetStatus raceAnotherPetStatusLogic;

	public GameObject racePetOrder;

	//another information data
	public CharacterInformation info;
	public Pet[] anotherPets;
	public Pet myPet;

	public enum Mode
	{
		Neutral,
		Result,
		NPC,
		Tranning,
		Race,
		SubContent,
		Default}
	;

	//property
	public Mode PresentMode
	{
		get { return presentMode; }	
	}

	public bool OnClickMouse
	{
		get { return onClickMouse; }
		set { onClickMouse = value; }
	}

	public bool ItemSell
	{
		get { return itemSell; }
		set { itemSell = value; }
	}

	public bool ItemBuy
	{
		get { return itemBuy; }
		set { itemBuy = value; }
	}

	public bool OnEnterDungeon
	{
		get { return enterDungeon.activeSelf; }
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
		//neutral UI & data
		inventory = GameObject.Find( "Inventory" );
		inventoryLogic = inventory.GetComponent<Inventory>();

		skillUI = GameObject.Find( "SkillUI" );
		skillUILogic = skillUI.GetComponent<SkillUI>();

		enterDungeon = GameObject.Find( "EnterDungeon" );
		enterDungeonLogic = enterDungeon.GetComponent<EnterDungeon>();
		enterDungeonLogic.LinkElement( info );

		quickStatus = GameObject.Find( "QuickStatus" );
		quickStatusLogic = quickStatus.GetComponent<QuickStatus>();
		quickStatusLogic.LinkElement();

		expGauge = GameObject.Find( "ExpGauge" );
		expGaugeLogic = expGauge.GetComponent<ExpGauge>();
		expGaugeLogic.LinkElement();

		quickSkill = GameObject.Find( "QuickSkill" );
		quickSkillLogic = quickSkill.GetComponent<QuickSkill>();
		quickSkillLogic.LinkElement();

		quickSkillChain = GameObject.Find( "QuickSkillChain" );
		quickSkillChainLogic = quickSkillChain.GetComponent<QuickSkillChain>();
		quickSkillChainLogic.LinkElement();

		quickSlot = GameObject.Find( "QuickSlot" );

		systemUI = GameObject.Find( "SystemUI" );
		systemUILogic = systemUI.GetComponent<SystemUI>();
		systemUILogic.LinkElement();

		itemPopUp = GameObject.Find( "ItemPopUp" );
		itemPopUpLogic = itemPopUp.GetComponent<ItemInformationPopUpControl>();
		itemPopUpLogic.LinkElement();

		skillPopUp = GameObject.Find( "SkillPopUp" );
		skillPopUpLogic = skillPopUp.GetComponent<SkillInformationPopUpControl>();
		skillPopUpLogic.LinkElement();

		skillCutScene = GameObject.Find( "SkillCutScene" );
		skillCutSceneLogic = skillCutScene.GetComponent<SkillCutScene>();
		skillCutSceneLogic.LinkElement();

		presentSelectItem = transform.Find( "PresentSelectItem" ).GetComponent<Image>();
		presentSelectItem.enabled = false;

		presentSelectSkill = transform.Find( "PresentSelectSkill" ).GetComponent<SkillElement>();
		presentSelectSkill.gameObject.GetComponent<Image>().enabled = false;

		deathPopUp = GameObject.Find( "DeathPopUp" );
		exitDungeonPopUp = GameObject.Find( "ExitDungeonPopUp" );
		quickButton = GameObject.Find( "QuickButton" );

		// npe UI & data
		storeUI = GameObject.Find( "StoreUI" );
		storeUILogic = storeUI.GetComponent<StoreUI>();
		storeUILogic.LinkElement();

		//race UI & data
		raceMiniMap = GameObject.Find( "RaceMiniMap" );
		raceMiniMapLogic = raceMiniMap.GetComponent<RaceMiniMap>();
		raceMiniMapLogic.LinkElement();

		racePetStatus = GameObject.Find( "RacePetStatus" );
		racePetStatusLogic = racePetStatus.GetComponent<RacePetStatus>();
		racePetStatusLogic.LinkElement();

		raceAnotherPetStatus = GameObject.Find( "RaceAnotherPetStatus" );
		raceAnotherPetStatusLogic = raceAnotherPetStatus.GetComponent<RaceAnotherPetStatus>();
		raceAnotherPetStatusLogic.LinkElement();

		racePetOrder = GameObject.Find( "RacePetOrder" );
	}

	public void SwitchUIMode( Mode uiMode )
	{
		switch (uiMode)
		{
			case Mode.Neutral:
				presentMode = Mode.Neutral;
				InitializeModeNeutral();
				break;
			case Mode.Race:
				presentMode = Mode.Race;
				InitializeModeRace();
				break;
			case Mode.NPC:
				presentMode = Mode.NPC;
				InitializeModeNPC();
				break;
		}
	}

	public void LinkNeutralData( CharacterInformation _info )
	{
		info = _info;
	}

	public void LinkRaceData( Pet[] _anotherPets, Pet _myPet )
	{
		anotherPets = _anotherPets;
		myPet = _myPet;
	}

	//state apply - neutral
	public void InitializeModeNeutral()
	{
		//on neutral update item
		quickSkill.SetActive( true );
		quickSkillChain.SetActive( true );
		quickStatus.SetActive( true );
		quickSlot.SetActive( true );
		systemUI.SetActive( true );
		expGauge.SetActive( true );
		quickButton.SetActive( true );
		skillCutScene.SetActive( true );

		//off neutralasynchronous item
		inventory.SetActive( false );
		skillUI.SetActive( false );
		enterDungeon.SetActive( false );
		deathPopUp.SetActive( false );
		itemPopUpLogic.ControlComponent( false );	
		skillPopUpLogic.ControlComponent( false );
		exitDungeonPopUp.SetActive( false );
		presentSelectItem.enabled = false;
		presentSelectSkill.gameObject.GetComponent<Image>().enabled = false;

		//off npc item
		storeUI.SetActive( false );

		//off race items
		raceMiniMap.SetActive( false );
		racePetStatus.SetActive( false );
		racePetOrder.SetActive( false );
		raceAnotherPetStatus.SetActive( false );

	}

	//state apply - Race
	public void InitializeModeRace()
	{
		//off neutral update item
		quickSkill.SetActive( false );
		quickSkillChain.SetActive( false );
		quickStatus.SetActive( false );
		quickSlot.SetActive( false );
		systemUI.SetActive( false );
		expGauge.SetActive( false );
		quickButton.SetActive( false );
		skillCutScene.SetActive( false );

		//off asynchronous item
		inventory.SetActive( false );
		skillUI.SetActive( false );
		enterDungeon.SetActive( false );
		deathPopUp.SetActive( false );
		itemPopUpLogic.ControlComponent( false );	
		skillPopUpLogic.ControlComponent( false );
		exitDungeonPopUp.SetActive( false );
		presentSelectItem.enabled = false;
		presentSelectSkill.gameObject.GetComponent<Image>().enabled = false;

		//off race items
		raceMiniMap.SetActive( true );
		racePetStatus.SetActive( true );
		racePetOrder.SetActive( true );
		raceAnotherPetStatus.SetActive( true );

	}

	//state apply - NPC
	public void InitializeModeNPC()
	{
	}

	// inventory
	public void ControlInventory( bool state )
	{
		inventory.SetActive( state );

		if (state)
		{
			inventoryLogic.InitializeElement();
			inventoryLogic.LinkElement();
			inventoryLogic.UpdateInventory( info );
		}
		else
			itemPopUpLogic.ControlComponent( state );
	}

	// skill ui
	public void ControlSkillUI( bool state )
	{
		skillUI.SetActive( state );
		
		if (state)
		{
			skillUILogic.LinkElement();
			skillUILogic.UpdateSkillUI( info );
		}
		else
			skillPopUpLogic.ControlComponent( state );			
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

	// store ui
	public void ControlStoreUI( bool state )
	{
		storeUI.SetActive( state );
		if (state)
			storeUILogic.UpdateStoreUI();
	}

	// close ui
	public void CloseScreen( string name )
	{
		switch (name)
		{
			case "EnterDungeon":
				ControlEnterDungeon( false );
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
			case "Store":
				ControlStoreUI( false );
				break;
		}
	}

	//close present item / skill
	public void ClosePresentElement()
	{
		presentSelectItem.enabled = false;
		presentSelectSkill.enabled = false;
	}

	//all element close
	public void ClearUI()
	{
		ControlInventory( false );
		ControlSkillUI( false );
		ControlEnterDungeon( false );
		ControlDeathPopUp( false );
		ControlExitDungeonPopUp( false );
		itemPopUpLogic.ControlComponent( false );
	}

	//compare present Mode
	public bool CompareMode( Mode mode )
	{
		if (presentMode == mode)
			return true;
		else
			return false;
	}

	//update by inventory
	public void UpdateItemInformationByInventory(  )
	{
		info.TopInstall = inventoryLogic.TopInstall.ItemInfo;
		info.BottomInstall = inventoryLogic.BottomInstall.ItemInfo;
		info.BladeInstall = inventoryLogic.BladeInstall.ItemInfo;
		info.HandleInstall = inventoryLogic.handleInstall.ItemInfo;

		for (int i = 0; i < info.CharacterItem.Length; i++)
			info.CharacterItem[i] = inventoryLogic.ItemSlot[i].ItemInfo;

		info.UpdateInventoryStatus();
		inventoryLogic.UpdateInventory( info );
	}

	public void UpdateItemInformationByStoreUI()
	{
		storeUILogic.UpdateStoreUI();
		inventoryLogic.UpdateInventory( info );
	}
	
	//update by quick skill
	public void UpdateInstallSkillInfomationByQuickSkill( )
	{
		for (int i = 0; i < info.InstallSkill.Length; i++)
			info.InstallSkill[i] = quickSkillLogic.InstallSkill[i].SkillInfo;	
	}
		
	//skill install in quick skill
	public void InstallQuickSkill()
	{
		if (quickSkillLogic.CheckSkill( PresentSelectSkill.SkillInfo ))
			quickSkillLogic.InstallQuickSkill( PresentSelectSkill.SkillInfo, info );
	}

	//sell item
	public void SellItemProcess(ItemElement data)
	{
		info.SellItemProcess( data );
	}

	public void BuyItemProcess(ItemElement data)
	{
		info.BuyItemProcess( data );
	}

	// on click event - quick button
	public void QuickButtonEvent( string name )
	{
		switch (name)
		{
			case "Inventory":
				ControlInventory( !OnInventory );
				break;
			case "SkillUI":
				ControlSkillUI( !OnSkillUI );
				break;
			case "Sell":
				itemBuy = false;
				itemSell = true;
				break;
			case " Buy":
				itemBuy = true;
				itemSell = false;
				break;
		}
	}
	
	//update system UI
	public void AsynchronousSystemUI( string data )
	{
		systemUILogic.AddData( data );
		systemUILogic.UpdateSystem();
	}

	// skill cut scene active!
	public void ActiveSkillCutScene()
	{
		skillCutSceneLogic.ActiveSkillCutScene();
	}

	//direct update
	//quick status update
	public void UpdateMainUI()
	{
		if (CompareMode( Mode.Neutral ))
		{
			//update quick status
			quickStatusLogic.UpdateQuickStatusInfo( info );

			//update exp gauge 
			expGaugeLogic.UpdateExpGauge( info );

			//update quick skill chain
			quickSkillChainLogic.UpdateSkillChain( info );
		
			//update present select item
			if (presentSelectItem.enabled)
				presentSelectItem.transform.position = Input.mousePosition;	

			//update quick skill
			quickSkillLogic.UpdateQuickSkillElement( info );
			
			//ready to skill cut scene
			skillCutSceneLogic.UpdateSkillCutScene();
			
		}
		else if (CompareMode( Mode.Race ))
		{
			//update race mini map
			raceMiniMapLogic.UpdateMinimap( myPet.PresentPosition );

			//update race pet status
			racePetStatusLogic.UpdatePetStatus( myPet );

			//update race another pet status
			raceAnotherPetStatusLogic.UpdateRaceAnotherPetStatus( anotherPets );
		}
		else if (CompareMode( Mode.Result ))
		{

		}
	}
}
