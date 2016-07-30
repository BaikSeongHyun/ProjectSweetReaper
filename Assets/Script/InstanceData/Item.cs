using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Item
{
	//id
	public int id;

	//name
	public string name;

	//icon
	public Sprite icon;

	//data
	public int price;
	public int coreRank;
	public int weaponAtk;
	public int weaponDef;
	public int weaponStr;
	public int weaponDex;
	public int weaponInt;
	public int weaponLuck;
	public int weaponCri;
	public Section section;
	public Rarity rareRank;

	//property
	public int Id
	{
		get { return id; }
	}

	public string Name
	{
		get { return name; }
	}

	public Sprite Icon
	{
		get { return icon; }
	}

	public int Price
	{
		get { return price; }
	}

	public int CoreRank
	{
		get { return coreRank; }
	}

	public int WeaponAtk
	{
		get { return weaponAtk; }
	}

	public int WeaponDef
	{
		get { return weaponDef; }
	}

	public int WeaponStr
	{
		get { return weaponStr; }
	}

	public int WeaponDex
	{
		get { return weaponDex; }
	}

	public int WeaponInt
	{
		get { return weaponInt; }
	}

	public int WeaponLuck
	{
		get { return weaponLuck; }
	}

	public int WeaponCri
	{
		get { return weaponCri; }
	}

	public Section InstallSection
	{
		get { return section; }
	}

	public Rarity RareRank
	{
		get { return rareRank; }
	}

	public enum Rarity{
		Default,
		Normal,
		Rare,
		Unique,
		Legendary}
;

	public enum Section
	{
		Top,
		Bottom,
		Blade,
		Handle,
		Consume,
		Default}

	;

	//constructor - no parameter
	public Item ()
	{
		id = 0;
		name = "Default";
		price = 0;
		coreRank = 0;
		weaponAtk = 0;
		weaponDef = 0;
		weaponStr = 0;
		weaponDex = 0;
		weaponInt = 0;
		weaponLuck = 0;
		weaponCri = 0;
		section = Section.Default;
		rareRank = Rarity.Default;
	}

	//constructor - all parameter
	public Item (int _id, string _name, int _price, int _coreRank, int _weaponAtk, int _weaponDef, int _weaponStr, int _weaponDex, int _weaponInt, int _weaponLuck, int _weaponCri, Section _section, Rarity _rareRank)
	{
		id = _id;
		name = _name;
		price = _price;
		coreRank = _coreRank;
		weaponAtk = _weaponAtk;
		weaponDef = _weaponDef;
		weaponStr = _weaponStr;
		weaponDex = _weaponDex;
		weaponInt = _weaponInt;
		weaponLuck = _weaponLuck;
		weaponCri = _weaponCri;
		section = _section;
		rareRank = _rareRank;
	}
		
			
	//constructor - self parameter
	public Item (Item data)
	{
		id = data.id;
		name = data.name;
		price = data.price;
		coreRank = data.coreRank;
		weaponAtk = data.weaponAtk;
		weaponDef = data.weaponDef;
		weaponStr = data.weaponStr;
		weaponDex = data.weaponDex;
		weaponInt = data.weaponInt;
		weaponLuck = data.weaponLuck;
		weaponCri = data.weaponCri;
		section = data.section;
		rareRank = data.rareRank;
		icon = data.icon;
	}

	//another method

	//set icon
	public void SetSpriteIcon()
	{
		string path = "Item/Item" + name;
		Sprite temp = Resources.Load<Sprite>( path );
		icon = temp;
	}

	public Color SetTextColor()
	{
		switch (rareRank)
		{
			case Rarity.Legendary:
				return new Color ( 1f, 0.5f, 0.0f, 1f );
			case Rarity.Unique:
				return Color.magenta;
			case Rarity.Rare:
				return Color.yellow;
			case Rarity.Normal:
				return Color.white;
		}

		return Color.clear;
	}

	public string SetRarityText()
	{
		switch (rareRank)
		{
			case Rarity.Legendary:
				return "[Legendary]";
			case Rarity.Unique:
				return "[Unique]";
			case Rarity.Rare:
				return "[Rare]";
			case Rarity.Normal:
				return"[Normal]";
		}

		return null;
	}

	public void SetDefault()
	{
		id = 0;
		name = "Default";
		price = 0;
		coreRank = 0;
		weaponAtk = 0;
		weaponDef = 0;
		weaponStr = 0;
		weaponDex = 0;
		weaponInt = 0;
		weaponLuck = 0;
		weaponCri = 0;
		section = Section.Default;
	}

}