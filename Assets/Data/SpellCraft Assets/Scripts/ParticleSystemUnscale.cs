using UnityEngine;
using System.Collections;

public class ParticleSystemUnscale : MonoBehaviour {

	private void Awake(){
		particle = GetComponent<ParticleSystem> ();
	}

	void Start(){
	}

	void Update(){
		particle.Simulate (Time.unscaledDeltaTime, true, false);
	}

	private ParticleSystem particle;
}
