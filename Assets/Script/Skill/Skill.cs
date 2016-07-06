using UnityEngine;
using System.Collections;

[System.Serializable]
public class Skill
{
	//name
	public string name;

	//icon
	public Sprite icon;

	//data
	public float coolTime;
	public float damage;
	public float resource;
	public STATE state;

	public enum STATE
	{
		Active,
		Passive,
		Buff}
;

	//constructor - no parameter
	public Skill ()
	{

	}

	//constructor - self parameter
	public Skill (Skill data)
	{
		name = data.name;
		coolTime = data.coolTime;
		damage = data.damage;
		resource = data.resource;
	}

	//property
	public string Name
	{
		get { return name; }
	}
}