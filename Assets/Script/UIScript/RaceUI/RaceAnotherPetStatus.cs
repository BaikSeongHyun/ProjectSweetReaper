using UnityEngine;
using System.Collections;

public class RaceAnotherPetStatus : MonoBehaviour
{
	public RaceAnotherPetElement[] elements;

	public void LinkElement()
	{
		elements = new RaceAnotherPetElement[7];

		for(int i = 0; i < elements.Length; i++)
		{
			string temp = "RaceElement" + ( i + 1 ).ToString();
			elements[i] = transform.Find( temp ).GetComponent<RaceAnotherPetElement>();
			elements[i].LinkElement();
		}
	}

	public void UpdateRaceAnotherPetStatus(Pet[] anotherPet )
	{
		for (int i = 0; i < elements.Length; i++)
		{
			elements[i].UpdateAnotherPet( anotherPet[i] );
		}
	}
}
