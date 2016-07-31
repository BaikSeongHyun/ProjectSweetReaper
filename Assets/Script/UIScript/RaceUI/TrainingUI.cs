using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrainingUI : MonoBehaviour
{
	public Text speed;
	public Text attack;

	public void LinkElement()
	{
		speed = transform.Find( "SpeedText" ).GetComponent<Text>();
		attack = transform.Find( "AttackText" ).GetComponent<Text>();
	}

	public void UpdateTrainingUI( CharacterInformation info )
	{
		speed.text = info.PetMoveSpeed.ToString() + " m/s";
		attack.text = info.PetStunTime.ToString() + " s";
	}
}
