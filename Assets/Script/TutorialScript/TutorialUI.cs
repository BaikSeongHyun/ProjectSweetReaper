using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class TutorialUI : MonoBehaviour {

	//explainimage getting;
	public ExplainImage explainImage;
	public int getimageCounter;

	//characterinfo getting;
	public CharacterInformation info;
	//UIM getting;
	public UserInterfaceManager UIM;
	bool tutorialstay;

	//cube3 all data (monsterarray,
	public GameObject cube3;
	public GameObject[] tutorialFrog;
	public GameObject MonsterArrayList;
	CharacterFaye Faye;


	void Start()
	{
		Faye = GameObject.FindWithTag ("Player").GetComponent<CharacterFaye> ();
		info = GameObject.FindWithTag ("Player").GetComponent<CharacterInformation> ();
		explainImage = transform.Find ("ExplainImage").GetComponent<ExplainImage>();
		UIM = GameObject.FindWithTag ("MainUI").GetComponent<UserInterfaceManager> ();

		tutorialstay = true;

		//cube3 monsterarraylist into map cube3
		MonsterArrayList.SetActive (false);
	}

	void Update()
	{
		if(tutorialstay){
			//gettoexplainImage get imagecount;
			GetToExplainImage ();

			if (getimageCounter == 5) {
				if (Input.GetMouseButtonDown (1)) 
					{
						if (!EventSystem.current.IsPointerOverGameObject ()) {
							explainImage.SendMessage ("EventClearNext");}
					}
			}

			if (getimageCounter == 9) {
				{
					if (Input.GetKey (KeyCode.I)) {
						if (UIM.OnInventory) {
							explainImage.SendMessage ("EventClearNext");
						}
					}
				}
			}

			if (getimageCounter == 7) {
				if (!EventSystem.current.IsPointerOverGameObject ()) {
					info.InstallSkill[0] = new Skill(DataBase.Instance.FindSkillById(1));
					info.InstallSkill[1] = new Skill(DataBase.Instance.FindSkillById(2));
					info.InstallSkill[2] = new Skill(DataBase.Instance.FindSkillById(3));

					if (Input.GetButtonDown ("Skill1")) {
						explainImage.SendMessage ("EventClearNext");
					}
				}
			}

			if(explainImage.imageCounter == 12)	
			{
				MonsterArrayList.SetActive (true);
				if (MonsterAliveCheck ()) {
					explainImage.SendMessage ("EventClearNext");
					Destroy (MonsterArrayList);
					Destroy (cube3);
				}

			}

			if (explainImage.imageCounter == 15) {
				Faye.skillingChainCount = 1;
				info.ComboCounter = 1;
				if (Input.GetMouseButtonDown (0)) {
					Faye.skillingChainCount = 0;
					info.ComboCounter = 0;
					explainImage.SendMessage ("EventClearNext");
				}

			}

			if (explainImage.imageCounter == 16) {
				if(info.ComboCounter==4){explainImage.SendMessage ("EventClearNext");
				}
			}

			if (explainImage.imageCounter == 17) {
				//if(Faye.Finish){explainImage.SendMessage ("EventClearNext");}
				//파야 각성기 사용시 넘어가게 하기
			}

			if (explainImage.imageCounter == 20) {
				tutorialstay = false;
			}
		}

	}

	void GetToExplainImage ()
	{
		getimageCounter = explainImage.imageCounter;
	}

	//cube3 monsteralivecheck
	public bool MonsterAliveCheck()
	{
		for (int i = 0; i < tutorialFrog.Length; i++)
		{
			if (tutorialFrog[i] != null)
				return true;
		}
		return false;
	}

	public void TutorialSkillGet()
	{
		UIM.InstallQuickSkill ();
		//quick
		//DataBase.Instance ();
	}













}
