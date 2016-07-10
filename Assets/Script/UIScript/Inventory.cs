using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
	//complex data field
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
		money = transform.Find( "MoneyText" ).GetComponent<Text>();
		topInstall = transform.Find( "TopInstall" ).GetComponent<ItemElement>();
		bottomInstall = transform.Find( "BottomInstall" ).GetComponent<ItemElement>();
		bladeInstall = transform.Find( "BladeInstall" ).GetComponent<ItemElement>();
		handleInstall = transform.Find( "HandleInstall" ).GetComponent<ItemElement>();


		for (int i = 0; i < elements.Length; i++)
		{
			string slot = "ItemSlot";
			slot += (i + 1).ToString();
			elements[i] = transform.Find( slot ).GetComponent<ItemElement>();
		}
	}

	//update inventory data
	public void UpdateInventory( CharacterInformation info )
	{
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
		presentItemElement = eventData.pointerEnter.GetComponent<ItemElement>();

		if (presentItemElement != null)
			presentItemElement.UpdateItemPopUp();
							
	}

	//item element out -> pop up item information
	public void OnPointerExit( PointerEventData eventData )
	{
		if (mainUI.PresentSelectItem.enabled)
			return;
		
		Debug.Log( "Active on pointer exit" );
		if (presentItemElement == null)
			return;
		
		presentItemElement.CloseItemPopUp();
		presentItemElement = null;
	}

	//mouse click item element
	public void OnPointerDown( PointerEventData eventData )
	{
		presentItemElement.CloseItemPopUp();
		
		//insert item data
		try
		{			
			presentItemElement = eventData.pointerEnter.GetComponent<ItemElement>();
		}
		catch (NullReferenceException e)
		{
			Debug.Log( e.InnerException );
			presentItemElement = null;
		}
		//delete item
		if (presentItemElement == null)
			return;
		
		//uninstall item
		if (eventData.button == PointerEventData.InputButton.Right && presentItemElement.CompareTag( "InstalledItem" ))
			UninstallItem( presentItemElement );
		
		//install item
		if (eventData.button == PointerEventData.InputButton.Right)
			SwapInstallItem( presentItemElement.ItemInfo.Section, presentItemElement );
		   
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
			Debug.Log( eventData.pointerEnter );
		}
		catch (NullReferenceException e)
		{
			Debug.Log( e.InnerException );
			downPointItemElement = null;
		}

		if (downPointItemElement == null)
		{
			Debug.Log( "Null! force!" );
			return;
		}
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
	void SwapInstallItem( Item.SECTION section, ItemElement presentSelect )
	{
		switch (section)
		{
			case Item.SECTION.Blade:
				SwapItem( presentSelect, bladeInstall );
				break;
			case Item.SECTION.Top:
				SwapItem( presentSelect, topInstall );
				break;
			case Item.SECTION.Handle:
				SwapItem( presentSelect, handleInstall );
				break;
			case Item.SECTION.Bottom:
				SwapItem( presentSelect, bottomInstall );
				break;
			case Item.SECTION.Consume:
				break;
		}
	}
	
	//install item
	void InstallItem( ItemElement presentItem, ItemElement replaceSelect )
	{
		if (replaceSelect.ItemInfo.Section == presentItem.ItemInfo.Section)
			SwapItem( presentItem, replaceSelect );		
	}
	
	//swap item -> a to b
	void SwapItem( ItemElement presentSelect, ItemElement replaceSelect )
	{
		Item temp;
		temp = presentSelect.ItemInfo;
		presentSelect.ItemInfo = replaceSelect.ItemInfo;
		replaceSelect.ItemInfo = temp;

		presentSelect.UpdateItemIcon();
		replaceSelect.UpdateItemIcon();
	}
}
