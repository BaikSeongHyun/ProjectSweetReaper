using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
	public GameObject gate;
	public GameObject[] monsterArray;

	void Start () {
		}
	// Update is called once per frame
	void Update () {
		if(!MonsterAliveCheck()){
		Destroy (this.gameObject);
		}
	}

	public bool MonsterAliveCheck()
	{
		for (int i = 0; i < monsterArray.Length; i++) {
			if (monsterArray [i] != null)
				return true;
		}
		return false;
	}

}
