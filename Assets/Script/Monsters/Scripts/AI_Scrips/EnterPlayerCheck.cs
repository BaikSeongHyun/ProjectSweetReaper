using UnityEngine;
using System.Collections;

public class EnterPlayerCheck : MonoBehaviour
{

	//field
	private bool isEntered = false;

	//property
	public bool Entered {
		get {
			return isEntered;
		}
	}

	//check entered object
	public void OnTriggerStay (Collider col)
	{
		if (col.gameObject.CompareTag ("Player"))
			isEntered = true;
	
	}

	//exit object
	public void OnTriggerExit (Collider col)
	{
		if (col.gameObject.CompareTag ("Player"))
			isEntered = false;
		
	}
}
