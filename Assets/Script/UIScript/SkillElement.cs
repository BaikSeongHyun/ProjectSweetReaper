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
	// initialize this script
	void Start()
	{		
		skillPopUp = GameObject.Find( "SkillPopUp" ).GetComponent<SkillInformationPopUpControl>();		
	}

	public void UpdateSkillPopUp()
	{
		if (skillInfo.Name == " Default")
			return;
		
		skillPopUp.LinkElement();
		skillPopUp.ControlComponent( true );
		skillPopUp.UpdateSkillInformation( skillInfo, transform.position );
	}

	public void CloseSkillPopUp()
	{
		skillPopUp.ControlComponent( false );	
	}

	public void UpdateSkillIcon(CharacterInformation info)
	{
		skillIcon = GetComponent<Image>();
		skillInfo.SetSpriteIcon();
		SkillIcon.sprite = skillInfo.Icon;
		if (skillInfo.Name == "Default" || skillInfo.LearnLevel >= info.Level)
			skillIcon.sprite = Resources.Load<Sprite>( "Skill/SkillDefault" );

	}

	//use default only
	public void UpdateDefaultSkillIcon( Sprite data )
	{
		skillIcon = GetComponent<Image>();
		skillIcon.sprite = data;
	}
}
