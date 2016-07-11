using UnityEngine;
using System.Collections;

[System.Serializable]
public class Skill
{
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
	public STATE state;

	public enum STATE
	{
		Default,
		Active,
		Passive,
		Buff}
	;
	//property
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

	//constructor - no parameter
	public Skill ()
	{
		name = "Default";
		learnLevel = 0;
		coolTime = 0f;
		damage = 0f;
		resource = 0f;
		state = STATE.Default;
	}
	
	//constructor - all parameter
	public Skill (string _name, int _learnLevel, float _coolTime, float _damage, float _resource, STATE _state)
	{
		name = _name;
		learnLevel = _learnLevel;
		coolTime = _coolTime;
		damage = _damage;
		resource = _resource;
		state = _state;
	}

	//constructor - self parameter
	public Skill (Skill data)
	{
		name = data.name;
		learnLevel = data.learnLevel;
		coolTime = data.coolTime;
		damage = data.damage;
		resource = data.resource;
		state = data.state;
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