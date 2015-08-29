using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour 
{
	void Update () 
	{
		transform.position = Input.mousePosition;
	}
}
