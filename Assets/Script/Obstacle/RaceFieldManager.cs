using UnityEngine;
using System.Collections;

public class RaceFieldManager : MonoBehaviour {

	public int cnt=4;
	public int lineOfObstacleLimit=2;
	public Transform[] position = new Transform[4];
	public GameObject[] obstacle;
	public GameObject box;
	int boxCount = 0;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < cnt; i++) {
			position [i] = GameObject.Find("Position"+i).GetComponent<Transform> ();
			for (int j = 0; j < lineOfObstacleLimit; j++) {
				boxCount++;
			}
		}

		obstacle = new GameObject[boxCount];

		for (int i = 0; i < boxCount; i++) {
			obstacle [i] = (GameObject)Instantiate (box, transform.position, transform.rotation);
		}

		//section
	}


}
