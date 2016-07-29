using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class TutorialUI : MonoBehaviour {
	
	public ExplainImage explainImage;
	public CharacterInformation info;
	public UserInterfaceManager UIM;
	public int getimageCounter;
	bool tutorialstay;


	void Start()
	{
		info = GameObject.FindWithTag ("Player").GetComponent<CharacterInformation> ();
		explainImage = transform.Find ("ExplainImage").GetComponent<ExplainImage>();
		UIM = GameObject.FindWithTag ("MainUI").GetComponent<UserInterfaceManager> ();
		tutorialstay = true;
	}

	void Update()
	{
		if(tutorialstay){
			GetToExplainImage ();

			if (Input.GetMouseButtonDown (1)) {
				{
					if (getimageCounter == 5) 
					{
						if (!EventSystem.current.IsPointerOverGameObject ()) {
							explainImage.SendMessage ("EventClearNext");}
					}
				}
			}

			if (Input.GetKey (KeyCode.I)) {
				{
					if (UIM.OnInventory) {
						if (getimageCounter == 9) {
							explainImage.SendMessage ("EventClearNext");
						}
					}
				}
			}

			if (Input.GetKey (KeyCode.A)) {
				if (getimageCounter == 7) {
					explainImage.SendMessage ("EventClearNext");
				}
			}
			if(explainImage.imageCounter == 20){
				tutorialstay= false;
			}

		}

	}

	void GetToExplainImage ()
	{
		getimageCounter = explainImage.imageCounter;
	}













}
