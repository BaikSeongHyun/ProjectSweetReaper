using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RacePetStatus : MonoBehaviour
{
	public Image raceGrade;
	public Text attack;
	public Text moveSpeed;
	public Text petOrderCounter;

	public void LinkElement()
	{
		raceGrade = transform.Find( "PresentGrade" ).GetComponent<Image>();
		attack = transform.Find( "AttackBack" ).Find( "Text" ).GetComponent<Text>();
		moveSpeed = transform.Find( "MoveSpeedBack" ).Find( "Text" ).GetComponent<Text>();
		petOrderCounter = transform.Find( "PetOrder" ).GetComponent<Text>();
	}

	public void UpdatePetStatus( Pet myPet )
	{
		string path = "Race/MyPetGrade" + myPet.Grade.ToString();
		raceGrade.sprite = Resources.Load<Sprite>( path );
		attack.text = myPet.petInfo.petStunTime.ToString() + " m/s";
		moveSpeed.text = myPet.petInfo.MoveSpeed.ToString() + " sec";
		petOrderCounter.text = myPet.OrderCounter.ToString();
	}
}
