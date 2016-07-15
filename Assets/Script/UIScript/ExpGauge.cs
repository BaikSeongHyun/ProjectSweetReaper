using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExpGauge : MonoBehaviour
{
	public Image presentExp;

	void Start()
	{
		LinkElement();
	}

	public void LinkElement()
	{
		presentExp = transform.Find( "ExpFill" ).GetComponent<Image>();
	}

	public void UpdateExpGauge(CharacterInformation info)
	{
		presentExp.fillAmount = info.ExpFill;
	}



}

