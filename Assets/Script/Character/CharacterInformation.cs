using UnityEngine;
using System.Collections;

public class CharacterInformation : MonoBehaviour
{
	// char status
	//name
	string characterName;

	//level
	int characterLevel;

	//exp
	float exp;
	float presentExp;
	float requireExp;

	//damage
	float presentDamage;
	float rootDamage;

	//hp - use public for test
	public float presentHealthPoint;
	float rootHealthPoint;
	float originHealthPoint;


	//rp - for use skill
	public float presentResourcePoint;
	float rootResourcePoint;
	float originResourcePoint;

	public float OriginResourcePoint
	{
		get { return originResourcePoint; }
	}

	//critical proability
	float criticalProability;
		
	//str
	int rootStrength;
	int presentStrength;
		
	//intell
	int rootIntelligence;
	int presentIntelligence;

	public int Intelligence
	{
		get { return presentIntelligence; }
	}
	
	//dex
	int rootDexterity;
	int presentDexterity;
		
	//luck
	int rootLuck;
	int presentLuck;

	//chain information
	int comboCounter;
	public float comboTime;

	//char Inventory information
	//Installed item
	public Item topInstall;
	public Item bottomInstall;
	public Item bladeInstall;
	public Item handleInstall;
		
	// have item
	Item[] characterItem;
	int money;

	//property

	public string CharacterName
	{
		get { return characterName; }
	}

	public int Level
	{
		get { return characterLevel; }
	}

	public float Damage
	{
		get { return presentDamage; }
	}

	public float OriginHealthPoint
	{
		get { return originHealthPoint; }
	}
	//use quick status health bar
	public float PresentHealthPoint
	{
		get { return( presentHealthPoint / originHealthPoint ); }
	}

	public float PresentResourcePoint
	{
		get { return ( presentResourcePoint / originResourcePoint ); }
	}

	public float CriticalProability
	{
		get { return criticalProability; }
	}

	public int Strength
	{
		get { return presentStrength; }
	}

	public int Dexterity
	{
		get { return presentDexterity; }
	}

	public int Luck
	{
		get{ return presentLuck; }
	}

	public int ComboCounter
	{
		get { return comboCounter; }
		set { comboCounter = value; }
	}

	public float ComboTimeFill
	{
		get { return comboTime; }
		set { comboTime = value; }
	}

	public Item TopInstall
	{
		get { return topInstall; }
		set { topInstall = value; }
	}

	public Item BottomInstall
	{
		get { return bottomInstall; }
		set { bottomInstall = value; }
	}

	public Item BladeInstall
	{
		get { return bladeInstall; }
		set { bladeInstall = value; }
	}

	public Item HandleInstall
	{
		get { return handleInstall; }
		set { handleInstall = value; }
	}

	public Item[] CharacterItem
	{
		get { return characterItem; }
	}

	public int Money
	{
		get { return money; }
	}

	public bool InstalledItem
	{
		get { return installedItem; }
		set { installedItem = value; }
	}

	//char skill infor mation
	//slot set up skill
	Skill[] charSkill;
	
	//data base
	DataBase dataBase;
	bool installedItem;

	void Start()
	{
		characterItem = new Item[35];
		charSkill = new Skill[8];
		DefaultStatus();
		dataBase = GameObject.FindWithTag( "DataBase" ).GetComponent<DataBase>();
	}

	//set default status
	public void	DefaultStatus()
	{
		characterName = "Faye";
		characterLevel = 1;

		presentHealthPoint = 50.0f;
		originHealthPoint = 50.0f;
		presentResourcePoint = 30.0f;
		originResourcePoint = 30.0f;
		criticalProability = 0.0f;

		exp = 0.0f;

		presentStrength = 150; 
		presentIntelligence = 150;
		presentDexterity = 5;
		presentLuck = 5;
		
		presentDamage	= 30.0f;	
		money = 0;

	}

	//set default item
	public void InstallDefaultItem()
	{
		topInstall = new Item ( dataBase.FindItem( "TheHolySpear" ) );
		bottomInstall = new Item ( dataBase.FindItem( "DropOfSorcerer" ) );
		bladeInstall = new Item ( dataBase.FindItem( "FearBlade" ) );
		handleInstall = new Item ( dataBase.FindItem( "IronHandle" ) );

		for (int i = 0; i < characterItem.Length; i++)
			characterItem[i] = new Item ();	

		installedItem = true;
	}

	//save data load and apply
	public void LoadCharacterInformation()
	{

	}

}
