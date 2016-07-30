using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
	//simple data field
	Vector3 cameraDistance;

	//complex data field
	public CharacterFaye faye;
	public CharacterInformation info;
	public UserInterfaceManager mainUI;

	//tutorialui upload
	public DataBase dataBase;
	public TutorialUI tutorialUI;

	// initialize this script
	void Start()
	{
		Application.targetFrameRate = 80;
		faye = GameObject.FindWithTag( "Player" ).GetComponent<CharacterFaye>();
		info = GameObject.FindWithTag( "Player" ).GetComponent<CharacterInformation>();
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
		mainUI.LinkNeutralData( info );
		mainUI.LinkElement();
		mainUI.SwitchUIMode( UserInterfaceManager.Mode.Neutral );
		cameraDistance = new Vector3 ( 0f, 7.5f, -8f );

		tutorialUI = GameObject.Find ("TutorialUI").GetComponent<TutorialUI> ();

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown( KeyCode.F12 ))
		{
			PlayerPrefs.DeleteAll();
			info.DefaultStatus();
		}

		//charaecter section
		if (!EventSystem.current.IsPointerOverGameObject() && !mainUI.PresentSelectItem.enabled)
		{
			if (Input.GetButtonDown( "NormalAttack" ))
				faye.Attack();
			else if (Input.GetButtonDown( "Skill1" ))
				faye.SkillCommand( 0 );
			else if (Input.GetButtonDown( "Skill2" ))
				faye.SkillCommand( 1 );
			else if (Input.GetButtonDown( "Skill3" ))
				faye.SkillCommand( 2 );
			else if (Input.GetButtonDown( "Skill4" ))
				faye.SkillCommand( 3 );
			else if (Input.GetButtonDown( "Skill5" ))
				faye.SkillCommand( 4 );
			else if (Input.GetButtonDown( "Skill6" ))
				faye.SkillCommand( 5 );
			else if (Input.GetButtonDown( "Skill7" ))
				faye.SkillCommand( 6 );
			else if (Input.GetButtonDown( "Skill8" ))
				faye.SkillCommand( 7 );
			else if (Input.GetButton( "Move" ))
				MakeMovePoint();
			//skill number - key
			//1q 2w 3e 4r
			//5a 6s 7d 8f
		}

		//check mouse click
		if (Input.GetMouseButton( 0 ) || Input.GetMouseButton( 1 ))
			mainUI.OnClickMouse = true;
		else
			mainUI.OnClickMouse = false;

		//ui section
		if (Input.GetButtonDown( "SkillUI" ) && mainUI.CompareMode( UserInterfaceManager.Mode.Neutral ))
			mainUI.ControlSkillUI( !mainUI.OnSkillUI );
		if (Input.GetButtonDown( "Inventory" ) && mainUI.CompareMode( UserInterfaceManager.Mode.Neutral ))
			mainUI.ControlInventory( !mainUI.OnInventory );
		if (Input.GetButtonDown( "CloseAllUI" ) && mainUI.CompareMode( UserInterfaceManager.Mode.Neutral ))
			mainUI.ClearUI();

		//item / skill drag object check
		if (mainUI.PresentSelectItem.enabled && !mainUI.OnClickMouse)
			mainUI.ClosePresentElement();				

		mainUI.UpdateMainUI();

		//raycast mode
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit hitInfo;

		//accquire item
		if (Physics.Raycast( ray, out hitInfo, Mathf.Infinity, 1 << LayerMask.NameToLayer( "Item" ) ))
		{
			if (faye.AcquireItem( hitInfo.collider.gameObject.GetComponent<DropItem>(), mainUI ))
				Destroy( hitInfo.collider.gameObject );
		}

		if (Input.GetKeyDown( KeyCode.F8 ))
			mainUI.SwitchUIMode( UserInterfaceManager.Mode.Race );
		else if (Input.GetKeyDown( KeyCode.F7 ))
			mainUI.SwitchUIMode( UserInterfaceManager.Mode.Neutral );



		//death popup
		if (!faye.IsAlive)
			mainUI.ControlDeathPopUp( true );		
	}

	public void LateUpdate()
	{
		//update camera sight
		CameraControl();
	}

	//another method

	//set destination for player character
	void MakeMovePoint()
	{		
		mainUI.ClearUI();
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit hitInfo;

		if (Physics.Raycast( ray, out hitInfo, Mathf.Infinity, 1 << LayerMask.NameToLayer( "Terrain" ) ))
		{
			faye.Destinaton = hitInfo.point;
		}
	}

	//set camera
	public void CameraControl()
	{
		if (mainUI.CompareMode( UserInterfaceManager.Mode.Neutral ))
		{
			//position
			Camera.main.transform.position = Vector3.Lerp( Camera.main.transform.position, faye.transform.position + cameraDistance, Time.deltaTime * 10 );
			//rotation
			Camera.main.transform.rotation = Quaternion.Lerp( Camera.main.transform.rotation, new Quaternion ( 0.4f, 0.0f, 0.0f, 0.9f ), Time.deltaTime * 10 );
		}

		if (mainUI.CompareMode( UserInterfaceManager.Mode.NPC ))
		{
			//			//rotation -> use forward vector
			//			Camera.main.transform.forward = Vector3.Lerp( Camera.main.transform.forward, -temp.transform.forward, Time.deltaTime * 10 );
			//			//position
			//			Camera.main.transform.position = Vector3.Lerp( Camera.main.transform.position, temp.transform.position + ( temp.transform.forward * 3 ) + new Vector3 ( 0f, 0.5f, 0f ), Time.deltaTime * 10 );
		}

		if (mainUI.CompareMode( UserInterfaceManager.Mode.Tranning ))
		{
		}			
	}

	public void ExpThrow( float exp )
	{
		faye.AddExperience( exp );
		mainUI.AsynchronousSystemUI( ( (int) exp ).ToString() + "의 경험치를 획득하셨습니다." );
	}

	//button event
	//return camp field
	public void ReturnCampField()
	{
		info.SaveCharacterInformation();
		SceneManager.LoadScene( "CampField" );
	}
}
