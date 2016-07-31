using UnityEngine;
using System.Collections;

public class NightmareFayeSummon : MonoBehaviour
{
	public bool nightmareIsSummon;
	
	public Transform summonPosition;
	public GameObject[] monsterList;
	public GameObject NightmareFaye;
	public GameObject createdNightmareFaye;
	

	// initialize this script
	void Start()
	{
		nightmareIsSummon = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (!MonsterAliveCheck() && !nightmareIsSummon)
		{
			createdNightmareFaye = (GameObject)Instantiate( NightmareFaye, transform.position, transform.rotation );
			nightmareIsSummon = true;
		}
		
		if (createdNightmareFaye != null)
			Destroy( this.gameObject );
	}

	public bool MonsterAliveCheck()
	{
		for (int i = 0; i < monsterList.Length; i++)
		{
			if (monsterList[i] != null)
				return true;
		}
		return false;
	}
}
