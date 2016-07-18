using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemElement : MonoBehaviour
{
	//complex data field
	public ItemInformationPopUpControl itemPopUp;
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
		itemPopUp = GameObject.Find( "ItemPopUp" ).GetComponent<ItemInformationPopUpControl>();
	}

	//update item pop up
	public void UpdateItemPopUp()
	{
		if (itemInfo.Name == "Default")
			return;
		
		itemPopUp.LinkComponent();
		itemPopUp.ControlComponent( true );
		itemPopUp.UpdateItemInformation( itemInfo, transform.position );
	}

	//close item pop up
	public void CloseItemPopUp()
	{
		itemPopUp.ControlComponent( false );
	}

	//set item icon -> no item set default
	public void UpdateItemIcon()
	{
		itemIcon = GetComponent<Image>();
		itemInfo.SetSpriteIcon();
		itemIcon.sprite = ItemInfo.Icon;		  
	}
}
