using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Options : MonoBehaviour {

	public float defaultVolume = 0.5f;

	// Use this for initialization
	void Start () {

		AudioListener.volume = 0.5f;

		DontDestroyOnLoad(this);


		if (!PlayerPrefs.HasKey ("settingsVolume")) {
			PlayerPrefs.SetFloat ("settingsVolume", defaultVolume);
		}

		else {
			AudioListener.volume = PlayerPrefs.GetFloat ("settingsVolume");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void adjustVolume(float sliderValue){
		if (PlayerPrefs.HasKey ("settingsVolume")) {
			PlayerPrefs.SetFloat ("settingsVolume", sliderValue);
			AudioListener.volume = sliderValue;
		}
	}

	public void resetHighscore(){
		if (PlayerPrefs.HasKey ("highscore")) {
			PlayerPrefs.DeleteKey("highscore");
			GameObject.Find("HighscoreTxt").GetComponent<Text>().text = "No Score yet!";
		}
	}

}
