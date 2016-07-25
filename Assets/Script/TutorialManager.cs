using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutorialManager : MonoBehaviour {
//	GameController controller; 대신쓴다

	public Vector3 cameraDistance;
	public GameObject temp;

	//complex data field
	public CharacterFaye faye;
	public CharacterInformation info;
	public UserInterfaceManager mainUI;
	public DataBase dataBase;





	// initialize this script
	void Start()
	{
		Application.targetFrameRate = 80;
		faye = GameObject.FindWithTag( "Player" ).GetComponent<CharacterFaye>();
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
		cameraDistance = new Vector3 ( 0f, 7.5f, -8f );
	}


	
	// Update is called once per frame
	void Update () {
		
	}





//	delegate void StartTutorial();
//
//	event StartTutorial advancement;
//




	//public void ()


}
