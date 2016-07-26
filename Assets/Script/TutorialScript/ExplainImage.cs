using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ExplainImage : MonoBehaviour, IPointerDownHandler {

	int imageCounter;
	Image showImage;

	// Use this for initialization
	void Start () {
		showImage = GetComponent<Image> ();
		imageCounter = 1;	
	}

	void Update()
	{
		
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			if (imageCounter <= 7) {
				imageCounter++;
				showImage.sprite = Resources.Load<Sprite> ("ExplainImage/ExplainImage" + (imageCounter).ToString ());
			}

		}

	}

	public void ControlExplainImage(bool state)
	{
		showImage.enabled = state;
	}

	public void NextTutorialImage(){
		imageCounter =7;
		showImage.sprite = Resources.Load<Sprite> ("ExplainImage/ExplainImage" + (imageCounter).ToString ());
	}

}
