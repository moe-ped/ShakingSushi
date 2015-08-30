using UnityEngine;
using System.Collections;

public class LoadManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.GetStreamProgressForLevel("menu") == 1) {
			Application.LoadLevel ("menu");
		}
	}
}
