using UnityEngine;
using System.Collections;

public class DungeonClearScript : MonoBehaviour
{
	public Transform createTransform;
	public GameObject returnCampObject;
	public GameObject bossMonster;
	public bool onCreate;
	public GameObject[] items;

	// initialize this script
	void Start()
	{
		onCreate = false;	
	}
	
	// Update is called once per frame
	void Update()
	{
		if (bossMonster == null&& !onCreate)
		{
			Instantiate( returnCampObject, createTransform.position, createTransform.rotation );
			onCreate = true;
		}		
	}

	
}
