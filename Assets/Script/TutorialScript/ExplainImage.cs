using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ExplainImage : MonoBehaviour, IPointerDownHandler {
	public GameObject ExplainText1;
	public GameObject ExplainText2;
	public GameObject ExplainText3;
	public GameObject ExplainText4;
	public GameObject ExplainText5;
	public GameObject ExplainText6;
	public GameObject ExplainText7;
	
	int imageCounter;
	Image showImage;

	// Use this for initialization
	void Start () {
		showImage = GetComponent<Image> ();
		imageCounter = 1;	

//		LinkElement ();
//		CloseElement ();
	}


	void Update()
	{
		
	}

//	public void LinkElement()
//	{
//		ExplainText1 = GameObject.Find ("ExplainText1");
//		ExplainText2 = GameObject.Find ("ExplainText2");
//		ExplainText3 = GameObject.Find ("ExplainText3");
//		ExplainText4 = GameObject.Find ("ExplainText4");
//		ExplainText5 = GameObject.Find ("ExplainText5");
//		ExplainText6 = GameObject.Find ("ExplainText6");
//		ExplainText7 = GameObject.Find ("ExplainText7");
//	}
//	public void CloseElement()
//	{
//		ExplainText1.SetActive (false);
//		ExplainText2.SetActive (false);
//		ExplainText3.SetActive (false);
//		ExplainText4.SetActive (false);
//		ExplainText5.SetActive (false);
//		ExplainText6.SetActive (false);
//		ExplainText7.SetActive (false);
//
//	}

	public void	EventClearNext(){
		imageCounter++;
		showImage.sprite = Resources.Load<Sprite> ("ExplainImage/EplainImage" + (imageCounter).ToString ());
	}



	public void OnPointerDown(PointerEventData eventData)
	{
		if (imageCounter < 7) {
			if (eventData.button == PointerEventData.InputButton.Left) {
				{
					EventClearNext ();
				}
			}
		}

		if (imageCounter == 8) {
			if (eventData.button == PointerEventData.InputButton.Left) {
				{
					EventClearNext ();
				}
			}

		}
	}

	public void InventoryOpen(){
		
		if (imageCounter == 9) {
		}
	}	





	public void ControlExplainImage(bool state)
	{
		showImage.enabled = state;
	}



}
