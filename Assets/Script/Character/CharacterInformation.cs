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
	public Item[] characterItem;
	int money;
		
	//char skill infor mation
	//slot set up skill
	public Skill[] characterSkill;
	public Skill[] installSkill;

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

	public float PresentHealthPoint
	{
		get { return presentHealthPoint; }
		set { presentHealthPoint = value; }
	}
	//use quick status health bar
	public float FillHealthPoint
	{
		get { return(presentHealthPoint / originHealthPoint); }
	}

	public float OriginResourcePoint
	{
		get { return originResourcePoint; }
	}

	public float PresentResourcePoint
	{
		get { return presentResourcePoint; }
		set { presentResourcePoint = value; }
	}
	//use quick status resource bar
	public float FillResourcePoint
	{
		get { return (presentResourcePoint / originResourcePoint); }
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
		set { money = value; }
	}

	public bool InstalledItem
	{
		get { return installedItem; }
		set { installedItem = value; }
	}

	public Skill[] CharacterSkill
	{
		get { return characterSkill; }
	}

	public Skill[] InstallSkill
	{
		get { return installSkill; }
		set { installSkill = value; }
	}

	
	//data base
	DataBase dataBase;
	bool installedItem;

	void Start()
	{
		characterItem = new Item[35];
		characterSkill = new Skill[9];
		DefaultStatus();
		dataBase = GameObject.FindWithTag( "DataBase" ).GetComponent<DataBase>();
	}

	//set default status
	public void	DefaultStatus()
	{
		characterName = "Faye";
		characterLevel = 5;

		presentHealthPoint = 2614.0f;
		originHealthPoint = 2614.0f;
		presentResourcePoint = 120.0f;
		originResourcePoint = 120.0f;
		criticalProability = 10.0f;

		presentExp = 345.0f;
		requireExp = 4035.0f;
		
		presentStrength = 35; 
		presentIntelligence = 25;
		presentDexterity = 25;
		presentLuck = 15;
		
		presentDamage = 85.0f;	
		money = 1203;

	}

	//set default item
	public void InstallDefaultItem()
	{
		topInstall = new Item(dataBase.FindItem( "TheHolySpear" ));
		bottomInstall = new Item(dataBase.FindItem( "DropOfSorcerer" ));
		bladeInstall = new Item(dataBase.FindItem( "FearBlade" ));
		handleInstall = new Item(dataBase.FindItem( "IronHandle" ));

		for (int i = 0; i < characterItem.Length; i++)
			characterItem[i] = new Item(dataBase.FindItem( "Default" ));	

		installedItem = true;
	}

	public void SetDefaultSkill()
	{
		for (int i = 0; i < characterSkill.Length; i++)
			characterSkill[i] = new Skill(dataBase.FindSkill( "Default" ));
		
		for (int i = 0; i < installSkill.Length; i++)
			installSkill[i] = new Skill(dataBase.FindSkill( "Default" ));
	}

	public bool AddItem( Item item )
	{
		for (int i = 0; i < characterItem.Length; i++)
		{
			if (characterItem[i].Name == "Default")
			{
				characterItem[i] = new Item(item);
				return true;
			}
		}
		
		return false;
	}

	//save data load and apply
	public void LoadCharacterInformation()
	{

	}

}
