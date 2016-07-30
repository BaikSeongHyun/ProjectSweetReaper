using UnityEngine;
using System.Collections;

public class eventfield : MonoBehaviour {
	public ExplainImage explainImage;
	public GameObject box;


	// Use this for initialization
	void Start () {
		explainImage = GameObject.Find ("ExplainImage").GetComponent<ExplainImage>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionStay(Collision coll){
		if(explainImage.imageCounter == 3)
		{
			if (coll.gameObject.CompareTag ("Player")) {
			
				explainImage.SendMessage ("EventClearNext");
				Destroy (this.gameObject);
				}
			}
		}
}
