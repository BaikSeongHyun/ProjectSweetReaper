using UnityEngine;
using System.Collections;

public class eventfield : MonoBehaviour {
	public TutorialManager tutorialManager;
	public GameObject box;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.CompareTag("Player")) {
			tutorialManager.SendMessage ("aa");
			Destroy (this.gameObject);
		}
	}
}
