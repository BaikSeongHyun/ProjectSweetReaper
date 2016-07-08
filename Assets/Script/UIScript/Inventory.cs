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
	public CharacterInformation info;
	public ItemElement topInstall;
	public ItemElement bottomInstall;
	public ItemElement bladeInstall;
	public ItemElement handleInstall;
	public ItemElement[] elements;
	public Text money;
	Sprite defaultSprite;
	public ItemElement presentItemElement;

	//another method

	//initialize inventory element
	public void InitializeElement()
	{		
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
		info = GameObject.FindWithTag( "Player" ).GetComponent<CharacterInformation>();
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
			slot += ( i + 1 ).ToString();
			elements[i] = transform.Find( slot ).GetComponent<ItemElement>();
		}
	}

	//update inventory data
	public void UpdateInventory()
	{
		money.text = info.Money.ToString();
		for (int i = 0; i < elements.Length; i++)
		{
			elements[i].ItemInfo = info.CharacterItem[i];
			//elements[i].UpdateItemIcon();
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

		//mode swap item
		if (eventData.button == PointerEventData.InputButton.Right)
			SwapInstallItem( presentItemElement.ItemInfo.Section, presentItemElement );
		   
		//mode drag send item icon data -> gameController
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			presentItemElement.CloseItemPopUp();
			mainUI.PresentSelectItem.enabled = true;
			defaultSprite = mainUI.PresentSelectItem.sprite; 
			mainUI.PresentSelectItem.sprite = presentItemElement.ItemIcon.sprite;
			presentItemElement.ItemIcon.sprite = defaultSprite;
		}
	
	}

	//mouse button up event
	public void OnPointerUp( PointerEventData eventData )
	{
		if (presentItemElement == null)
			return;

		if(presentItemElement != null)
			presentItemElement.CloseItemPopUp();
				
		ItemElement downPointItemElement;
		try
		{
			downPointItemElement = eventData.pointerEnter.GetComponent<ItemElement>();
		}
		catch (NullReferenceException e)
		{
			Debug.Log( e.InnerException );
			downPointItemElement = null;
		}

		if (downPointItemElement == null)
		{
			presentItemElement.ItemIcon.sprite = mainUI.PresentSelectItem.sprite;
			mainUI.PresentSelectItem.sprite = defaultSprite;
		}
		
//		//default - no edit or self
//		if (presentItemElement.Equals( downPointItemElement ))
//			presentItemElement = null;
//
//		//swap
//		SwapItem(presentItemElement, downPointItemElement);	
	}


	void SwapItem( ItemElement presentSelect, ItemElement replaceSelect )
	{
		ItemElement temp;
		temp = presentSelect;
		presentSelect = replaceSelect;
		replaceSelect = temp;

		presentSelect.UpdateItemIcon();
		replaceSelect.UpdateItemIcon();
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
		}
	}
}
