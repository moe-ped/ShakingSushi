using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
		GameObject.Find("LevelAudio").GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goToMenu(){
		Cursor.visible = true;
		Application.LoadLevel("menu");
	}
}
