using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {
	Vector3 target;
	public GameObject talk;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			talk.SetActive (true);
		}
	}

	void OnTriggerStay(Collider coll){
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			this.transform.LookAt (coll.gameObject.transform.position,Vector3.up);
		}
	}
}
