using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillInformationPopUpControl : MonoBehaviour
{
	//pop up component
	public Image skillInformation;
	
	//link all component
	public void LinkElement()
	{
		skillInformation = transform.Find( "SkillInformation" ).GetComponent<Image>();
	}

	public void ControlComponent( bool state )
	{
		skillInformation.enabled = state;
	}

	public void UpdateSkillInformation( Skill info, Vector3 popUpPosition )
	{
		//position set
		transform.position = popUpPosition + new Vector3(50f, -50f);
		
		if (info == null)
			return;
		else
		{
			ControlComponent( true );
			skillInformation.sprite = Resources.Load<Sprite>( "Skill/SkillInfomation" + info.Name );
		}
	}

}
