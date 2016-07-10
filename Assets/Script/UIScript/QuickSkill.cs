using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class QuickSkill : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
	//complex data field
	public UserInterfaceManager mainUI;
	public SkillElement[] elements;
	public SkillElement presentSkillElement;

	public SkillElement[] InstallSkill
	{
		get { return elements; }
	}

	public void InitializeElement()
	{
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
		elements = new SkillElement[8];
	}

	public void LinkElement()
	{		
		for (int i = 0; i < elements.Length; i++)
		{
			string skillItem = "SkillSlot";
			skillItem += (i + 1).ToString();
			elements[i] = transform.Find( skillItem ).GetComponent<SkillElement>();	
		}				
	}

	public void InstallQuickSkill( Skill skill )
	{
		for (int i = 0; i < elements.Length; i++)
		{
			if (elements[i].SkillInfo.Name == "Default")
				elements[i].SkillInfo = new Skill(skill);
		}
	}

	
	public void UpdateSkillUI( CharacterInformation info )
	{
		for (int i = 0; i < elements.Length; i++)
		{
			elements[i].SkillInfo = info.InstallSkill[i];
			elements[i].UpdateSkillIcon(info);
		}
	}
	
	//item element in -> pop up item information
	public void OnPointerEnter( PointerEventData eventData )
	{
		presentSkillElement = eventData.pointerEnter.GetComponent<SkillElement>();

		if (presentSkillElement != null)
			presentSkillElement.UpdateSkillPopUp();
	}
	
	//item element out -> pop up item information
	public void OnPointerExit( PointerEventData eventData )
	{
		if (mainUI.PresentSelectSkill.enabled)
			return;
		
		if (presentSkillElement == null)
			return;

		presentSkillElement.CloseSkillPopUp();
		presentSkillElement = null;
	}
	
}
