using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DataBase : MonoBehaviour
{
	//complex data field
	public Item[] itemInformation;
	public Skill[] skillInformation;

	//initialize this script
	void start()
	{
		CreateItemInformation();
		LinkSkillInformation();
	}

	//another method

	//initialize item data
	void CreateItemInformation()
	{
		itemInformation = new Item[10];

	}
	//initialize skill data
	void LinkSkillInformation()
	{

	}

	//find item
	public Item FindItem( string name )
	{
		for (int i = 0; i < itemInformation.Length; i++)
			if (name == itemInformation[i].Name)
				return itemInformation[i];

		return null;
	}

	//find skill
	public Skill SkillItem( string name )
	{
		for (int i = 0; i < skillInformation.Length; i++)
			if (name == skillInformation[i].Name)
				return skillInformation[i];

		return null;
	}
}
