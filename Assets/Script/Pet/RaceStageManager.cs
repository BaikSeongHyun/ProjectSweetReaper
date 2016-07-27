using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaceStageManager : MonoBehaviour
{

	const int petCount = 6;
	public GameObject petType;
	public List<Pet> petList;
	public Pet myPet;
	public UserInterfaceManager mainUI;

	// Use this for initialization
	void Start()
	{
		EveryPet();
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
		mainUI.LinkElement();
		mainUI.SwitchUIMode( UserInterfaceManager.Mode.Race );
		mainUI.LinkRaceData( petList.ToArray(), myPet );
	}
	
	// Update is called once per frame
	void Update()
	{
		mainUI.UpdateMainUI();			
	}

	public void EveryPet()
	{
		petList = new List<Pet>();
		GameObject[] temp = GameObject.FindGameObjectsWithTag( "Pet" );

		for (int i = 0; i < temp.Length; i++)
			petList.Add( temp[i].GetComponent<Pet>() );
		

		for (int i = 0; i < temp.Length; i++)
		{
			if (petList[i].playerPet)
			{
				myPet = petList[i];
				petList.RemoveAt( i );
			}
		}
	
	}

	public void OrderMyPet( string data )
	{		
		if (data == "Run")
			myPet.UserOrder( "Run" );
	}
}
