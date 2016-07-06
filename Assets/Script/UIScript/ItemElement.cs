using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemElement : MonoBehaviour
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
		iPopUp = GameObject.FindWithTag( "ItemPopUp" ).GetComponent<ItemInformationPopUpControl>();

	}

	//update item pop up
	public void UpdateItemPopUp()
	{
		iPopUp.LinkComponent();
		iPopUp.ControlComponent( true );
		iPopUp.UpdateItemInformation( itemInfo, transform.position );
	}

	//close item pop up
	public void CloseItemPopup()
	{
		iPopUp.ControlComponent( false );
	}

	//set item icon -> no item set default
	public void UpdateItemIcon()
	{
		if (itemInfo == null)
			return;
		//data base allow
		else
			return;
	}
}
