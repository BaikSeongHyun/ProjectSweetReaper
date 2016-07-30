using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public Transform transform1;
	public Transform transform2;
	public Transform transform3;
	public GameObject ui;
	public GameObject gameController;
	int positionChange=0;
	float moveTime=0.0f;
	Vector3 startPosition;
	Quaternion startRotation;
	CharacterFaye faye;
	bool savePoint = false;
	// Use this for initialization
	void Start () {
		faye = GameObject.Find ("Faye").GetComponent<CharacterFaye> ();

	}
	
	// Update is called once per frame
	void Update () {
		CameraMoveMethod (faye.OnSpecialActive);
	}

	public void SaveCameraPosition(){
		startPosition = Camera.main.transform.position;
		startRotation = Camera.main.transform.rotation;
	}
	public void CameraMoveMethod(bool Trigger){
		if (Trigger) {
			transform.LookAt (faye.transform);
			gameController.SetActive (false);
			ui.SetActive (false);
			if (!savePoint) {
				SaveCameraPosition ();
				savePoint = true;
			}
			if (positionChange == 0) {
				moveTime += Time.unscaledDeltaTime;
				Camera.main.transform.position = Vector3.Lerp (this.transform.position, transform1.transform.position, Time.unscaledDeltaTime * 3f);
				if (Vector3.Distance (this.transform.position, transform1.transform.position) <= 0.1f && moveTime >= 3.0f) {
					positionChange++;
					moveTime = 0.0f;
				}
			} else if (positionChange == 1) {
				moveTime += Time.unscaledDeltaTime;
				Camera.main.transform.position = Vector3.Lerp (this.transform.position, transform2.transform.position, Time.unscaledDeltaTime * 3f);
				if (Vector3.Distance (this.transform.position, transform2.transform.position) <= 0.1f && moveTime >= 2.0f) {
					positionChange++;
					moveTime = 0.0f;
				}

			} else if (positionChange == 2) {
				moveTime += Time.unscaledDeltaTime;
				Camera.main.transform.position = Vector3.Lerp (this.transform.position, transform3.transform.position, Time.unscaledDeltaTime * 3f);
				if (Vector3.Distance (this.transform.position, transform3.transform.position) <= 0.1f && moveTime >= 2.0f) {
					positionChange++;
					moveTime = 0.0f;
				}
			} else if (positionChange == 3) {
				moveTime += Time.unscaledDeltaTime;
				Camera.main.transform.position = Vector3.Lerp (this.transform.position, startPosition, Time.unscaledDeltaTime * 3f);
				Camera.main.transform.rotation = Quaternion.Lerp (this.transform.rotation, startRotation, Time.unscaledDeltaTime * 3f);
				if (Vector3.Distance (this.transform.position, startPosition) <= 0.1f && moveTime >= 3.0f) {
					moveTime = 0.0f;
					Trigger = false;
					savePoint = false;
					positionChange = 0;
				}
			}
		} else {
			moveTime = 0.0f;
			savePoint = false;
			positionChange = 0;
			gameController.SetActive(true);
			ui.SetActive (true);
		}
	}
}
