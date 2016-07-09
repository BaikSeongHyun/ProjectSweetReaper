using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DataBase : MonoBehaviour
{
	public bool onCreate;

	public bool OnCreate
	{
		get { return onCreate; }
		set { onCreate = value; }
	}
	//complex data field
	public Item[] itemInformation;
	public Skill[] skillInformation;

	void Start()
	{
		onCreate = false;
	}
	//another method

	//initialize item data
	public void CreateItemInformation()
	{
		itemInformation = new Item[10];
		itemInformation[0] = new Item ( "FearBlade", 1000, 3, 10, 0, 0, 0, 0, 1, 1, Item.SECTION.Blade );
		itemInformation[1] = new Item ( "IronHandle", 100, 1, 0, 0, 0, 0, 0, 1, 1, Item.SECTION.Handle );
		itemInformation[2] = new Item ( "DropOfSorcerer", 300, 2, 0, 0, 0, 0, 0, 1, 1, Item.SECTION.Bottom );
		itemInformation[3] = new Item ( "TheHolySpear", 800, 0, 0, 0, 0, 3, 3, 0, 5, Item.SECTION.Top );
		for (int i = 4; i < itemInformation.Length; i++)
			itemInformation[i] = new Item ();
		

		for (int i = 0; i < itemInformation.Length; i++)
			itemInformation[i].SetSpriteIcon();
	}

	//initialize skill data
	public void CreateSkillInformation()
	{
		skillInformation = new Skill[10];
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
