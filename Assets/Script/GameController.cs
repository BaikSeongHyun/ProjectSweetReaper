using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GameController : MonoBehaviour
{
	//complex data field
	public CharacterFaye faye;
	public UserInterfaceManager mainUI;

	// initialize this script
	void Start()
	{
		faye = GameObject.FindWithTag( "Player" ).GetComponent<CharacterFaye>();
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
	}
	
	// Update is called once per frame
	void Update()
	{
		//charaecter section
		if (Input.GetButtonDown( "NormalAttack" ))
			faye.Attack();
		else if(Input.GetButtonDown("Skill1"))
			faye.SkillCommand("Q");
		else if(Input.GetButtonDown("Skill2"))
			faye.SkillCommand("Skill2");
		else if(Input.GetButtonDown("Skill3"))
			faye.SkillCommand("Skill3");
		else if(Input.GetButtonDown("Skill4"))
			faye.SkillCommand("Skill4");
		else if(Input.GetButtonDown("Skill5"))
			faye.SkillCommand("A");
		else if(Input.GetButtonDown("Skill6"))
			faye.SkillCommand("S");
		else if(Input.GetButtonDown("Skill7"))
			faye.SkillCommand("D");
		else if(Input.GetButtonDown("Skill8"))
			faye.SkillCommand("Skill8");			
		else if (Input.GetButtonDown( "Move" ))
			MakeMovePoint();
		//skill number - key
		//1q 2w 3e 4r
		//5a 6s 7d 8f
			
		
		//ui section
		//always update
		mainUI.UpdateQuickStatus();

		if (Input.GetKeyDown( KeyCode.C ))
			mainUI.ControlStatusUI( !mainUI.OnStatusUI );

		if (Input.GetKeyDown( KeyCode.I ))
			mainUI.ControlInventory( !mainUI.OnInventory );

		if (Input.GetKeyDown( KeyCode.Escape ))
			mainUI.ClearUI();
		
		//move camera transform
		
	}

	//another method

	//set destination for player character
	void MakeMovePoint()
	{
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			mainUI.ClearUI();
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hitInfo;

			if (Physics.Raycast( ray, out hitInfo, Mathf.Infinity, 1 << LayerMask.NameToLayer( "Terrain" ) ))
			{
				faye._destinaton = hitInfo.point;
			}
		}
	}
}
