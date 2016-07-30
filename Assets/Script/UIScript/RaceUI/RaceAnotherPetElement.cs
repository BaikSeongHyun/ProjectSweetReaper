using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RaceAnotherPetElement : MonoBehaviour
{
	Image raceGrade;
	Scrollbar miniMap;

	public void LinkElement()
	{
		raceGrade = transform.Find( "PetMiniMap" ).GetComponent<Image>();
		miniMap = transform.Find( "RaceGrade" ).GetComponent<Scrollbar>();		                        
	}

	public void UpdateAnotherPet(Pet status)
	{
		string path = "Race/AnotherPetGrade" + status.Grade.ToString();
		raceGrade.sprite = Resources.Load<Sprite>( path );
		miniMap.value = status.PresentPosition;
	}
}