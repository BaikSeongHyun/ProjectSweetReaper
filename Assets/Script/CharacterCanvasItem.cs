using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterCanvasItem : MonoBehaviour
{
	//canvas data
	Image comboGaugeFill;
	Image comboGaugeBack;
	public Image[] comboPointElement;
	
	
	
	//initialize component
	public void InitializeComponentData()
	{
		comboGaugeFill = transform.Find( "ComboGaugeFill" ).GetComponent<Image>();
		comboGaugeBack = transform.Find( "ComboGaugeBack" ).GetComponent<Image>();
		comboPointElement = new Image[4];
		for (int i = 0; i < comboPointElement.Length; i++)
		{
			string elementName = "Element" + (1 + i).ToString();
			comboPointElement[i] = transform.Find( "ComboPoint" ).Find( elementName ).GetComponent<Image>();
		}			
		
		ControlComponent( false );
	}
	
	//control element
	public void ControlComponent( bool state )
	{
		comboGaugeFill.enabled = state;	
		comboGaugeBack.enabled = state;
		for (int i = 0; i < comboPointElement.Length; i++)
			comboPointElement[i].enabled = state;
	}
	
	//update component data
	public void UpdateCanvas( int comboCounter, float gaugeFillAmount )
	{				
		ControlComponent( false );
		
		//rotation set
		//transform.LookAt(Camera.main.transform);
		transform.rotation = new Quaternion(transform.rotation.x, 0f, transform.rotation.z, transform.rotation.w);
		
		//combo gauge set up
		comboGaugeBack.enabled = true;
		comboGaugeFill.enabled = true;
		comboGaugeFill.fillAmount = gaugeFillAmount;
		
		//combo point set up
		for (int i = 0; i < comboCounter; i++)
			comboPointElement[i].enabled = true;
		
	}

}
