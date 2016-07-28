using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuickSkillChain : MonoBehaviour
{
	public Image comboCheck;
	public Image comboGaugeFill;
	public Image[] comboPointElement;
	public bool overChain = false;


	public void LinkElement()
	{
		comboCheck = transform.Find( "ChainText" ).GetComponent<Image>();
		comboGaugeFill = transform.Find( "SkillChainFill" ).GetComponent<Image>();
		comboPointElement = new Image[4];
		for (int i = 0; i < comboPointElement.Length; i++)
		{
			string elementName = "ComboCounter" + ( 1 + i ).ToString();
			comboPointElement[i] = transform.Find( elementName ).GetComponent<Image>();
		}			
	}
	
	//control element
	public void ControlComponent( bool state )
	{
		comboGaugeFill.enabled = state;	
		for (int i = 0; i < comboPointElement.Length; i++)
			comboPointElement[i].enabled = state;
	}

	//update component data
	public void UpdateSkillChain( CharacterInformation info )
	{
		ControlComponent( false );
		
		//combo gauge set up
		comboGaugeFill.enabled = true;
		comboGaugeFill.fillAmount = info.ComboTimeFill;
		
		//combo point set up
		for (int i = 0; i < info.ComboCounter; i++)
			comboPointElement[i].enabled = true;

		switch (info.ComboCounter)
		{
			case 0:
				comboCheck.enabled = false;
				overChain = false;
				break;
			case 1:
				comboCheck.enabled = true;
				comboCheck.sprite = Resources.Load<Sprite>( "Skill/ChainText1" );
				break;
			case 2:
				comboCheck.sprite = Resources.Load<Sprite>( "Skill/ChainText2" );
				break;
			case 3:
				comboCheck.sprite = Resources.Load<Sprite>( "Skill/ChainText3" );
				break;
			case 4:
				if (!info.OverChain)
					comboCheck.sprite = Resources.Load<Sprite>( "Skill/ChainText4" );
				else
					comboCheck.sprite = Resources.Load<Sprite>( "Skill/ChainTextOver" );	

				break;
		}
	}
}
