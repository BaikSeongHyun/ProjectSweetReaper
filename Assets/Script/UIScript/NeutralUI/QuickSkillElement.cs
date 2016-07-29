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

	public override void UpdateSkillElement( CharacterInformation info, int index )
	{
		if (info.OnSkill[index])
		{
			setUse.enabled = true;
			coolTime.enabled = true;
			coolTime.text = string.Format( "{0:###.0}", info.InstallSkill[index].CoolTime - info.SkillCoolTime[index] );
		}
		else
		{
			setUse.enabled = false;
			coolTime.enabled = false;
		}
	}
}
