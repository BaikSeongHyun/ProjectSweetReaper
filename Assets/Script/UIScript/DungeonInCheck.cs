using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DungeonInCheck : MonoBehaviour , IPointerEnterHandler,IPointerExitHandler{

	// Use this for initialization

	public Image dungeonCheck;

	void start()
	{
		dungeonCheck =transform.Find("ForestCheck").GetComponent<Image> ();
		Debug.Log (dungeonCheck);

		ControlDungeonCheckImage (false);
	}
	public void ControlDungeonCheckImage(bool state)
	{
		dungeonCheck.enabled = state;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		ControlDungeonCheckImage (true);
		
		Debug.Log ("DungeonPopUp");
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		ControlDungeonCheckImage (false);

	}

}
