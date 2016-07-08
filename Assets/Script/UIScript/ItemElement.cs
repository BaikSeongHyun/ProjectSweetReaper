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

	public Image ItemIcon
	{
		get { return itemIcon; }
	}

	// initialize this script
	void Start()
	{
		itemIcon = GetComponent<Image>();
		iPopUp = GameObject.FindWithTag( "ItemPopUp" ).GetComponent<ItemInformationPopUpControl>();
		//itemInfo = null;
	}

	//update item pop up
	public void UpdateItemPopUp()
	{
		if (ItemInfo == null)
			return;
		
		iPopUp.LinkComponent();
		iPopUp.ControlComponent( true );
		iPopUp.UpdateItemInformation( itemInfo, transform.position);
	}

	//close item pop up
	public void CloseItemPopUp()
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
