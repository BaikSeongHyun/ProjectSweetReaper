using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
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
	public SECTION section;

	public enum SECTION
	{
		Top,
		Bottom,
		Blade,
		Handle,
		Consume}

	;

	//constructor - no parameter
	public Item()
	{

	}

	//constructor - all parameter
	public Item( string _name, int _price, int _coreRank, int _weaponAtk, int _weaponDef, int _weaponStr, int _weaponDex, int _weaponInt, int _weaponLuck, int _weaponCri, Item.SECTION _section )
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
	public Item( Item data )
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
	}

	//property
	public string Name
	{
		get { return name; }
	}

	public Sprite Icon
	{
		get { return icon; }
	}

	//another method

	//set icon
	public void SetSpriteIcon( )
	{
//		string path = "image/" + name;
//		icon = Resources.Load<Sprite>();
	}


}