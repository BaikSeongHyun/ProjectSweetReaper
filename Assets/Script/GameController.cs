using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
	//simple data field
	public bool modeNPC;
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
		modeNPC = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		//charaecter section
		if (!EventSystem.current.IsPointerOverGameObject() && !mainUI.PresentSelectItem.enabled)
		{
			if (Input.GetButtonDown( "NormalAttack" ))
				faye.Attack();
			else if (Input.GetButtonDown( "Skill1" ))
				faye.SkillCommand( "Q" );
			else if (Input.GetButtonDown( "Skill2" ))
				faye.SkillCommand( "Skill2" );
			else if (Input.GetButtonDown( "Skill3" ))
				faye.SkillCommand( "Skill3" );
			else if (Input.GetButtonDown( "Skill4" ))
				faye.SkillCommand( "Skill4" );
			else if (Input.GetButtonDown( "Skill5" ))
				faye.SkillCommand( "A" );
			else if (Input.GetButtonDown( "Skill6" ))
				faye.SkillCommand( "S" );
			else if (Input.GetButtonDown( "Skill7" ))
				faye.SkillCommand( "D" );
			else if (Input.GetButtonDown( "Skill8" ))
				faye.SkillCommand( "Skill8" );
			else if (Input.GetButton( "Move" ))
				MakeMovePoint();
			//skill number - key
			//1q 2w 3e 4r
			//5a 6s 7d 8f
		}
		
		//ui section
		if (Input.GetButtonDown( "SkillUI" ) && mainUI.CompareMode( UserInterfaceManager.Mode.Neutral ))
			mainUI.ControlSkillUI( !mainUI.OnSkillUI );
		if (Input.GetButtonDown( "Status" ) && mainUI.CompareMode( UserInterfaceManager.Mode.Neutral ))
			mainUI.ControlStatusUI( !mainUI.OnStatusUI );
		if (Input.GetButtonDown( "Inventory" ) && mainUI.CompareMode( UserInterfaceManager.Mode.Neutral ))
			mainUI.ControlInventory( !mainUI.OnInventory );
		if (Input.GetButtonDown( "CloseAllUI" ) && mainUI.CompareMode( UserInterfaceManager.Mode.Neutral ))
			mainUI.ClearUI();

		//item / skill drag object check
		if (mainUI.PresentSelectItem.enabled && !Input.GetMouseButton( 0 ) && !Input.GetMouseButton( 1 ))
		{
			Debug.Log( "Active close present element" );
			mainUI.ClosePresentElement();
		}		
		SetUIState();
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
		
		//death popup
		if (!faye.IsAlive)
			mainUI.ControlDeathPopUp( true );		

		//test camera
		if (Input.GetKeyDown( KeyCode.F1 ))
			modeNPC = !modeNPC;
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

	void SetUIState()
	{

	}

	public void CameraControl()
	{
		if (!modeNPC)
		{
			//position
			Camera.main.transform.position = Vector3.Lerp( Camera.main.transform.position, faye.transform.position + cameraDistance, Time.deltaTime * 10 );
			//rotation
			Camera.main.transform.rotation = Quaternion.Lerp( Camera.main.transform.rotation, new Quaternion ( 0.4f, 0.0f, 0.0f, 0.9f ), Time.deltaTime * 10 );
		}

		if (modeNPC)
		{
			//rotation -> use forward vector
			Camera.main.transform.forward = Vector3.Lerp( Camera.main.transform.forward, -temp.transform.forward, Time.deltaTime * 10 );
			//position
			Camera.main.transform.position = Vector3.Lerp( Camera.main.transform.position, temp.transform.position + ( temp.transform.forward * 3 ) + new Vector3 ( 0f, 0.5f, 0f ), Time.deltaTime * 10 );
		}
			
	}

	//button event
	//return camp field
	public void ReturnCampField()
	{
		SceneManager.LoadScene( "CampField" );
	}
}
