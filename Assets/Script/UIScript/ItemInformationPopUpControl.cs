using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//item information pop up
public class ItemInformationPopUpControl : MonoBehaviour
{
	//pop up component
	public Image backGround;
	public Text itemName;
	public Text rarity;
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
		rarity = transform.Find( "RarityText" ).GetComponent<Text>();
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
		rarity.enabled = state;
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
		else if (info.InstallSection == Item.Section.Consume)
			return;
		else
		{
			ControlComponent( true );
			itemName.text = info.Name;
			itemName.color = info.SetTextColor();
			rarity.text = info.SetRarityText();
			price.text = info.Price.ToString();
			coreRank.text = "CoreRank : " + info.CoreRank.ToString();
			weaponCri.text = "Critical : " + info.WeaponCri.ToString();

			switch (info.InstallSection)
			{
				case Item.Section.Blade:
					section.text = "Blade";
					element1Text.text = "ATK : " + info.WeaponAtk.ToString();
					element2Text.text = "STR : " + info.WeaponStr.ToString();
					element3Text.text = "DEX : " + info.WeaponDex.ToString();
					break;
				case Item.Section.Top:
					section.text = "Top";
					element1Text.text = "ATK : " + info.WeaponAtk.ToString();
					element2Text.text = "STR : " + info.WeaponStr.ToString();
					element3Text.text = "DEX : " + info.WeaponDex.ToString();
					break;
				case Item.Section.Bottom:
					section.text = "Bottom";
					element1Text.text = "DEF : " + info.WeaponDef.ToString();
					element2Text.text = "INT : " + info.WeaponInt.ToString();
					element3Text.text = "LUCK : " + info.WeaponLuck.ToString();
					break;
				case Item.Section.Handle:
					section.text = "Handle";
					element1Text.text = "DEF : " + info.WeaponDef.ToString();
					element2Text.text = "INT : " + info.WeaponInt.ToString();
					element3Text.text = "LUCK : " + info.WeaponLuck.ToString();
					break;
			}
		}			
	}
}

