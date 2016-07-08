using UnityEngine;
using System.Collections;

public class CharacterInformation : MonoBehaviour
{
	// char status
	//name
	string characterName;

	public string CharacterName
	{
		get { return characterName; }
	}
	//level
	int characterLevel;

	public int Level
	{
		get { return characterLevel; }
	}
	//exp
	float exp;
	float presentExp;
	float requireExp;

	//damage
	float presentDamage;
	float rootDamage;

	public float Damage
	{
		get { return presentDamage; }
	}
	//hp - use public for test
	public float presentHealthPoint;
	float rootHealthPoint;
	float originHealthPoint;

	public float OriginHealthPoint
	{
		get { return originHealthPoint; }
	}
	//use quick status health bar
	public float PresentHealthPoint
	{
		get { return(presentHealthPoint / originHealthPoint); }
	}

	//rp - for use skill
	public float presentResourcePoint;
	float rootResourcePoint;
	float originResourcePoint;

	public float OriginResourcePoint
	{
		get { return originResourcePoint; }
	}
	//use quick status resource bar
	public float PresentResourcePoint
	{
		get { return (presentResourcePoint / originResourcePoint); }
	}
	//critical proability
	float criticalProability;

	public float CriticalProability
	{
		get { return criticalProability; }
	}
	
	//str
	int rootStrength;
	int presentStrength;

	public int Strength
	{
		get { return presentStrength; }
	}
	
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

	public int Dexterity
	{
		get { return presentDexterity; }
	}
	
	//luck
	int rootLuck;
	int presentLuck;

	public int Luck
	{
		get{ return presentLuck; }
	}
	
	//chain information
	int comboCounter;

	public int ComboCounter
	{
		get {
			Debug.Log(comboCounter);
			return comboCounter; }
		set { comboCounter = value; }
	}

	public float comboTime;

	public float ComboTimeFill
	{
		get { return comboTime; }
		set { comboTime = value; }
	}

	//char Inventory information
	//Installed item
	Item topInstall;
	Item bottomInstall;
	Item bladeInstall;
	Item handleInstall;

	public Item TopInstall
	{
		get { return topInstall; }
	}

	public Item BottomInstall
	{
		get { return BottomInstall; }
	}

	public Item BladeInstall
	{
		get { return bladeInstall; }
	}

	public Item HandleInstall
	{
		get { return handleInstall; }
	}
	
	// have item
	Item[] characterItem;
	int money;

	public Item[] CharacterItem
	{
		get { return characterItem; }
	}

	public int Money
	{
		get { return money; }
	}

	//char skill infor mation
	//slot set up skill
	Skill[] charSkill;
	
	
	//property

	void Start()
	{
		characterItem = new Item[35];
		charSkill = new Skill[8];
		DefaultStatus();
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

		topInstall = null;
		bottomInstall = null;
		bladeInstall = null;
		handleInstall = null;
	}

	//save data load and apply
	public void LoadCharacterInformation()
	{

	}

}
