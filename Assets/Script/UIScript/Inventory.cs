using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour
{

	//complex data field
	public CharacterInformation info;
	public Item topInstall;
	public Item bottomInstall;
	public Item bladeInstall;
	public Item handleInstall;
	public Item[] charItem;
	public Image[] itemSlot;
	public Text money;

	//Initialize this script
	void Start( )
	{
		info = GameObject.FindWithTag("Player").GetComponent<CharacterInformation>();
		LinkElement();
		InitializeElement();
	}

	//another method
	public void InitializeElement()
	{		
		charItem = new Item[35];
		itemSlot = new Image[35];
	}

	public void LinkElement()
	{
		money = transform.Find( "MoneyText" ).GetComponent<Text>();
	}
	
	public void UpdateInventory()
	{
		money.text = info.Money.ToString();
	}
}
