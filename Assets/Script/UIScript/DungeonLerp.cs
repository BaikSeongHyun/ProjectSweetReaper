using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DungeonLerp : MonoBehaviour
{

	public Image InsertDungeonImage;
	private Color startColor;
	private Color endColor;
	float delayTime;

	//initialize this script
	void Start()
	{
		InsertDungeonImage = GetComponent<Image>();
		startColor = InsertDungeonImage.color;
		endColor = startColor;
		endColor.a = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		delayTime += Time.deltaTime; 		
		if (delayTime >= 1)
		{
			InsertDungeonImage.color = Color.Lerp( InsertDungeonImage.color, endColor, Time.deltaTime );
			if (InsertDungeonImage.color.a < 0.1f)
			{
				InsertDungeonImage.enabled = false;
				//send massage kill this script for UIM
			}
		}

	}
}
