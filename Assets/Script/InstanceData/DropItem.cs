using UnityEngine;
using System.Collections;

public class DropItem : MonoBehaviour
{
	//complex data field
	public float power = 100000;
	public Rigidbody rigid;
	public Item itemInfo;
	public int gold;
	public TextMesh text;
	public bool onCreate;

	public Item ItemInfo
	{
		get { return itemInfo; }
	}

	public int Gold
	{
		get { return gold; }
	}
	
	// initialize this script
	void Start()
	{	
		//go to sky	
		Vector3 force = transform.up * power;	
		rigid = GetComponent<Rigidbody>();
		rigid.AddForce( force );
		rigid.velocity = transform.up * power;
		

		//set item info
		if (gameObject.name == "DropGold")
		{
			text = transform.Find( "DropGoldImage" ).Find( "DropGoldName" ).GetComponent<TextMesh>();
			gold = Random.Range( 0, 1000 );
			text.text = gold.ToString() + " Gold";
		}
		else if (gameObject.name == "DropItem")
		{
			text = transform.Find( "DropItemImage" ).Find( "DropItemName" ).GetComponent<TextMesh>();
			itemInfo = new Item(DataBase.Instance.FindItemById( Random.Range( 1, 5 ) ));
			text.text = itemInfo.Name;
			text.color = itemInfo.SetTextColor();
		}		
	}



}
