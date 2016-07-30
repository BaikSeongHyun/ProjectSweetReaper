using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RaceAnotherPetElement : MonoBehaviour
{
	public Image raceGrade;
	public Scrollbar miniMap;

	public void LinkElement()
	{
		raceGrade = transform.Find( "RaceGrade" ).GetComponent<Image>();
		miniMap = transform.Find( "PetMiniMap" ).GetComponent<Scrollbar>();		                        
	}

	public void UpdateAnotherPet(Pet status)
	{
		string path = "Race/AnotherPetGrade" + status.Grade.ToString();
		raceGrade.sprite = Resources.Load<Sprite>( path );
		miniMap.value = status.PresentPosition;
	}
}