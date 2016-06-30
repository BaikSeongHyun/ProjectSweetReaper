using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusUI : MonoBehaviour
{
	CharacterInformation info;
	Text characterName;
	Text level;
	Text damage;
	Text healthPoint;
	Text resourcePoint;
	Text criticalProability;
	Text strength;
	Text intelligence;
	Text dexterity;
	Text luck;

	// Use this for initialization
	void Start( )
	{
		info = GameObject.FindWithTag( "Player" ).GetComponent<CharacterInformation>();
	}
	
	public void LinkElement()
	{
		characterName = transform.Find("CharacterNameText").GetComponent<Text>();
		level = transform.Find("LevelText").GetComponent<Text>();
		damage = transform.Find("DamageText").GetComponent<Text>();
		healthPoint = transform.Find("HealthPointText").GetComponent<Text>();
		resourcePoint = transform.Find("ResourcePointText").GetComponent<Text>();
		criticalProability = transform.Find("CriticalProabilityText").GetComponent<Text>();
		strength = transform.Find("StrengthText").GetComponent<Text>();
		intelligence = transform.Find("IntelligenceText").GetComponent<Text>();
		dexterity = transform.Find("DexterityText").GetComponent<Text>();
		luck = transform.Find("LuckText").GetComponent<Text>();
	}
		

	public void UpdateStatusInfo()
	{
		characterName.text = info.CharacterName;
		level.text = info.Level.ToString();
		damage.text = info.Damage.ToString();
		healthPoint.text = info.OriginHealthPoint.ToString();
		resourcePoint.text  = info.OriginResourcePoint.ToString();
		criticalProability.text  = info.CriticalProability.ToString();
		strength.text = info.Strength.ToString();
		intelligence.text = info.Intelligence.ToString();
		dexterity.text = info.Dexterity.ToString();
		luck.text = info.Luck.ToString();		
	}
}
