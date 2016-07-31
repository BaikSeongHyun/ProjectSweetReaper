using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterDungeon : MonoBehaviour
{
	public CharacterInformation charInfo;

	public void LinkElement( CharacterInformation info )
	{
		charInfo = info;
	}

	public void FirstAreaDungeonSelect( string name )
	{
		charInfo.SaveCharacterInformation();
		switch (name)
		{
			case "Forest":
				SceneManager.LoadScene( "Forest" );
				break;
			case "Cave":
				SceneManager.LoadScene( "Cave" );
				break;
			case "Nightmare":
				SceneManager.LoadScene( "Nightmare" );
				break;
		}
	}
}
