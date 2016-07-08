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

	//update component data
	public void UpdateSkillChain()
	{

	}
}
