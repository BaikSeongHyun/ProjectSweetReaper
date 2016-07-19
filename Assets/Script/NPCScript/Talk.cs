using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Talk : NPC
{

	public Text[] txt;
	public int count;
	public GameObject UI;
	int i = 0;
	float Timer = 0;
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		if (i == count)
		{
			UI.SetActive( true );
			talk.SetActive( false );
		}
		else
		{
			if (Timer >= 5.0f)
			{
				Timer = 0.0f;
				txt[i].gameObject.SetActive( false );
				i++;
			}
			else
			{
				UI.SetActive( false );
				Timer += Time.deltaTime;
				txt[i].gameObject.SetActive( true );
			}
		}
	}
}
