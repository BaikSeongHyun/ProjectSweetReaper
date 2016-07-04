using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ItemElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	//complex data field
	public ItemInformationPopUpControl iPopUp;
	public Image itemIcon;
	public Item itemInfo;

	//property
	public Item ItemInfo
	{
		set { itemInfo = value; }
		get { return itemInfo; }
	}

	// initialize this script
	void Start()
	{
		itemIcon = GetComponent<Image>();
		//iPopUp = transform.Find( "PopUp" ).GetComponent<ItemInformationPopUpControl>();
	}

	//pop up item information
	public void OnPointerEnter( PointerEventData eventData )
	{
		iPopUp.UpdateItemInformation(itemInfo, transform.position);
	}

	//pop up off
	public void OnPointerExit( PointerEventData eventData )
	{
		
	}

	//set item icon -> no item set default
	public void SetItemIcon()
	{
		if (itemInfo == null)
			return;
		//data base allow
		else
			return;
	}
}
