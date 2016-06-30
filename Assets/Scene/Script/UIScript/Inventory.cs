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

	//Initialize this script
	void Start( )
	{
		
	}

	//another method
	public void InitializeInventory()
	{
		charItem = new Item[info.CharacterItem.Length];
		itemSlot = new Image[info.CharacterItem.Length];
	}
	public void LinkComponent()
	{
		info = GameObject.Find("Player").GetComponent<CharacterInformation>();
	}
	
	public void UpdateInventory()
	{
		
	}
}
