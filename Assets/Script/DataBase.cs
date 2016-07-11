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

	public Item[] ItemInformation
	{
		get { return itemInformation; }
	}

	public Skill[] SkillInformation
	{
		get { return skillInformation; }
	}


	void Start()
	{
		onCreate = false;
	}
	//another method

	//initialize item data
	public void CreateItemInformation()
	{
		//(string _name, int _price, int _coreRank, int _weaponAtk, int _weaponDef, int _weaponStr, int _weaponDex, int _weaponInt, int _weaponLuck, int _weaponCri, Item.SECTION _section)
		itemInformation = new Item[10];
		itemInformation[0] = new Item ( "FearBlade", 1000, 3, 10, 0, 10, 10, 0, 0, 1, Item.SECTION.Blade );
		itemInformation[1] = new Item ( "IronHandle", 100, 1, 0, 30, 0, 0, 5, 8, 1, Item.SECTION.Handle );
		itemInformation[2] = new Item ( "DropOfSorcerer", 300, 5, 60, 0, 0, 0, 7, 4, 1, Item.SECTION.Bottom );
		itemInformation[3] = new Item ( "TheHolySpear", 800, 10, 50, 0, 19, 10, 0, 0, 10, Item.SECTION.Top );
		
		for (int i = 4; i < itemInformation.Length; i++)
			itemInformation[i] = new Item ();
		
		for (int i = 0; i < itemInformation.Length; i++)
			itemInformation[i].SetSpriteIcon();
	}

	//initialize skill data
	public void CreateSkillInformation()
	{
		//(string _name, int _learnLevel, float _coolTime, float _damage, float _resource, STATE _state)
		
		skillInformation = new Skill[9];
		skillInformation[0] = new Skill ( "Bash", 1, 0f, 350, 20, Skill.STATE.Active );
		skillInformation[1] = new Skill ( "TwinRush", 1, 10.0f, 342, 10, Skill.STATE.Active );
		skillInformation[2] = new Skill ( "CrescentCut", 1, 6f, 560, 15, Skill.STATE.Active );
		skillInformation[3] = new Skill ( "LandCrush", 5, 18f, 1025, 90, Skill.STATE.Active );
		skillInformation[4] = new Skill ( "WheelScythe", 5, 20f, 767, 20, Skill.STATE.Active );
		skillInformation[5] = new Skill ( "UpperScythe", 5, 10f, 412, 20, Skill.STATE.Active );
		for (int i = 6; i < skillInformation.Length; i++)
			skillInformation[i] = new Skill ();
		
		for (int i = 0; i < skillInformation.Length; i++)
			skillInformation[i].SetSpriteIcon();
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
	public Skill FindSkill( string name )
	{
		for (int i = 0; i < skillInformation.Length; i++)
			if (name == skillInformation[i].Name)
				return skillInformation[i];

		return null;
	}
}
