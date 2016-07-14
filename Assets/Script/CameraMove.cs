using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	public GameObject faya;

	void Update()
	{
		transform.LookAt( faya.transform );
	}
}
