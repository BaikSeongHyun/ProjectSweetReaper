using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RaceResult : MonoBehaviour
{	
	public Image resultGrade;

	public void LinkElement()
	{
		resultGrade = transform.Find( "GradeImage" ).GetComponent<Image>();
	}

	public void UpdateResult( Pet myPet )
	{
		string path = "Race/MyPetGrade" + myPet.Grade.ToString();
		resultGrade.sprite = Resources.Load<Sprite>( path );
	}
}
