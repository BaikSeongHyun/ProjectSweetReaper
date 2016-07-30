using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class QuickSkill : MonoBehaviour, IPointerDownHandler
{
	//complex data field
	public UserInterfaceManager mainUI;
	public SkillElement[] elements;
	public SkillElement presentSkillElement;
	public Sprite defaultSprite;

	public SkillElement[] InstallSkill
	{
		get { return elements; }
	}

	void Start()
	{
		InitializeElement();
		LinkElement();
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
			elements[i].LinkElement();
		}
	}

	public bool CheckSkill( Skill data )
	{
		if (data.Id == 0)
			return false;
		for (int i = 0; i < elements.Length; i++)
			if (elements[i].SkillInfo.Id == data.Id)
				return false;
				
		
		return true;
	}

	public void InstallQuickSkill( Skill skill, CharacterInformation info )
	{
		for (int i = 0; i < elements.Length; i++)
		{
			if (elements[i].SkillInfo.Name == "Default" && skill.LearnLevel <= info.Level)
			{
				elements[i].SkillInfo = new Skill(skill);
				elements[i].UpdateSkillIcon( info, defaultSprite );
				break;
			}
		}
		mainUI.UpdateInstallSkillInfomationByQuickSkill( this );
	}

	//update in user interface manager
	public void UpdateQuickSkillElement( CharacterInformation info )
	{
		for (int i = 0; i < elements.Length; i++)
		{
			elements[i].SkillInfo = info.InstallSkill[i];
			elements[i].UpdateSkillIcon( info, defaultSprite );
			elements[i].UpdateSkillElement( info, i );
		}
	}
	
	//skill element out item
	public void OnPointerDown( PointerEventData eventData )
	{
		presentSkillElement = eventData.pointerEnter.GetComponent<SkillElement>();

		if (presentSkillElement == null)
			return;

		if (eventData.button == PointerEventData.InputButton.Right)
		{
			presentSkillElement.SkillInfo = new Skill();
			presentSkillElement.UpdateDefaultSkillIcon( defaultSprite );
			presentSkillElement = null;
		}

		mainUI.UpdateInstallSkillInfomationByQuickSkill( this );
	}

	
}
