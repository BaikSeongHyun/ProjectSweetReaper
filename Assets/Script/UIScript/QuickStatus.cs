using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuickStatus : MonoBehaviour
{
	CharacterInformation info;
	Text characterName;
	Text level;
	Image healthBar;
	Image resourceBar;


	// initialize this script
	void Start( )
	{
		info = GameObject.FindWithTag( "Player" ).GetComponent<CharacterInformation>();
		LinkElement();
	}

	public void LinkElement()
	{
		characterName = transform.Find( "QuickCharacterNameText" ).GetComponent<Text>();
		level = transform.Find( "QuickLevelText" ).GetComponent<Text>();
		healthBar = transform.Find( "HealthPointBar" ).GetComponent<Image>();
		resourceBar = transform.Find( "ResourcePointBar" ).GetComponent<Image>();
	}

	public void UpdateQuickStatusInfo()
	{
		characterName.text = info.CharacterName;
		level.text = info.Level.ToString();
		healthBar.fillAmount = info.PresentHealthPoint;
		resourceBar.fillAmount = info.PresentResourcePoint;
	}
}
