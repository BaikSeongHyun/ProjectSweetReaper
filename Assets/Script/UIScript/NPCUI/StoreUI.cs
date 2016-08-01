using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class StoreUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
	public string presentName;

	public ItemElement[] sellItemList;
	public Text[] itemName;
	public Text[] itemBuyPrice;

	public UserInterfaceManager mainUI;
	public ItemElement presentItemElement;
	public ItemElement downPointItemElement;

	public void LinkElement()
	{
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();

		//ItemNameText, ItemPriceText
		sellItemList = new ItemElement[8];
		itemName = new Text[8];
		itemBuyPrice = new Text[8];
		for (int i = 0; i < sellItemList.Length; i++)
		{
			string name = "SellItemElement" + ( i + 1 ).ToString();
			sellItemList[i] = transform.Find( name ).GetComponent<ItemElement>();
			itemName[i] = sellItemList[i].transform.Find( "ItemNameText" ).GetComponent<Text>();
			itemBuyPrice[i] = sellItemList[i].transform.Find( "ItemPriceText" ).GetComponent<Text>();
		}
	}

	public void UpdateStoreUI()
	{
		for (int i = 0; i < sellItemList.Length; i++)
		{
			sellItemList[i].ItemInfo = new Item ( DataBase.Instance.FindItemById( Random.Range( 1, 8 ) ) );
			sellItemList[i].UpdateItemIcon();
			itemName[i].text = sellItemList[i].ItemInfo.Name;
			itemName[i].color = sellItemList[i].ItemInfo.SetTextColor();
			itemBuyPrice[i].text = ( (int) ( sellItemList[i].ItemInfo.Price * 10 ) ).ToString();			
		}
	}

	public void OnPointerEnter( PointerEventData eventData )
	{
		if (!mainUI.OnClickMouse)
			presentItemElement = eventData.pointerEnter.GetComponent<ItemElement>();

		if (( presentItemElement != null ) && !mainUI.OnClickMouse)
			presentItemElement.UpdateItemPopUp();				
	}

	public void OnPointerExit( PointerEventData eventData )
	{
		if (mainUI.PresentSelectItem.enabled)
			return;

		if (presentItemElement == null)
			return;

		presentItemElement.CloseItemPopUp();
		presentItemElement = null;
	}

	public void OnPointerDown( PointerEventData eventData )
	{
		if (presentItemElement != null)
		{
			presentItemElement.CloseItemPopUp();
			presentItemElement = null;
		}

		//insert item data
		try
		{			
			presentName = eventData.pointerEnter.name;
			presentItemElement = transform.Find( presentName ).gameObject.GetComponent<ItemElement>();
		}
		catch
		{
			presentItemElement = null;
		}
		//delete item
		if (presentItemElement == null)
			return;

		presentItemElement.CloseItemPopUp();

		if (eventData.button == PointerEventData.InputButton.Left && mainUI.ItemBuy)
			mainUI.BuyItemProcess( presentItemElement );

		mainUI.UpdateItemInformationByStoreUI();
	}
}
