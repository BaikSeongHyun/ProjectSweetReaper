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
	public ItemElement[] elements;
	public Text money;

	//Initialize this script
	void Start()
	{
		info = GameObject.FindWithTag( "Player" ).GetComponent<CharacterInformation>();
		LinkElement();
		InitializeElement();
	}

	//another method
	public void InitializeElement()
	{		
		elements = new ItemElement[35];
	}

	public void LinkElement()
	{
		money = transform.Find( "MoneyText" ).GetComponent<Text>();
		for(int i = 0; i < elements.Length; i++)
		{
			string slot = "ItemSlot";
			slot += ( i + 1 ).ToString();
			elements [i] = transform.Find( slot ).GetComponent<ItemElement>();
		}
	}

	public void UpdateInventory()
	{
		money.text = info.Money.ToString();
	}
}
