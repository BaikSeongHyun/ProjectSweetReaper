using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Item
{
	//name
	public string name;

	public string Name
	{
		get { return name; }
	}

	//icon
	public Sprite icon;

	public Sprite Icon
	{
		get { return icon; }
	}

	//data
	public int price;

	public int Price
	{
		get { return price; }
	}

	public int coreRank;

	public int CoreRank
	{
		get { return coreRank; }
	}

	public int weaponAtk;

	public int WeaponAtk
	{
		get { return weaponAtk; }
	}

	public int weaponDef;

	public int WeaponDef
	{
		get { return weaponDef; }
	}

	public int weaponStr;

	public int WeaponStr
	{
		get { return weaponStr; }
	}

	public int weaponDex;

	public int WeaponDex
	{
		get { return weaponDex; }
	}

	public int weaponInt;

	public int WeaponInt
	{
		get { return weaponInt; }
	}

	public int weaponLuck;

	public int WeaponLuck
	{
		get { return weaponLuck; }
	}

	public int weaponCri;

	public int WeaponCri
	{
		get { return weaponCri; }
	}

	public SECTION section;

	public SECTION Section
	{
		get { return section; }
	}

	public enum SECTION
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
		section = SECTION.Default;
	}

	//constructor - all parameter
	public Item (string _name, int _price, int _coreRank, int _weaponAtk, int _weaponDef, int _weaponStr, int _weaponDex, int _weaponInt, int _weaponLuck, int _weaponCri, Item.SECTION _section)
	{
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
	}
		
			
	//constructor - self parameter
	public Item (Item data)
	{
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


	public void SetDefault()
	{
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
		section = SECTION.Default;
	}

}