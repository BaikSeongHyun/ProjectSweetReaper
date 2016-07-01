using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterDungeon : MonoBehaviour
{
	
	public Image dungeonCheck;

	// initialize this script
	void start( )
	{
		dungeonCheck = transform.Find( "Forest" ).Find( "ForestCheck" ).GetComponent<Image>();
	}


	public void FirstAreaDungeonSelect( string name )
	{
		switch(name)
		{
			case "Forest":
				SceneManager.LoadScene( "Forest" );
				break;
		}
	}


}
