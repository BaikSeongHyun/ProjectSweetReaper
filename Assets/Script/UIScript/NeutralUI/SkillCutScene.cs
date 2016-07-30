using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillCutScene : MonoBehaviour
{
	public bool onSkill;
	public bool firstMove;
	public bool secondMove;
	public Vector3 firstPoint;
	public Vector3 secondPoint;
	public Vector3 thirdPoint;
	public Color startColor;
	public Color endColor;
	public float cutTime;
	public float skillTime;
	public Image cutSceneImage;

	public void LinkElement()
	{
		onSkill = false;
		
		firstPoint = new Vector3(1500f, -50f, 0f);
		secondPoint = new Vector3(500, -50f, 0f);
		thirdPoint = new Vector3(300, -50f, 0f);
		
		cutSceneImage = transform.Find( "CutSceneImage" ).GetComponent<Image>();
		cutSceneImage.transform.localPosition = firstPoint;
		startColor = cutSceneImage.color;
		endColor = cutSceneImage.color;
		endColor.a = 0;
		cutSceneImage.color = endColor;
	}

	public void InitalizeData()
	{	
		cutSceneImage.transform.localPosition = firstPoint;
		onSkill = false;
		firstMove = false;
		secondMove = false;
		skillTime = 0.0f;	
	}

	public void ActiveSkillCutScene()
	{
		onSkill = true;
		firstMove = false;
		secondMove = false;
	}

	public void UpdateSkillCutScene()
	{
		if (onSkill)
		{
			if (!firstMove)
			{
				cutSceneImage.transform.localPosition += new Vector3(-60f, 0f, 0f);
				cutSceneImage.color = Color.Lerp( cutSceneImage.color, startColor, Time.unscaledDeltaTime * 10f );
				if (cutSceneImage.transform.localPosition.x < secondPoint.x)
					firstMove = true;
			}
			else if (!secondMove)
			{
				skillTime += Time.unscaledTime;
				if (skillTime >= cutTime)
					secondMove = true;
			}
			else
			{
				cutSceneImage.transform.localPosition += new Vector3(-4f, 0f, 0f);	
				cutSceneImage.color = Color.Lerp( cutSceneImage.color, endColor, Time.unscaledDeltaTime * 10f );
				if (cutSceneImage.transform.localPosition.x < thirdPoint.x)
					InitalizeData();
			}					
		}
			
	}
}
