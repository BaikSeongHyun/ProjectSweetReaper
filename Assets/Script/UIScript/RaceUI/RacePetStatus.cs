using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RacePetStatus : MonoBehaviour
{
	public Image fearFill;
	public Image belligerenceFill;
	public Text attack;
	public Text moveSpeed;

	public void LinkElement()
	{
		fearFill = transform.Find( "FearGaugeBack" ).GetComponent<Image>();
		belligerenceFill = transform.Find( "BelligerenceGaugeFill" ).GetComponent<Image>();
		attack = transform.Find( "AttackBack" ).Find( "Text" ).GetComponent<Text>();
		moveSpeed = transform.Find( "MoveSpeedBack" ).Find( "Text" ).GetComponent<Text>();
	}

	public void UpdatePetStatus(Pet myPet)
	{
		attack.text = myPet.petInfo.petStunTime.ToString() + " sec";
		moveSpeed.text = myPet.petInfo.MoveSpeed.ToString() + " m/s";
	}
}
