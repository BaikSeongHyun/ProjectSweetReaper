using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ExplainImage : MonoBehaviour, IPointerDownHandler {
	public GameObject ExplainImage1;
	public GameObject ExplainImage2;
	public GameObject ExplainImage3;
	public GameObject ExplainImage4;
	public GameObject ExplainImage5;
	public GameObject ExplainImage6;
	public GameObject ExplainImage7;
	public GameObject ExplainImage8;
	public GameObject ExplainImage9;
	public GameObject ExplainImage10;
	public GameObject ExplainImage11;
	public GameObject ExplainImage12;
	public GameObject ExplainImage13;
	public GameObject ExplainImage14;
	public GameObject ExplainImage15;
	public GameObject ExplainImage16;
	public GameObject ExplainImage17;
	public GameObject ExplainImage18;
	public GameObject ExplainImage19;

	int imageCounter;
	Image showImage;

	// Use this for initialization
	void Start () {
		showImage = gameObject.GetComponent<Image> ();
		imageCounter = 1;	
		StartImage();
		LinkElement ();
		CloseElement ();
	}


	void Update()
	{
		
	}

	public void LinkElement()
	{
		ExplainImage1 = GameObject.Find ("ExplainImage1");
		ExplainImage2 = GameObject.Find ("ExplainImage2");
		ExplainImage3 = GameObject.Find ("ExplainImage3");
		ExplainImage4 = GameObject.Find ("ExplainImage4");
		ExplainImage5 = GameObject.Find ("ExplainImage5");
		ExplainImage6 = GameObject.Find ("ExplainImage6");
		ExplainImage7 = GameObject.Find ("ExplainImage7");
		ExplainImage8 = GameObject.Find ("ExplainImage8");
		ExplainImage9 = GameObject.Find ("ExplainImage9");
		ExplainImage10 = GameObject.Find ("ExplainImage10");
		ExplainImage11 = GameObject.Find ("ExplainImage11");
		ExplainImage12 = GameObject.Find ("ExplainImage12");
		ExplainImage13 = GameObject.Find ("ExplainImage13");
		ExplainImage14 = GameObject.Find ("ExplainImage14");
		ExplainImage15 = GameObject.Find ("ExplainImage15");
		ExplainImage16 = GameObject.Find ("ExplainImage16");
		ExplainImage17 = GameObject.Find ("ExplainImage17");
		ExplainImage18 = GameObject.Find ("ExplainImage18");
		ExplainImage19 = GameObject.Find ("ExplainImage19");

	}
	public void CloseElement()
	{
		ExplainImage1.SetActive (false);
		ExplainImage2.SetActive (false);
		ExplainImage3.SetActive (false);
		ExplainImage4.SetActive (false);
		ExplainImage5.SetActive (false);
		ExplainImage6.SetActive (false);
		ExplainImage7.SetActive (false);
		ExplainImage8.SetActive (false);
		ExplainImage9.SetActive (false);
		ExplainImage10.SetActive (false);
		ExplainImage11.SetActive (false);
		ExplainImage12.SetActive (false);
		ExplainImage13.SetActive (false);
		ExplainImage14.SetActive (false);
		ExplainImage15.SetActive (false);
		ExplainImage16.SetActive (false);
		ExplainImage17.SetActive (false);
		ExplainImage18.SetActive (false);
		ExplainImage19.SetActive (false);
	}
	public void	StartImage(){
		showImage.sprite = Resources.Load<Sprite> ("ExplainImage/ExplainImage" + (imageCounter).ToString ());
	}
	public void	EventClearNext(){
		imageCounter++;
		showImage.sprite = Resources.Load<Sprite> ("ExplainImage/ExplainImage" + (imageCounter).ToString ());
	}



	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log (imageCounter);
		if(eventData.button == PointerEventData.InputButton.Left){
			if (imageCounter<= 2 
			|| imageCounter==4 
			|| imageCounter==6 
			||imageCounter==7
				||imageCounter==8
			||imageCounter==11
			||imageCounter== 13
			||imageCounter==14
			||imageCounter==15
			||imageCounter==18
			||imageCounter==19 
			)
			{
				EventClearNext ();
			}
		}
		if(eventData.button == PointerEventData.InputButton.Right){
			if(imageCounter == 5){
				EventClearNext();
			}

			if(imageCounter ==9){
				Debug.Log ("hi");
				UserInterfaceManager uSM = GameObject.Find("UserInterfaceManager").GetComponent<UserInterfaceManager>();
				if (uSM.OnInventory) {
					Debug.Log (uSM.OnInventory);
					EventClearNext ();
				}
			}
				
		}
	}

	public void OnButtonDown(BaseEventData eventData)
	{

	}

	public void InventoryOpen(){
		
		if (imageCounter == 9) {
			//if(AxisEventData.)
		}
	}	





	public void ControlExplainImage(bool state)
	{
		showImage.enabled = state;
	}



}
