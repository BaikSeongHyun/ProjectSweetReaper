using UnityEngine;
using System.Collections;

public class NightmareFayeSummon : MonoBehaviour {

	public GameObject[] NightmareArray;

	public GameObject NightmareFaye;
	// Use this for initialization

	public bool fayeSummonCheck;

	void Start ()
	{
		fayeSummonCheck = false;
	}
	// Update is called once per frame
	void Update () 
	{
		if (!NightAliveCheck ())
		{
			if (!fayeSummonCheck)
			{
				
				var Nightmarefaye = Instantiate (NightmareFaye, transform.position, transform.rotation);
				Nightmarefaye.name = "NightmareFaye";

				fayeSummonCheck = true;
			}

			Destroy (this.gameObject, 1.0f);
		}

	}

	public bool NightAliveCheck()
	{
		for (int i = 0; i < NightmareArray.Length; i++)
		{
			if (NightmareArray[i] != null)
				return true;
		}
		return false;
	}
}
