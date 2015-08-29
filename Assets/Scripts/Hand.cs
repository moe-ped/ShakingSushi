using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Hand : MonoBehaviour 
{
	public GameObject OpenSprite;
	public GameObject ClosedSprite;
	public ClipEffect ClipEffect;

	void Update () 
	{
		transform.position = Input.mousePosition;
		if (Input.GetMouseButtonDown (0)) 
		{
			OpenSprite.SetActive (false);
			ClosedSprite.SetActive (true);
			//ClipEffect.Activate ();
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			OpenSprite.SetActive (true);
			ClosedSprite.SetActive (false);
		}
	}
}
