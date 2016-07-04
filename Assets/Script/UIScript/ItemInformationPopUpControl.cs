using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//item information pop up
public class ItemInformationPopUpControl : MonoBehaviour
{
	//pop up component
	public Image backGround;
	public Text itemName;
	public Text price;
	public Text coreRank;
	public Text weaponCri;
	public Text section;
	public Text element1;
	public Text element2;
	public Text element3;

	//link all component
	public void LinkComponent()
	{
		backGround = transform.Find( "ItemInformationPopUpBackGround" ).GetComponent<Image>();
		itemName = transform.Find( "ItemNameText" ).GetComponent<Text>();
		price = transform.Find( "PriceText" ).GetComponent<Text>();
		coreRank = transform.Find( "CoreRankText" ).GetComponent<Text>();
		weaponCri = transform.Find( "CriticalText" ).GetComponent<Text>();
		section = transform.Find( "SectionText" ).GetComponent<Text>();

		element1 = transform.Find( "Element1" ).GetComponent<Text>();
		element2 = transform.Find( "Element2" ).GetComponent<Text>();
		element3 = transform.Find( "Element3" ).GetComponent<Text>();		
	}

	public void ControlComponent( bool state )
	{
		backGround.enabled = state;
		itemName.enabled = state;
		price.enabled = state;
		coreRank.enabled = state;
		weaponCri.enabled = state;
		element1.enabled = state;
		element2.enabled = state;
		element3.enabled = state;
	}

	//update item information
	public void UpdateItemInformation( Item info, Vector3 popUpPosition )
	{
		transform.position = popUpPosition;
		if (info == null)
			return;
		else if (info.Section == Item.SECTION.Consume)
			return;
		else
		{
			ControlComponent( true );
			itemName.text = info.Name;
			price.text = info.Price.ToString();
			coreRank.text = info.CoreRank.ToString();
			weaponCri.text = info.WeaponCri.ToString();

			switch (info.Section)
			{
				case Item.SECTION.Blade:
					section.text = "Blade";
					element1.text = info.WeaponAtk.ToString();
					element2.text = info.WeaponStr.ToString();
					element3.text = info.WeaponDex.ToString();
					break;
				case Item.SECTION.Top:
					section.text = "Top";
					element1.text = info.WeaponAtk.ToString();
					element2.text = info.WeaponStr.ToString();
					element3.text = info.WeaponDex.ToString();
					break;
				case Item.SECTION.Bottom:
					section.text = "Bottom";
					element1.text = info.WeaponDef.ToString();
					element2.text = info.WeaponInt.ToString();
					element3.text = info.WeaponLuck.ToString();
					break;
				case Item.SECTION.Handle:
					section.text = "Handle";
					element1.text = info.WeaponDef.ToString();
					element2.text = info.WeaponInt.ToString();
					element3.text = info.WeaponLuck.ToString();
					break;
			}
		}

			
	}
}

