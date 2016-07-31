using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleImage : MonoBehaviour, IPointerDownHandler
{

	public void OnPointerDown( PointerEventData eventData )
	{
		if (eventData.button == PointerEventData.InputButton.Left ||	eventData.button == PointerEventData.InputButton.Right)
			SceneManager.LoadScene( "CampField" );
	}
	
}
