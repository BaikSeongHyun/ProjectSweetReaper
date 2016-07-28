using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SystemUI : MonoBehaviour
{
	//complex data field
	public UserInterfaceManager mainUI;
	public Text[] elements;
	public Queue<string> elementsText;


	public void LinkElement()
	{
		mainUI = GameObject.FindWithTag( "MainUI" ).GetComponent<UserInterfaceManager>();
		elements = new Text[5];
		for (int i = 0; i < elements.Length; i++)
		{
			string name = "Element" + (i + 1).ToString();
			elements[i] = transform.Find( name ).GetComponent<Text>();
		}
		elementsText = new Queue<string>();
	}

	public void AddData( string data )
	{
		elementsText.Enqueue( data );
		
		if (elementsText.Count > 5)
			elementsText.Dequeue();
	}

	public void UpdateSystem()
	{
		string[] temp = elementsText.ToArray();
		for (int i = 0; i < elementsText.Count; i++)
			elements[i].text = temp[i];		
	}
	
	
}
