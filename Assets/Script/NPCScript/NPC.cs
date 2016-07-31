using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
	public GameController mainControl;
	public RectTransform popUp;
	public Type npcType;
	public Image popUpLogic;

	public enum Type
	{
		Store,
		Race,
		Default}

	;

	// initialize this script
	void Start()
	{
		mainControl = GameObject.FindWithTag( "GameController" ).GetComponent<GameController>();
		popUp = transform.Find( "Canvas" ).GetComponent<RectTransform>();
		popUpLogic = popUp.Find( "NPCUI" ).GetComponent<Image>();
		popUpLogic.enabled = false;
		
	}

	void OnTriggerEnter( Collider coll )
	{
		mainControl.ConnectNPC( npcType, this.gameObject );
		popUpLogic.enabled = true;
	}

	void OnTriggerStay( Collider coll )
	{
		popUp.transform.forward = Camera.main.transform.forward;
		
		if (coll.gameObject.layer == LayerMask.NameToLayer( "Player" ))
			this.transform.LookAt( coll.gameObject.transform.position, Vector3.up );		
	}

	void OnTriggerExit()
	{
		mainControl.DisConnectNPC();	
		popUpLogic.enabled = false;
	}
}
