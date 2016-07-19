using UnityEngine;
using System.Collections;

public class ObstacleEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Enermy")) {
			Destroy (this.gameObject);
		}
	}
}
