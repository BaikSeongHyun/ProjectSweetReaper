using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SystemUI : MonoBehaviour
{
	//complex data field
	public UserInterfaceManager mainUI;
	public Text[] elements;
	public List<string> elementsText;

	public void LinkElement()
	{
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
		elements = new Text[5];
		for (int i = 0; i < elements.Length; i++)
		{
			string name = "Element" + (i + 1).ToString();
			elements[i] = transform.Find( name ).GetComponent<Text>();
		}
		elementsText = new List<string>();
	}

	public void AddData( string data )
	{
		elementsText.Add( data );
		
		if (elementsText.Count > 5)
			elementsText.RemoveAt( 0 );
	}

	public void UpdateSystem()
	{
		for (int i = 0; i < elementsText.Count; i++)
			elements[i].text = elementsText[i];		
	}
	
	
}
