using UnityEngine;
using System.Collections;

public class Shaking : MonoBehaviour {
	public float shakes = 0f;
	public float shakeAmount = 0.0f;
	public float decreaseFactor = 1.0f;
	Vector3 originalPos;
	bool CameraShaking;

	void Start()
	{
		originalPos = gameObject.transform.position;
		CameraShaking = false;
	}
	public void ShakeCamera(float shaking) 
	{
		shakes = shaking;
		originalPos = gameObject.transform.position;
		CameraShaking = true;
	}

	void FixedUpdate()
	{

		if (CameraShaking) {
			if (shakes > 0)  
			{
				gameObject.transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
				gameObject.transform.position += new Vector3(0f,-0.05f,0f);

				shakes -= Time.deltaTime * decreaseFactor;
			}
			else
			{
				shakes = 0f;
				gameObject.transform.localPosition= originalPos;
				CameraShaking = false;
			}


		}

	}
}