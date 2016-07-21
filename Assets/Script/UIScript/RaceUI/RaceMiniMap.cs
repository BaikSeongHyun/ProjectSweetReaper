using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RaceMiniMap : MonoBehaviour
{
	Scrollbar minimapBar;

	public void LinkElement()
	{
		minimapBar = transform.Find("Scrollbar").GetComponent<Scrollbar>();
	}

	public void UpdateMinimap(float information)
	{
		minimapBar.value = information;
	}
}
