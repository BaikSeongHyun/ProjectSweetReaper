using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterDungeon : MonoBehaviour
{
	public CharacterInformation charInfo;

	public void LinkElement(CharacterInformation info)
	{
		charInfo = info;
	}

	public void FirstAreaDungeonSelect( string name )
	{
		switch (name)
		{
			case "Forest":
				charInfo.SaveCharacterInformation();
				SceneManager.LoadScene( "Forest" );
				break;
			case "Cave":
				charInfo.SaveCharacterInformation();
				SceneManager.LoadScene( "Cave" );
				break;
		}
	}
}
