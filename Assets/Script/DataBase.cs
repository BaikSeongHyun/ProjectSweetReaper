using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DataBase
{
	public bool onCreate;

	public bool OnCreate
	{
		get { return onCreate; }
		set { onCreate = value; }
	}
	//complex data field
	public List<Item> itemInformation;
	public List<Skill> skillInformation;
	private static DataBase dataBaseInstance = null;

	public List<Item> ItemInformation
	{
		get { return itemInformation; }
	}

	public List<Skill> SkillInformation
	{
		get { return skillInformation; }
	}

	//constructor set - use singletone
	//constructor - mode static;
	static DataBase ()
	{
		dataBaseInstance = new DataBase ();
	}
	//constructor - no parameter
	private DataBase ()
	{
		CreateItemInformation();
		CreateSkillInformation();
	}

	public static DataBase Instance
	{
		get { return dataBaseInstance; }
	}


	//initialize item data
	public void CreateItemInformation()
	{
		//(string _name, int _price, int _coreRank, int _weaponAtk, int _weaponDef, int _weaponStr, int _weaponDex, int _weaponInt, int _weaponLuck, int _weaponCri, Item.SECTION _section)
		itemInformation = new List<Item> ();
		itemInformation.Add( new Item ( 1, "FearBlade", 1000, 3, 10, 0, 10, 10, 0, 0, 1, Item.SECTION.Blade ) );
		itemInformation.Add( new Item ( 2, "IronHandle", 100, 1, 0, 30, 0, 0, 5, 8, 1, Item.SECTION.Handle ) );
		itemInformation.Add( new Item ( 3, "DropOfSorcerer", 300, 5, 60, 0, 0, 0, 7, 4, 1, Item.SECTION.Bottom ) );
		itemInformation.Add( new Item ( 4, "TheHolySpear", 800, 10, 50, 0, 19, 10, 0, 0, 10, Item.SECTION.Top ) );
				
		for (int i = 0; i < itemInformation.Count; i++)
			itemInformation[i].SetSpriteIcon();
	}

	//initialize skill data
	public void CreateSkillInformation()
	{
		//(string _name, int _learnLevel, float _coolTime, float _damage, float _resource, STATE _state)
		
		skillInformation = new List<Skill> ();
		skillInformation.Add( new Skill ( 1, "Bash", 1, 0f, 350, 20, Skill.STATE.Active ) );
		skillInformation.Add( new Skill ( 2, "TwinRush", 1, 10.0f, 342, 10, Skill.STATE.Active ) );
		skillInformation.Add( new Skill ( 3, "CrescentCut", 1, 6f, 560, 15, Skill.STATE.Active ) );
		skillInformation.Add( new Skill ( 4, "LandCrush", 5, 18f, 1025, 90, Skill.STATE.Active ) );
		skillInformation.Add( new Skill ( 5, "WheelScythe", 5, 20f, 767, 20, Skill.STATE.Active ) );
		skillInformation.Add( new Skill ( 6, "UpperScythe", 5, 10f, 412, 20, Skill.STATE.Active ) );
			
		for (int i = 0; i < skillInformation.Count; i++)
			skillInformation[i].SetSpriteIcon();
	}

	//find item
	public Item FindItem( int index )
	{
		return itemInformation[index - 1];
	}

	//find skill
	public Skill FindSkill( int index )
	{
		return skillInformation[index - 1];
	}
}
