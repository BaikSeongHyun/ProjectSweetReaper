using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
	public string presentName;

	//status
	Text characterName;
	Text level;
	Text damage;
	Text healthPoint;
	Text resourcePoint;
	Text criticalProability;
	Text strength;
	Text intelligence;
	Text dexterity;
	Text luck;

	//inventory
	public UserInterfaceManager mainUI;
	public ItemElement topInstall;
	public ItemElement bottomInstall;
	public ItemElement bladeInstall;
	public ItemElement handleInstall;
	public ItemElement[] elements;
	public Text money;
	public ItemElement presentItemElement;
	public ItemElement downPointItemElement;

	//property
	public ItemElement TopInstall
	{
		get { return topInstall; }
	}

	public ItemElement BottomInstall
	{
		get { return bottomInstall; }
	}

	public ItemElement BladeInstall
	{
		get { return bladeInstall; }
	}

	public ItemElement HandleInstall
	{
		get { return handleInstall; }
	}

	public ItemElement[] ItemSlot
	{
		get { return elements; }
	}

	//another method

	//initialize inventory element
	public void InitializeElement()
	{		
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
		elements = new ItemElement[35];
	}

	//link inventory element
	public void LinkElement()
	{
		//status
		characterName = transform.Find( "CharacterNameText" ).GetComponent<Text>();
		level = transform.Find( "LevelText" ).GetComponent<Text>();
		damage = transform.Find( "DamageText" ).GetComponent<Text>();
		healthPoint = transform.Find( "HealthPointText" ).GetComponent<Text>();
		resourcePoint = transform.Find( "ResourcePointText" ).GetComponent<Text>();
		criticalProability = transform.Find( "CriticalProabilityText" ).GetComponent<Text>();
		strength = transform.Find( "StrengthText" ).GetComponent<Text>();
		intelligence = transform.Find( "IntelligenceText" ).GetComponent<Text>();
		dexterity = transform.Find( "DexterityText" ).GetComponent<Text>();
		luck = transform.Find( "LuckText" ).GetComponent<Text>();

		//inventory
		money = transform.Find( "MoneyText" ).GetComponent<Text>();

		topInstall = transform.Find( "TopInstall" ).GetComponent<ItemElement>();
		bottomInstall = transform.Find( "BottomInstall" ).GetComponent<ItemElement>();
		bladeInstall = transform.Find( "BladeInstall" ).GetComponent<ItemElement>();
		handleInstall = transform.Find( "HandleInstall" ).GetComponent<ItemElement>();

		for (int i = 0; i < elements.Length; i++)
		{
			string slot = "ItemSlot";
			slot += ( i + 1 ).ToString();
			elements[i] = transform.Find( slot ).GetComponent<ItemElement>();
		}

	}

	//update inventory data
	public void UpdateInventory( CharacterInformation info )
	{
		//status
		characterName.text = info.CharacterName;
		level.text = info.Level.ToString();
		damage.text = info.Damage.ToString();
		healthPoint.text = info.OriginHealthPoint.ToString();
		resourcePoint.text = info.OriginResourcePoint.ToString();
		criticalProability.text = info.CriticalProability.ToString();
		strength.text = info.Strength.ToString();
		intelligence.text = info.Intelligence.ToString();
		dexterity.text = info.Dexterity.ToString();
		luck.text = info.Luck.ToString();	

		//inventory
		money.text = info.Money.ToString();

		bladeInstall.ItemInfo = info.BladeInstall;
		bladeInstall.UpdateItemIcon();
		topInstall.ItemInfo = info.TopInstall;
		topInstall.UpdateItemIcon();
		handleInstall.ItemInfo = info.HandleInstall;
		handleInstall.UpdateItemIcon();
		bottomInstall.ItemInfo = info.BottomInstall;
		bottomInstall.UpdateItemIcon();

		for (int i = 0; i < elements.Length; i++)
		{
			elements[i].ItemInfo = info.CharacterItem[i];
			elements[i].UpdateItemIcon();
		}
	}

	//item element in -> pop up item information
	public void OnPointerEnter( PointerEventData eventData )
	{
		if (!mainUI.OnClickMouse)
			presentItemElement = eventData.pointerEnter.GetComponent<ItemElement>();

		if (( presentItemElement != null ) && !mainUI.OnClickMouse)
			presentItemElement.UpdateItemPopUp();								
	}

	//item element out -> pop up item information
	public void OnPointerExit( PointerEventData eventData )
	{
		if (mainUI.PresentSelectItem.enabled)
			return;
	
		if (presentItemElement == null)
			return;
		
		presentItemElement.CloseItemPopUp();
		presentItemElement = null;
	}

	//mouse click item element
	public void OnPointerDown( PointerEventData eventData )
	{		
		if (presentItemElement != null)
		{
			presentItemElement.CloseItemPopUp();
			presentItemElement = null;
		}

		//insert item data
		try
		{			
			presentName = eventData.pointerEnter.name;
			presentItemElement = transform.Find( presentName ).gameObject.GetComponent<ItemElement>();
		}
		catch (NullReferenceException e)
		{
			Debug.Log( e.InnerException );
			presentItemElement = null;
		}
		//delete item
		if (presentItemElement == null)
			return;

		presentItemElement.CloseItemPopUp();

		//uninstall item
		if (eventData.button == PointerEventData.InputButton.Right && presentItemElement.CompareTag( "InstalledItem" ))
			UninstallItem( presentItemElement );
		
		//install item
		if (eventData.button == PointerEventData.InputButton.Right)
			SwapInstallItem( presentItemElement.ItemInfo.InstallSection, presentItemElement );
		   
		//mode drag send item icon data -> gameController
		if (eventData.button == PointerEventData.InputButton.Left && presentItemElement.ItemInfo.Name != "Default")
		{			
			mainUI.PresentSelectItem.enabled = true;
			mainUI.PresentSelectItem.sprite = presentItemElement.ItemIcon.sprite;
		}

		mainUI.UpdateItemInformationByInventory( this );	
	}

	//mouse button up event
	public void OnPointerUp( PointerEventData eventData )
	{		
		if (presentItemElement == null)
			return;

		try
		{
			downPointItemElement = eventData.pointerEnter.GetComponent<ItemElement>();
		}
		catch
		{
			downPointItemElement = null;
		}

		if (downPointItemElement == null)
			return;
		else if (downPointItemElement.CompareTag( "InstalledItem" ))
			InstallItem( presentItemElement, downPointItemElement );
		else if (downPointItemElement != null)
			SwapItem( presentItemElement, downPointItemElement );	

		mainUI.UpdateItemInformationByInventory( this );
	}

	//uninstall item
	void UninstallItem( ItemElement presentSelect )
	{
		for (int i = 0; i < elements.Length; i++)
		{
			if (elements[i].ItemInfo.Name == "Default")
			{
				SwapItem( presentSelect, elements[i] );
				return;
			}
		}

		//send message for system UI
	}

	//installed item swap
	void SwapInstallItem( Item.Section section, ItemElement presentSelect )
	{
		switch (section)
		{
			case Item.Section.Blade:
				SwapItem( presentSelect, bladeInstall );
				break;
			case Item.Section.Top:
				SwapItem( presentSelect, topInstall );
				break;
			case Item.Section.Handle:
				SwapItem( presentSelect, handleInstall );
				break;
			case Item.Section.Bottom:
				SwapItem( presentSelect, bottomInstall );
				break;
			case Item.Section.Consume:
				break;
		}
	}
	
	//install item
	void InstallItem( ItemElement presentItem, ItemElement replaceSelect )
	{
		if (presentItem.ItemInfo.InstallSection.ToString() + "Install" == replaceSelect.gameObject.name)
			SwapItem( presentItem, replaceSelect );		
	}
	
	//swap item -> a to b
	void SwapItem( ItemElement presentSelect, ItemElement replaceSelect )
	{
//		Debug.Log( presentSelect );
//		Debug.Log( replaceSelect );
		Item temp;
		temp = presentSelect.ItemInfo;
		presentSelect.ItemInfo = replaceSelect.ItemInfo;
		replaceSelect.ItemInfo = temp;

		presentSelect.UpdateItemIcon();
		replaceSelect.UpdateItemIcon();
	}
}
