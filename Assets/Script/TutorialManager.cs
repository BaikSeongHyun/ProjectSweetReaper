using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour {
//	GameController controller;
	// Use this for initialization
	public GameObject ExplainText1;
	public GameObject ExplainText2;
	public GameObject ExplainText3;
	public GameObject ExplainText4;
	public GameObject ExplainText5;
	public GameObject ExplainText6;
	public GameObject ExplainText7;



	void Start () {
		LinkElement ();
		CloseElement ();
		StartTutorial ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StartTutorial()
	{
		float startTime = Time.realtimeSinceStartup;
		if (startTime >= 1f) {
			ExplainText1.SetActive (true);
		}
	}


	public void LinkElement()
	{
		ExplainText1 = GameObject.Find ("ExplainText1");
		ExplainText2 = GameObject.Find ("ExplainText2");
		ExplainText3 = GameObject.Find ("ExplainText3");
		ExplainText4 = GameObject.Find ("ExplainText4");
		ExplainText5 = GameObject.Find ("ExplainText5");
		ExplainText6 = GameObject.Find ("ExplainText6");
		ExplainText7 = GameObject.Find ("ExplainText7");
	}
	public void CloseElement()
	{
		ExplainText1.SetActive (false);
		ExplainText2.SetActive (false);
		ExplainText3.SetActive (false);
		ExplainText4.SetActive (false);
		ExplainText5.SetActive (false);
		ExplainText6.SetActive (false);
		ExplainText7.SetActive (false);
	}


}
