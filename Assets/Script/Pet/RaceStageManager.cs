using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaceStageManager : MonoBehaviour
{

	public int goalCount = 0;
	public GameObject petType;
	public List<Pet> petList;
	public Pet myPet;
	public UserInterfaceManager mainUI;

	// Use this for initialization
	void Start()
	{
		FindEveryPet();
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
		mainUI.LinkElement();
		mainUI.SwitchUIMode( UserInterfaceManager.Mode.Race );
		mainUI.LinkRaceData( petList.ToArray(), myPet );
	}
	
	// Update is called once per frame
	void Update()
	{
		mainUI.UpdateMainUI();
		SortPetGrade();
		SetPetAttackTarget();
	}

	public void FindEveryPet()
	{
		petList = new List<Pet> ();
		GameObject[] temp = GameObject.FindGameObjectsWithTag( "Pet" );

		for (int i = 0; i < temp.Length; i++)
		{
			if (temp[i].GetComponent<Pet>() != null)
				petList.Add( temp[i].GetComponent<Pet>() );				
		}
		for (int i = 0; i < petList.Count; i++)
			if (petList[i].PlayerPet)
				myPet = petList[i];
	}

	public void SetPlayerPet()
	{
		int select = Random.Range( 0, 8 );
		petList[select].PlayerPet = true;

		//set player pet status
	}

	// sort
	void SortPetGrade()
	{
		petList.Sort( delegate(Pet x, Pet y ) {
			return x.transform.position.z.CompareTo( y.transform.position.z );
		} );
		petList.Reverse();
	}

	void SetPetAttackTarget()
	{
		goalCount = 0;
		foreach (Pet elements in petList)
		{
			elements.SetPetAttackTarget( petList[Random.Range( 0, 3 )] );	
			if (!elements.onRace)
				goalCount++;
		}
	}

	public void OrderMyPet( string data )
	{		
		if (data == "Run")
			myPet.UserOrder( "Run" );
		else if (data == "Attack")
			myPet.UserOrder( "Attack" );
	}
}
