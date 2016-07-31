using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
	//simple data field
	Vector3 cameraDistance;
	public AudioSource backgroundMusic;
	public GameObject npcPosition;
	
	//complex data field
	public CharacterFaye faye;
	public CharacterInformation info;
	public UserInterfaceManager mainUI;
	

	// initialize this script
	void Start()
	{
		Application.targetFrameRate = 80;
		backgroundMusic = Camera.main.GetComponent<AudioSource>();
		
		faye = GameObject.FindWithTag( "Player" ).GetComponent<CharacterFaye>();
		info = GameObject.FindWithTag( "Player" ).GetComponent<CharacterInformation>();
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
		mainUI.LinkNeutralData( info );
		mainUI.LinkElement();
		mainUI.SwitchUIMode( UserInterfaceManager.Mode.Neutral );
		cameraDistance = new Vector3(0f, 7.5f, -8f);
		PlayBackgroundMusic();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown( KeyCode.F12 ))
		{
			PlayerPrefs.DeleteAll();
			info.DefaultStatus();
		}
		if (Input.GetKeyDown( KeyCode.F11 ))
			info.LevelUp( mainUI );
		

		if (Input.GetButtonDown( "NPC" ) && npcPosition != null)
			mainUI.SwitchUIMode( UserInterfaceManager.Mode.NPC );
	
		//charaecter section
		if (!EventSystem.current.IsPointerOverGameObject()
		    && !mainUI.PresentSelectItem.enabled
		    && mainUI.CompareMode( UserInterfaceManager.Mode.Neutral ))
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
	
		//check cut Scene
		if (faye.OnSpecialActive)
		{
			mainUI.ActiveSkillCutScene();
			faye.OnSpecialActive = false;
		}
		
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
	//play background music
	void PlayBackgroundMusic()
	{
		string sceneName = Application.loadedLevelName;
		switch (sceneName)
		{
			case "CampField":
				backgroundMusic.clip = Resources.Load<AudioClip>( "Music/CampField" );
				break;
			case "Forest":
				backgroundMusic.clip = Resources.Load<AudioClip>( "Music/DarkForestField" );
				break;
			case "Cave":
				backgroundMusic.clip = Resources.Load<AudioClip>( "Music/DeepCaveField" );
				break;
			case "Nightmare":
				backgroundMusic.clip = Resources.Load<AudioClip>( "Music/NightmareField" );
				break;
		}
		backgroundMusic.Play();
	}

	public void ConnectNPC( NPC.Type type, GameObject _npcPosition )
	{	
		mainUI.PresentNPCType = type;
		npcPosition = _npcPosition;
	}

	public void DisConnectNPC()
	{
		mainUI.PresentNPCType = NPC.Type.Default;
		npcPosition = null;
	}
	
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
			Camera.main.transform.rotation = Quaternion.Lerp( Camera.main.transform.rotation, new Quaternion(0.4f, 0.0f, 0.0f, 0.9f), Time.deltaTime * 10 );
		}

		if (mainUI.CompareMode( UserInterfaceManager.Mode.NPC ))
		{
			//rotation -> use forward vector
			Camera.main.transform.forward = Vector3.Lerp( Camera.main.transform.forward, -npcPosition.transform.forward, Time.deltaTime * 10 );
			
			//position
			Camera.main.transform.position = Vector3.Lerp( Camera.main.transform.position, npcPosition.transform.position + (npcPosition.transform.forward) + new Vector3(0f, 1.0f, 0f), Time.deltaTime * 10 );
		}

		if (mainUI.CompareMode( UserInterfaceManager.Mode.Tranning ))
		{
		}			
	}

	public void ExpThrow( float exp )
	{
		faye.AddExperience( exp, mainUI );
		mainUI.AsynchronousSystemUI( ((int)exp).ToString() + "의 경험치를 획득하셨습니다." );
	}

	//button event
	//return camp field
	public void ReturnCampField()
	{
		info.SaveCharacterInformation();
		SceneManager.LoadScene( "CampField" );
	}
	
	public void GotoRaceField()
	{
		info.SaveCharacterInformation();
		SceneManager.LoadScene("PetRaceTrack");	
	}
}
