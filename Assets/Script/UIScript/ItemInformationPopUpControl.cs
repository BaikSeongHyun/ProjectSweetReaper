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
	public Text element1Text;
	public Text element2Text;
	public Text element3Text;

	//link all component
	public void LinkComponent()
	{
		backGround = transform.Find( "ItemPopUpBack" ).GetComponent<Image>();
		itemName = transform.Find( "ItemNameText" ).GetComponent<Text>();
		coreRank = transform.Find( "CoreRankText" ).GetComponent<Text>();
		weaponCri = transform.Find( "CriticalText" ).GetComponent<Text>();
		section = transform.Find( "SectionText" ).GetComponent<Text>();

		element1Text = transform.Find( "Element1Text" ).GetComponent<Text>();
		element2Text = transform.Find( "Element2Text" ).GetComponent<Text>();
		element3Text = transform.Find( "Element3Text" ).GetComponent<Text>();	

		price = transform.Find( "PriceText" ).GetComponent<Text>();
	}

	//control all component  by state
	public void ControlComponent( bool state )
	{
		backGround.enabled = state;
		itemName.enabled = state;
		section.enabled = state;
		coreRank.enabled = state;
		weaponCri.enabled = state;
		element1Text.enabled = state;
		element2Text.enabled = state;
		element3Text.enabled = state;
		price.enabled = state;
	}

	//update item information
	public void UpdateItemInformation( Item info, Vector3 popUpPosition )
	{
		//position set
		transform.position = popUpPosition + new Vector3 ( 50f, -50f );

		if (info == null)
			return;
		else if (info.Section == Item.SECTION.Consume)
			return;
		else
		{
			ControlComponent( true );
			itemName.text = info.Name;
			price.text = info.Price.ToString();
			coreRank.text = "CoreRank : " + info.CoreRank.ToString();
			weaponCri.text = "Critical : " + info.WeaponCri.ToString();

			switch (info.Section)
			{
				case Item.SECTION.Blade:
					section.text = "Blade";
					element1Text.text = "ATK : " + info.WeaponAtk.ToString();
					element2Text.text = "STR : " + info.WeaponStr.ToString();
					element3Text.text = "DEX : " + info.WeaponDex.ToString();
					break;
				case Item.SECTION.Top:
					section.text = "Top";
					element1Text.text = "ATK : " + info.WeaponAtk.ToString();
					element2Text.text = "STR : " + info.WeaponStr.ToString();
					element3Text.text = "DEX : " + info.WeaponDex.ToString();
					break;
				case Item.SECTION.Bottom:
					section.text = "Bottom";
					element1Text.text = "DEF : " + info.WeaponDef.ToString();
					element2Text.text = "INT : " + info.WeaponInt.ToString();
					element3Text.text = "LUCK : " + info.WeaponLuck.ToString();
					break;
				case Item.SECTION.Handle:
					section.text = "Handle";
					element1Text.text = "DEF : " + info.WeaponDef.ToString();
					element2Text.text = "INT : " + info.WeaponInt.ToString();
					element3Text.text = "LUCK : " + info.WeaponLuck.ToString();
					break;
			}
		}			
	}
}

