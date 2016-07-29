using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class SkillUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
	//complex data field
	public UserInterfaceManager mainUI;
	public SkillElement[] elements;
	public SkillElement presentSkillElement;
	public Sprite defaultSprite;

	public SkillElement[] CharacterSkill
	{
		get { return elements; }	
	}



	public void LinkElement()
	{	
		elements = new SkillElement[9];
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
		for (int i = 0; i < elements.Length; i++)
		{
			string skillItem = "SkillItem";
			skillItem += ( i + 1 ).ToString();
			elements[i] = transform.Find( skillItem ).GetComponent<SkillElement>();	
			elements[i].LinkElement();
		}				
	}

	public void UpdateSkillUI( CharacterInformation info )
	{
		for (int i = 0; i < elements.Length; i++)
		{
			elements[i].SkillInfo = info.CharacterSkill[i];
			elements[i].UpdateSkillIcon( info, defaultSprite );
		}
	}
	
	//skill element in -> pop up item information
	public void OnPointerEnter( PointerEventData eventData )
	{
		if(!mainUI.OnClickMouse)
			presentSkillElement = eventData.pointerEnter.GetComponent<SkillElement>();

		if ((presentSkillElement != null) && !mainUI.OnClickMouse)
			presentSkillElement.UpdateSkillPopUp(mainUI.info);
	}

	//skill element out -> pop up skill information
	public void OnPointerExit( PointerEventData eventData )
	{
		if (mainUI.PresentSelectSkill == null)
			return;
		
		if (presentSkillElement == null)
			return;

		presentSkillElement.CloseSkillPopUp();
		presentSkillElement = null;
	}

	//mouse click skill element
	public void OnPointerDown( PointerEventData eventData )
	{
		//insert skill data
		try
		{
			mainUI.PresentSelectSkill.enabled = true;
			mainUI.PresentSelectSkill = eventData.pointerEnter.GetComponent<SkillElement>();
		}
		catch (NullReferenceException e)
		{
			Debug.Log( e.InnerException );
			mainUI.PresentSelectSkill = null;
		}
		//delete item
		if (mainUI.PresentSelectSkill.SkillInfo.Name == "Default")
			return;

		//uninstall item
		if (eventData.button == PointerEventData.InputButton.Right)
			mainUI.InstallQuickSkill();

		//mode drag send skill icon data -> gameController
		if (eventData.button == PointerEventData.InputButton.Left && mainUI.PresentSelectSkill.SkillInfo.Name != "Default")
			mainUI.PresentSelectSkill.CloseSkillPopUp();		
	}
}