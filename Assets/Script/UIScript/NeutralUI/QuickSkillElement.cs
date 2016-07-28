using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuickSkillElement : SkillElement
{
	public Text coolTime;
	public Image setUse;

	public override void LinkElement()
	{
		skillPopUp = GameObject.Find( "SkillPopUp" ).GetComponent<SkillInformationPopUpControl>();		
		skillIcon = GetComponent<Image>();
		coolTime = transform.Find( "CoolTime" ).GetComponent<Text>();
		setUse = transform.Find( "SetUse" ).GetComponent<Image>();
	}

	public override void UpdateSkillIcon(CharacterInformation info)
	{
		if (skillInfo.Name == " Default")
			return;

		skillPopUp.LinkElement();
		skillPopUp.ControlComponent( true );
		skillPopUp.UpdateSkillInformation( skillInfo, transform.position );

	}
}
