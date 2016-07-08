using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuickSkillChain : MonoBehaviour
{
	public Image comboGaugeFill;
	public Image[] comboPointElement;
	

	// initialization this script
	void Start()
	{
		comboGaugeFill = transform.Find( "SkillChainFill" ).GetComponent<Image>();
		comboPointElement = new Image[4];
		for (int i = 0; i < comboPointElement.Length; i++)
		{
			string elementName = "ComboCounter" + (1 + i).ToString();
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
	public void UpdateSkillChain(CharacterInformation info)
	{
		ControlComponent( false );
		
		//combo gauge set up
		comboGaugeFill.enabled = true;
		comboGaugeFill.fillAmount = info.ComboTimeFill;
		
		//combo point set up
		for (int i = 0; i < info.ComboCounter; i++)
			comboPointElement[i].enabled = true;
	}
}
