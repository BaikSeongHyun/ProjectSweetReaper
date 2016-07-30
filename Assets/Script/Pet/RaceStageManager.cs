using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaceStageManager : MonoBehaviour
{
	public const int petNumber = 8;
	public int select;
	public GameObject petType;
	public CharacterInformation charInfo;
	public Transform[] startPoint;
	public Transform[] endPoint;
	public List<Pet> petList;
	public Pet[] anotherPets;
	public Pet myPet;
	public UserInterfaceManager mainUI;

	// Use this for initialization
	void Start()
	{
		charInfo = GameObject.FindWithTag( "Player" ).GetComponent<CharacterInformation>();
		CreatePets();
		SetPetInformation();
		SortPetGrade();
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
		mainUI.LinkElement();
		mainUI.SwitchUIMode( UserInterfaceManager.Mode.Race );
		mainUI.LinkRaceData( anotherPets, myPet );
	}
	
	// Update is called once per frame
	void Update()
	{
		SortPetGrade();
		SetPetAttackTarget();
		mainUI.UpdateMainUI();		
	}

	void LateUpdate()
	{
		CameraUpdate();	
	}

	public void CreatePets()
	{
		for (int i = 0; i < petNumber; i++)
		{
			GameObject temp = (GameObject)Instantiate( petType, startPoint[i].position, new Quaternion(0f, 0f, 0f, 0f) );
			petList.Add( temp.GetComponent<Pet>() );
			petList[i].SetStartAndGoal( startPoint[i], endPoint[i] );
			petList[i].SetLane( i + 1 );
		}
	}

	public void SetPetInformation()
	{
		select = Random.Range( 2, 6 );
		petList[select].PlayerPet = true;

		//set player pet status
		petList[select].SetStatus( charInfo.PetMoveSpeed, charInfo.PetStunTime );

		myPet = petList[select];
		anotherPets = new Pet[7];

		int tempCounter = 0;

		for (int i = 0; i < petList.Count; i++)
		{
			if (!petList[i].PlayerPet)
			{	
				anotherPets[tempCounter] = petList[i];
				tempCounter++;
			}
		}
	}

	// sort grade
	void SortPetGrade()
	{
		petList.Sort( delegate(Pet x, Pet y )
		{
			return x.transform.position.z.CompareTo( y.transform.position.z );
		} );
		petList.Reverse();
		
		for (int i = 0; i < petList.Count; i++)
			petList[i].Grade = (i + 1);		
	}

	void SetPetAttackTarget()
	{		
		foreach (Pet elements in petList)
		{
			elements.SetPetAttackTarget( petList[Random.Range( 0, 3 )] );
		}
	}

	public void OrderMyPet( string data )
	{		
		if (data == "Run")
			myPet.UserOrder( "Run" );
		else if (data == "Attack")
			myPet.UserOrder( "Attack" );
	}

	void CameraUpdate()
	{
		Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, myPet.transform.position.z - 30f);
	}
		
}
