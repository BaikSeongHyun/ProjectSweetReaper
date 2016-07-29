using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillElement : MonoBehaviour
{
	//complex data field
	public SkillInformationPopUpControl skillPopUp;
	public Image skillIcon;
	public Skill skillInfo;

	//property
	public Skill SkillInfo
	{
		get { return skillInfo; }
		set { skillInfo = value; }
	}

	public Image SkillIcon
	{
		get { return skillIcon; }
	}

	public virtual void LinkElement()
	{
		skillPopUp = GameObject.Find( "SkillPopUp" ).GetComponent<SkillInformationPopUpControl>();		
		skillIcon = GetComponent<Image>();
	}

	public void UpdateSkillPopUp( CharacterInformation info )
	{
		if (skillInfo.Name == "Default")
			return;
		if (skillInfo.LearnLevel > info.Level)
			return;
		
		skillPopUp.LinkElement();
		skillPopUp.ControlComponent( true );
		skillPopUp.UpdateSkillInformation( skillInfo, transform.position );
	}

	public void CloseSkillPopUp()
	{
		skillPopUp.ControlComponent( false );	
	}

	public void UpdateSkillIcon( CharacterInformation info, Sprite data )
	{		
		skillInfo.SetSpriteIcon();
		SkillIcon.sprite = skillInfo.Icon;
		if (skillInfo.Name == "Default" || skillInfo.LearnLevel > info.Level)
			skillIcon.sprite = data;
	}

	public virtual void UpdateSkillElement( CharacterInformation info, int index )
	{
	}

	//use default only
	public void UpdateDefaultSkillIcon( Sprite data )
	{		
		skillIcon.sprite = data;
	}
}
