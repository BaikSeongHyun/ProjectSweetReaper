﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DungeonInCheck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Image dungeonCheck;

	// initialize this script
	void start()
	{
		dungeonCheck = transform.Find( "ForestCheck" ).GetComponent<Image>();
		ControlDungeonCheckImage( false );
	}

	public void ControlDungeonCheckImage( bool state )
	{
		dungeonCheck.enabled = state;
	}

	public void OnPointerEnter( PointerEventData eventData )
	{
		ControlDungeonCheckImage( true );
	}

	public void OnPointerExit( PointerEventData eventData )
	{
		ControlDungeonCheckImage( false );
	}

}
