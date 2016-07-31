using UnityEngine;
using System.Collections;

[System.Serializable]
public class Skill
{
	//id
	public int id;
	//name
	public string name;

	//icon
	public Sprite icon;
	public Sprite information;

	//data
	public int learnLevel;
	public float coolTime;
	public float damage;
	public float resource;
	public int resourceComboCounter;
	public Classify type;

	public enum Classify
	{
		Default,
		Active,
		SpecialActive,
		Passive,
		Buff}
	;
	//property
	public int Id
	{
		get { return id; }
	}

	public string Name
	{
		get { return name; }
	}

	public int LearnLevel
	{
		get { return learnLevel; }
	}

	public Sprite Icon
	{
		get { return icon; }
	}

	public Sprite Information
	{
		get { return information; }
	}

	public float CoolTime
	{
		get { return coolTime; }
	}

	public float Damage
	{
		get { return damage; }
	}

	public float SkillResource
	{
		get { return resource; }	
	}

	public int SkillComboResource
	{
		get { return resourceComboCounter; }
	}

	public Classify Type
	{
		get { return type; }
	}

	//constructor - no parameter (default)
	public Skill ()
	{
		id = 0;
		name = "Default";
		learnLevel = 0;
		coolTime = 0f;
		damage = 0f;
		resource = 0f;
		resourceComboCounter = 0;
		type = Classify.Default;
	}
	
	//constructor - all parameter
	public Skill (int _id, string _name, int _learnLevel, float _coolTime, float _damage, float _resource, int _resourceComboCounter, Classify _type)
	{
		id = _id;
		name = _name;
		learnLevel = _learnLevel;
		coolTime = _coolTime;
		damage = _damage;
		resource = _resource;
		resourceComboCounter = _resourceComboCounter;
		type = _type;
	}

	//constructor - self parameter
	public Skill (Skill data)
	{
		id = data.id;
		name = data.name;
		learnLevel = data.learnLevel;
		coolTime = data.coolTime;
		damage = data.damage;
		resource = data.resource;
		resourceComboCounter = data.resourceComboCounter;
		type = data.type;
		icon = data.icon;
	}
	
	//set icon
	public void SetSpriteIcon()
	{
		string path = "Skill/Skill" + name;
		Sprite temp = Resources.Load<Sprite>( path );
		icon = temp;
	}

	
}