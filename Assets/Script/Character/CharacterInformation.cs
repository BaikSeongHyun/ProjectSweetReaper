using UnityEngine;
using System.Collections;

public class CharacterInformation : MonoBehaviour
{
	// char status
	//name
	string characterName;

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
		characterItem = new Item[35];
		characterSkill = new Skill[9];
		installSkill = new Skill[8];
		DefaultStatus();
	}

	//set default status
	public void	DefaultStatus()
	{
		characterName = "Faye";
		characterLevel = 4;

		presentHealthPoint = 2614.0f;
		originHealthPoint = 2614.0f;
		presentResourcePoint = 600.0f;
		originResourcePoint = 600.0f;
		rootCriticalProability = 10.0f;

		presentExp = 345.0f;
		requireExp = 4035.0f;
		
		rootStrength = 35; 
		rootIntelligence = 25;
		rootDexterity = 25;
		rootLuck = 15;
		
		rootDamage = 85.0f;	
		money = 1203;

		InstallDefaultItem();
		SetDefaultSkill();

	}

	//set default item
	public void InstallDefaultItem()
	{
		bladeInstall = DataBase.Instance.FindItemByName( "FearBlade" );
		bottomInstall = DataBase.Instance.FindItemByName( "DropOfSorcerer" );
		topInstall = DataBase.Instance.FindItemByName( "TheHolySpear" );
		handleInstall = DataBase.Instance.FindItemByName( "IronHandle" );

		for (int i = 0; i < characterItem.Length; i++)
			characterItem[i] = new Item();
	}

	public void SetDefaultSkill()
	{
		characterSkill[0] = DataBase.Instance.FindSkill( 0 );
		characterSkill[1] = DataBase.Instance.FindSkill( 1 );
		characterSkill[2] = DataBase.Instance.FindSkill( 2 );
		characterSkill[3] = DataBase.Instance.FindSkill( 3 );
		characterSkill[4] = DataBase.Instance.FindSkill( 4 );
		characterSkill[5] = DataBase.Instance.FindSkill( 5 );

		for (int i = 6; i < characterSkill.Length; i++)
			characterSkill[i] = new Skill();
		
		
		onSkill = new bool[8];
		skillCoolTimeSet = new float[onSkill.Length];

		for (int i = 0; i < onSkill.Length; i++)
		{
			onSkill[i] = false;
			skillCoolTimeSet[i] = 0.0f;
		}

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

	public void UpdateStatus( Item item )
	{
		presentDamage = rootDamage + item.WeaponAtk;
		originHealthPoint = rootHealthPoint + item.WeaponDef;
		presentStrength = rootStrength + item.WeaponStr;
		presentDexterity = rootDexterity + item.WeaponDex;
		presentIntelligence = rootIntelligence + item.WeaponInt;
		presentLuck = rootLuck + item.WeaponLuck;
		presentCriticalProability = rootCriticalProability + item.WeaponCri;
	}

	public void UpdateInventoryStatus()
	{
		UpdateStatus( topInstall );
		UpdateStatus( bottomInstall );
		UpdateStatus( bladeInstall );
		UpdateStatus( handleInstall );
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

	}

}
