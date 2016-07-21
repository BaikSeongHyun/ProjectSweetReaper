using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RacePetStatus : MonoBehaviour
{
	Image fearFill;
	Image belligerenceFill;

	public void LinkElement()
	{
		fearFill = transform.Find( "FearGaugeBack" ).GetComponent<Image>();
		belligerenceFill = transform.Find( "BelligerenceGaugeFill" ).GetComponent<Image>();
	}

	public void UpdatePetStatus()
	{

	}
}
