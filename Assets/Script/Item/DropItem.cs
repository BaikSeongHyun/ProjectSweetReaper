using UnityEngine;
using System.Collections;

public class DropItem : MonoBehaviour {

	public float power= 100000;
	public Rigidbody rigid;
	// Use this for initialization
	void Start () {
		
		Vector3 force = transform.up * power;	
		rigid = GetComponent<Rigidbody>();
		rigid.AddForce (force);
		rigid.velocity = transform.up * power;

	}
	

}
