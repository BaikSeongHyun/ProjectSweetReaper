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
		itemInformation[0] = new Item( "LeatherHandle", 100, 1, 0, 0, 0, 0, 0, 1, 1, Item.SECTION.Handle );
		itemInformation[1] = new Item( "BloodyCarnival", 1000, 3, 10, 0, 10, 0, 0, 0, 5, Item.SECTION.Blade );
		itemInformation[2] = new Item( "OutwornProp", 100, 2, 0, 0, 1, 0, 0, 1, 0, Item.SECTION.Bottom );
		itemInformation[3] = new Item( "WingOfVictory", 4000, 3, 0, 0, 0, 5, 0, 5, 5, Item.SECTION.Top );
		itemInformation[4] = new Item( "BFHandle", 222, 4, 0, 0, 0, 0, 0, 10, 10, Item.SECTION.Handle );
		itemInformation[5] = new Item( "JumbiHead", 100, 2, 0, 0, 3, -1, 3, 0, 10, Item.SECTION.Top );
		itemInformation[6] = new Item( "HealthPotion", 50, 0, 0, 0, 0, 0, 0, 0, 0, Item.SECTION.Consume );
	}

	//initialize skill data
	void LinkSkillInformation()
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
