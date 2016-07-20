using UnityEngine;
using System.Collections;

public class RaceFieldManager : MonoBehaviour {

	public int cnt=0;
	public int lineOfObstacleLimit=0;
	public int ObstaclePlacement = 0;
	public int sectionDistance = 30;
	public int ObstacleCount = 0;

	Transform[] position;
	GameObject[] obstacle;
	public GameObject[] box;

	int boxCount = 0;

	// Use this for initialization
	void Start () {
		CreateObstacle ();
		Invoke ("RecycleObstacle", 5.0f);
	}


	//Obstacle Initialize and Create
	public void RecycleObstacle(){
		for (int i = 0; i < boxCount; i++) {
			Destroy (obstacle [i].gameObject);
		}
		boxCount = 0;
		CreateObstacle ();
	}

	//create Obstacle
	public void CreateObstacle(){
		
		position = new Transform[cnt];

		for (int i = 0; i < cnt; i++) {
			position [i] = GameObject.Find("Position"+i).GetComponent<Transform> ();
			for (int j = 0; j < lineOfObstacleLimit; j++) {
				boxCount++;
			}
		}

		obstacle = new GameObject[boxCount];

		for (int i = 0; i < boxCount; i++) {
			//Random Obstacle
			int Counter = Random.Range (0, ObstacleCount);
			obstacle [i] = (GameObject)Instantiate (box[Counter], box[Counter].transform.position, box[Counter].transform.rotation);
			obstacle [i].name = "obstacle" + i;
		}

		boxCount = 0;

		for (int i = 0; i < cnt; i++) {
			for (int j = 0; j < lineOfObstacleLimit; j++) {
				int randomPosition = Random.Range (0, ObstaclePlacement);
				//Obstacle position reset 
				obstacle [boxCount].transform.position = new Vector3 (position [i].transform.position.x,obstacle[boxCount].transform.position.y ,position [i].transform.position.z+randomPosition);
				position [i].transform.position = new Vector3 (position [i].transform.position.x, obstacle [boxCount].transform.position.y, position [i].transform.position.z + sectionDistance);
				boxCount++;
			}

			//Position initialize
			position [i].transform.position = new Vector3 (position [i].transform.position.x, 0, position [i].transform.position.z - (sectionDistance*lineOfObstacleLimit));
		}
	}

}
