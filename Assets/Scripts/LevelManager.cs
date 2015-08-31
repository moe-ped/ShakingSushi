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

		// Check if playerprefs has highscore key
		if (!PlayerPrefs.HasKey ("highscore")) {
			// if not, create highscore key with setInt = Score
			PlayerPrefs.SetInt ("highscore", Game.Instance.Score);
		}
		else if (PlayerPrefs.HasKey ("highscore")) {
			// if true, check if higscore int is smaller than Score
			if (PlayerPrefs.GetInt ("highscore") < Game.Instance.Score) {
				// if true, overwrite highscore int = Score
				PlayerPrefs.SetInt ("highscore", Game.Instance.Score);
			}
		}

		Cursor.visible = true;
		Application.LoadLevel("menu");
	}
}
