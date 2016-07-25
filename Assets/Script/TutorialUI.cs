using UnityEngine;
using System.Collections;

public class TutorialUI : MonoBehaviour {
	//tutorial text
	public GameObject ExplainText1;
	public GameObject ExplainText2;
	public GameObject ExplainText3;
	public GameObject ExplainText4;
	public GameObject ExplainText5;
	public GameObject ExplainText6;
	public GameObject ExplainText7;

	public int ExplainState;
	// Use this for initialization
	void Start () {
		LinkElement ();
		CloseElement ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void StartTutorial()
	{

		Debug.Log (ExplainState);
		if(ExplainState == 0) {
			ExplainText1.SetActive (true);
			ExplainState = 1;
		}

		if (ExplainState == 1) {
			if (Input.GetMouseButton(0)) {//이부분을 move가 될때로 처리해야함.
				ExplainText2.SetActive (true);
				ExplainText1.SetActive (false);
				ExplainState = 2;
			}
		}

		if (ExplainState == 2) {
			if (Input.GetMouseButton (1)) {
				ExplainText3.SetActive (true);
				ExplainText2.SetActive (false);
				ExplainState = 3;
			}
		}

		if (ExplainState == 3) {
			if (Input.GetKey (KeyCode.A)) {
				ExplainText4.SetActive (true);
				ExplainText3.SetActive (false);
				ExplainState = 4;
			}
		}

		if (ExplainState == 4) {
			//if (Up) {
			ExplainText5.SetActive (true);
			ExplainText4.SetActive (false);
			ExplainState = 5;
			//}	
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
