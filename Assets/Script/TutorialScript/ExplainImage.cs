using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ExplainImage : MonoBehaviour, IPointerDownHandler {


	public int imageCounter;
	public Image showImage;



	// Use this for initialization
	void Start () {
		showImage = gameObject.GetComponent<Image> ();
		imageCounter = 1;	
		StartImage();

	}

	void Update()
	{
		
	}


	public void	StartImage(){
		showImage.sprite = Resources.Load<Sprite> ("ExplainImage/ExplainImage" + (imageCounter).ToString ());
	}
	public void	EventClearNext(){
		imageCounter++;
		showImage.sprite = Resources.Load<Sprite> ("ExplainImage/ExplainImage" + (imageCounter).ToString ());
	}
	public void EventUnRealrize()
	{	showImage.sprite = Resources.Load<Sprite>("ExplainImage/ExplainImage"+(imageCounter).ToString());
	}



	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log (imageCounter);
		if(eventData.button == PointerEventData.InputButton.Left){
			if (imageCounter<= 2 
			|| imageCounter==4 
			|| imageCounter==6 
			||imageCounter==8
			||imageCounter==11
			||imageCounter== 13
			||imageCounter==14
			||imageCounter==18
			||imageCounter==19 
			)
			{
				EventClearNext ();
			}
		
		}


	}











	public void ControlExplainImage(bool state)
	{
		showImage.enabled = state;
	}



}
