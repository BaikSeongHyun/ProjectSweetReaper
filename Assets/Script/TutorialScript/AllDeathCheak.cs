using UnityEngine;
using System.Collections;

public class AllDeathCheak : MonoBehaviour {
	public GameObject cube3;
	public GameObject[] tutorialFrog;
	public ExplainImage explainImage;
	public GameObject MonsterArrayList;

	// Update is called once per frame
	void Start(){
		explainImage = GameObject.Find ("ExplainImage").GetComponent<ExplainImage>();
		MonsterArrayList.SetActive (false);
	}

	void Update () {
		if(explainImage.imageCounter == 12)	
		{
			MonsterArrayList.SetActive (true);

		}
		if (!MonsterAliveCheck ()) {
			explainImage.SendMessage ("EventClearNext");
			Destroy (this.gameObject);
		}
	}

	public bool MonsterAliveCheck()
	{
		for (int i = 0; i < tutorialFrog.Length; i++)
		{
			if (tutorialFrog[i] != null)
				return true;
		}
		return false;
	}


}
