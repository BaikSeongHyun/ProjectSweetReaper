using UnityEngine;
using System.Collections;

public class GoalProcess : MonoBehaviour
{
	public RaceStageManager mainControl;
	public Pet tempPet;

	public void OnTriggerEnter( Collider col )
	{		
		tempPet = col.gameObject.GetComponent<Pet>();
		Debug.Log( tempPet );
		if (tempPet == null)
			return;
		
		if (tempPet.PlayerPet)
			mainControl.GoalProcess();	
		
	}
}
