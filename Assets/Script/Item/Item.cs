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

	public Item( string _name, int _price )
	{
	}
		
			
	//constructor - self parameter
	public Item( Item data )
	{

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

}