using UnityEngine;
using System;
using System.Collections;

public class CharacterInformation : MonoBehaviour
{
	// char status
	//name
	public string characterName;

	//level
	public int characterLevel;

	//exp
	public float presentExp;
	float requireExp;

	//damage
	public float presentDamage;
	float rootDamage;

	//hp - use public for test
	public float presentHealthPoint;
	float rootHealthPoint;
	public float originHealthPoint;


	//rp - for use skill
	public float presentResourcePoint;
	float rootResourcePoint;
	public float originResourcePoint;

	//critical proability
	float rootCriticalProability;
	public float presentCriticalProability;
		
	//str
	int rootStrength;
	public int presentStrength;
		
	//intell
	int rootIntelligence;
	public int presentIntelligence;

	public int Intelligence
	{
		get { return presentIntelligence; }
	}
	
	//dex
	int rootDexterity;
	public int presentDexterity;
		
	//luck
	int rootLuck;
	public int presentLuck;

	//chain information
	int comboCounter;
	public float comboTime;
	bool overChain;

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
	public bool[] onSkill;
	public float[] skillCoolTimeSet;
	
	
	//property

	public string CharacterName
	{
		get { return characterName; }
	}

	public int Level
	{
		get { return characterLevel; }
	}

	public float ExpFill
	{
		get { return presentExp / requireExp; }
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
		get { return( presentHealthPoint / originHealthPoint ); }
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
		get { return ( presentResourcePoint / originResourcePoint ); }
	}

	public float CriticalProability
	{
		get { return presentCriticalProability; }
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

	public bool OverChain
	{
		get { return overChain; }
		set { overChain = value; }
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

	public Skill[] CharacterSkill
	{
		get { return characterSkill; }
	}

	public Skill[] InstallSkill
	{
		get { return installSkill; }
		set { installSkill = value; }
	}

	public bool[] OnSkill
	{
		get { return onSkill; }
		set{ onSkill = value; }
	}

	public float[] SkillCoolTime
	{
		get { return skillCoolTimeSet; }
		set { skillCoolTimeSet = value; }
	}

	void Start()
	{
		InitializeData();
		PlayerPrefs.DeleteAll();
		LoadCharacterInformation();

	}

	//initialize data
	public void InitializeData()
	{
		characterItem = new Item[35];
		characterSkill = new Skill[9];
		installSkill = new Skill[8];

		onSkill = new bool[8];
		skillCoolTimeSet = new float[onSkill.Length];

		for (int i = 0; i < onSkill.Length; i++)
		{
			installSkill[i] = new Skill ();
			onSkill[i] = false;
			skillCoolTimeSet[i] = 0.0f;
		}
	}

	//set default status
	public void	DefaultStatus()
	{
		characterName = "Faye";
		characterLevel = 1;

		presentHealthPoint = 1000.0f;
		originHealthPoint = 1000.0f;
		presentResourcePoint = 200.0f;
		originResourcePoint = 200.0f;
		rootCriticalProability = 0.0f;

		presentExp = 0.0f;
		requireExp = 3000.0f;
		
		rootStrength = 20; 
		rootIntelligence = 20;
		rootDexterity = 20;
		rootLuck = 20;
		
		rootDamage = 20.0f;	
		money = 1000;

		InstallDefaultItem();
		SetDefaultSkill();
	}

	//set default item
	public void InstallDefaultItem()
	{
		bladeInstall = new Item ();
		bottomInstall = new Item ();
		topInstall = new Item ();
		handleInstall = new Item ();

		for (int i = 0; i < characterItem.Length; i++)
			characterItem[i] = new Item ();
	}

	public void SetDefaultSkill()
	{
		for (int i = 0; i < characterSkill.Length; i++)
			characterSkill[i] = new Skill ();
	}

	public bool AddItem( Item item )
	{
		for (int i = 0; i < characterItem.Length; i++)
		{
			if (characterItem[i].Name == "Default")
			{
				characterItem[i] = new Item ( item );
				return true;
			}
		}
		
		return false;
	}

	public void UpdateStatus( Item item, int mode )
	{
		if (mode == 0)
		{
			presentDamage = rootDamage + item.WeaponAtk;
			originHealthPoint = rootHealthPoint + item.WeaponDef;
			presentStrength = rootStrength + item.WeaponStr;
			presentDexterity = rootDexterity + item.WeaponDex;
			presentIntelligence = rootIntelligence + item.WeaponInt;
			presentLuck = rootLuck + item.WeaponLuck;
			presentCriticalProability = rootCriticalProability + item.WeaponCri;
		}
		else if (mode == 1)
		{
			presentDamage += item.WeaponAtk;
			originHealthPoint += item.WeaponDef;
			presentStrength += item.WeaponStr;
			presentDexterity += item.WeaponDex;
			presentIntelligence += item.WeaponInt;
			presentLuck += item.WeaponLuck;
			presentCriticalProability += item.WeaponCri;
		}
	}

	public void UpdateInventoryStatus()
	{
		UpdateStatus( topInstall, 0 );
		UpdateStatus( bottomInstall, 1 );
		UpdateStatus( bladeInstall, 1 );
		UpdateStatus( handleInstall, 1 );
	}

	public bool CheckSkillResource( int index )
	{
		if (presentResourcePoint >= installSkill[index].SkillResource)
			return true;
		else
			return false;
	}
	
	//save data load and apply
	public void LoadCharacterInformation()
	{
		try
		{
			characterName = PlayerPrefs.GetString( "characterName" );
			characterLevel = PlayerPrefs.GetInt( "characterLevel" );
			presentExp = PlayerPrefs.GetFloat( "presentExp" );
			requireExp = PlayerPrefs.GetFloat( "requireExp" );

			presentDamage = PlayerPrefs.GetFloat( "presentDamage" );
			rootDamage = PlayerPrefs.GetFloat( "rootDamage" );
			presentHealthPoint = PlayerPrefs.GetFloat( "presentHealthPoint" );
			rootHealthPoint = PlayerPrefs.GetFloat( "rootHealthPoint" );
			originHealthPoint = PlayerPrefs.GetFloat( "originHealthPoint" );
			presentResourcePoint = PlayerPrefs.GetFloat( "presentResourcePoint" );
			rootResourcePoint = PlayerPrefs.GetFloat( "rootResourcePoint" );
			originResourcePoint = PlayerPrefs.GetFloat( "originResourcePoint" );
			rootCriticalProability = PlayerPrefs.GetFloat( "rootCriticalProability" );
			presentCriticalProability = PlayerPrefs.GetFloat( "presentCriticalProability" );

			rootStrength = PlayerPrefs.GetInt( "rootStrength" );
			presentStrength = PlayerPrefs.GetInt( "presentStrength" );
			rootIntelligence = PlayerPrefs.GetInt( "rootIntelligence" );
			presentIntelligence = PlayerPrefs.GetInt( "presentIntelligence" );
			rootDexterity = PlayerPrefs.GetInt( "rootDexterity" );
			presentDexterity = PlayerPrefs.GetInt( "presentDexterity" );
			rootLuck = PlayerPrefs.GetInt( "rootLuck" );
			presentLuck = PlayerPrefs.GetInt( "presentLuck" );

			topInstall = new Item ( DataBase.Instance.FindItemById( PlayerPrefs.GetInt( "topInstall" ) ) );
			bottomInstall = new Item ( DataBase.Instance.FindItemById( PlayerPrefs.GetInt( "bottomInstall" ) ) );
			bladeInstall = new Item ( DataBase.Instance.FindItemById( PlayerPrefs.GetInt( "bladeInstall" ) ) );
			handleInstall = new Item ( DataBase.Instance.FindItemById( PlayerPrefs.GetInt( "handleInstall" ) ) );

			money = PlayerPrefs.GetInt( "money" );

			for (int i = 0; i < characterItem.Length; i++)
			{
				string temp = "characterItem" + i.ToString();
				if (PlayerPrefs.GetInt( temp ) == 0)
					characterItem[i] = new Item ();
				else
					characterItem[i] = new Item ( DataBase.Instance.FindItemById( PlayerPrefs.GetInt( temp ) ) );
			}

			for (int i = 0; i < characterSkill.Length; i++)
			{
				string temp = "characterSkill" + i.ToString();
				if (PlayerPrefs.GetInt( temp ) == 0)
					characterSkill[i] = new Skill ();
				else
					characterSkill[i] = new Skill ( DataBase.Instance.FindSkillById( PlayerPrefs.GetInt( temp ) ) );			
			}

			for (int i = 0; i < installSkill.Length; i++)
			{
				string temp = "installSkill" + i.ToString();
				if (PlayerPrefs.GetInt( temp ) == 0)
					installSkill[i] = new Skill ();
				else
					installSkill[i] = new Skill ( DataBase.Instance.FindSkillById( PlayerPrefs.GetInt( temp ) ) );
			}
		}
		catch (NullReferenceException e)
		{
			Debug.Log( e.InnerException );
			DefaultStatus();
		}
	}

	public void SaveCharacterInformation()
	{
		PlayerPrefs.SetString( "characterName", characterName );
		PlayerPrefs.SetInt( "characterLevel", characterLevel );
		PlayerPrefs.SetFloat( "presentExp", presentExp );
		PlayerPrefs.SetFloat( "requireExp", requireExp );

		PlayerPrefs.SetFloat( "presentDamage", presentDamage );
		PlayerPrefs.SetFloat( "rootDamage", rootDamage );
		PlayerPrefs.SetFloat( "presentHealthPoint", presentHealthPoint );
		PlayerPrefs.SetFloat( "rootHealthPoint", rootHealthPoint );
		PlayerPrefs.SetFloat( "originHealthPoint", originHealthPoint );
		PlayerPrefs.SetFloat( "presentResourcePoint", presentResourcePoint );
		PlayerPrefs.SetFloat( "rootResourcePoint", rootResourcePoint );
		PlayerPrefs.SetFloat( "originResourcePoint", originResourcePoint );
		PlayerPrefs.SetFloat( "rootCriticalProability", rootCriticalProability );
		PlayerPrefs.SetFloat( "presentCriticalProability", presentCriticalProability );

		PlayerPrefs.SetInt( "rootStrength", rootStrength );
		PlayerPrefs.SetInt( "presentStrength", presentStrength );
		PlayerPrefs.SetInt( "rootIntelligence", rootIntelligence );
		PlayerPrefs.SetInt( "presentIntelligence", presentIntelligence );
		PlayerPrefs.SetInt( "rootDexterity", rootDexterity );
		PlayerPrefs.SetInt( "presentDexterity", presentDexterity );
		PlayerPrefs.SetInt( "rootLuck", rootLuck );
		PlayerPrefs.SetInt( "presentLuck", presentLuck );

		PlayerPrefs.SetInt( "topInstall", topInstall.Id );
		PlayerPrefs.SetInt( "bottomInstall", bottomInstall.Id );
		PlayerPrefs.SetInt( "bladeInstall", bladeInstall.Id );
		PlayerPrefs.SetInt( "handleInstall", handleInstall.Id );

		for (int i = 0; i < characterItem.Length; i++)
		{
			string temp = "characterItem" + i.ToString();
			PlayerPrefs.SetInt( temp, characterItem[i].Id );
		}

		PlayerPrefs.SetInt( "money", money );

		for (int i = 0; i < characterSkill.Length; i++)
		{
			string temp = "characterSkill" + i.ToString();
			PlayerPrefs.SetInt( temp, characterSkill[i].Id );
		}

		for (int i = 0; i < installSkill.Length; i++)
		{
			string temp = "installSkill" + i.ToString();
			PlayerPrefs.SetInt( temp, installSkill[i].Id );
		}

		PlayerPrefs.Save();
	}
}
