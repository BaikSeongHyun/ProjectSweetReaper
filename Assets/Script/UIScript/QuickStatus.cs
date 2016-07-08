using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuickStatus : MonoBehaviour
{
	//complex field
	public Text characterName;
	public Text level;
	public Image healthBar;
	public Image resourceBar;

	//property
	// initialize this script
	void Start()
	{
		LinkElement();
	}

	public void LinkElement()
	{
		characterName = transform.Find( "QuickCharacterNameText" ).GetComponent<Text>();
		level = transform.Find( "QuickLevelText" ).GetComponent<Text>();
		healthBar = transform.Find( "HealthPointBar" ).GetComponent<Image>();
		resourceBar = transform.Find( "ResourcePointBar" ).GetComponent<Image>();
	}

	public void UpdateQuickStatusInfo(CharacterInformation info)
	{
		characterName.text = info.CharacterName;
		level.text = info.Level.ToString();
		healthBar.fillAmount = info.PresentHealthPoint;
		resourceBar.fillAmount = info.PresentResourcePoint;
	}
}
