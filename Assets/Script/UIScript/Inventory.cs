﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
	//complex data field
	public CharacterInformation info;
	public Item topInstall;
	public Item bottomInstall;
	public Item bladeInstall;
	public Item handleInstall;
	public ItemElement[] elements;
	public Text money;
	public ItemElement presentItemElement;

	//another method

	//initialize inventory element
	public void InitializeElement()
	{		
		info = GameObject.FindWithTag( "Player" ).GetComponent<CharacterInformation>();
		elements = new ItemElement[35];
	}

	//link inventory element
	public void LinkElement()
		money = transform.Find( "MoneyText" ).GetComponent<Text>();
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
//			elements[i].UpdateItemIcon();
		}
	}

	//item element in -> pop up item information
	public void OnPointerEnter( PointerEventData eventData )
	{
		presentItemElement = eventData.pointerEnter.GetComponent<ItemElement>();
		if (presentItemElement != null)
		{
			Debug.Log( "Active pop up" );
		}
					
	}

	//item element out -> pop up item information
	public void OnPointerExit( PointerEventData eventData )
	{
		//presentItemElement.CloseItemPopup();
		presentItemElement = null;
	}

	//mouse click item element
	public void OnPointerDown(PointerEventData eventData)
	{
		presentItemElement = eventData.pointerEnter.GetComponent<ItemElement>();
	}

	//mouse button up event
	public void OnPointerUp(PointerEventData eventData)
	{
		//default

		//delete

		//swap

	}
}
