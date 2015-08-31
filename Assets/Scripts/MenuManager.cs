using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public GameObject btn;
	public GameObject LogoPanel;
	public GameObject MenuBtnPanel;
	public GameObject ConfirmExitPanel;
	public GameObject HighscorePanel;
	public GameObject SettingsPanel;
	public GameObject MenuAudio;
	public GameObject DeleteHighscorePanel;

	private AudioSource[] audioSources;
	private AudioSource menuMusic;
	private AudioSource btnSound;

	// Use this for initialization
	void Awake () {
		audioSources = MenuAudio.GetComponents<AudioSource>();
		btnSound = audioSources[1];
		menuMusic = audioSources[0];
	}

	void Start(){
		menuMusic.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeMenu (GameObject btn) {
		
		btnSound.Play();

		// load main level when clicking the play btn
		if (btn.gameObject.name == "PlayBtn") {
			Debug.Log ("PlayBtn pressed");
			Application.LoadLevel ("Main");
		} 

		// Show the highscore panel when clicking the highscore btn
		else if (btn.gameObject.name == "HighscoreBtn") {
			Debug.Log ("HighscoreBtn pressed");
			MenuBtnPanel.SetActive (false);
			HighscorePanel.SetActive (true);

			if (PlayerPrefs.HasKey ("highscore")) {
				GameObject.Find ("HighscoreTxt").GetComponent<Text> ().text = PlayerPrefs.GetInt ("highscore").ToString ();
			}

		} 

		// Show settings panel when clicking the options btn
		else if (btn.gameObject.name == "SettingsBtn") {
			Debug.Log ("SettingsBtn pressed");
			MenuBtnPanel.SetActive (false);
			SettingsPanel.SetActive (true);
			GameObject.Find ("VolumeSlider").GetComponent<Slider> ().value = AudioListener.volume;
		} 

		// Show exit confirmation panel when clicking the exit btn
		else if (btn.gameObject.name == "ExitBtn") {
			Debug.Log ("Exit Btn pressed");
			MenuBtnPanel.SetActive (false);
			ConfirmExitPanel.SetActive (true);
		} 

		// Close game when player confirms the confirmation panel via the Yes btn
		else if (btn.gameObject.name == "YesBtn") {
			Debug.Log ("Exit confirmed");
			Application.Quit ();
		} 

		// Abort the game exit when the player clicks the No btn
		else if (btn.gameObject.name == "NoBtn") {
			Debug.Log ("Exit aborted");
			ConfirmExitPanel.SetActive (false);
			MenuBtnPanel.SetActive (true);
		} 


		// Disable the highscore soon panel and show the Menu panel
		else if (btn.gameObject.name == "BackBtn") {
			HighscorePanel.SetActive (false);
			SettingsPanel.SetActive (false);
			MenuBtnPanel.SetActive (true);
		} else if (btn.gameObject.name == "ApplyBtn") {
			PlayerPrefs.Save ();
		} else if (btn.gameObject.name == "ResetHighscoreBtn") {
			HighscorePanel.SetActive (false);
			DeleteHighscorePanel.SetActive (true);
		}
		else if (btn.gameObject.name == "DeleteHighscoreBtn") {
			DeleteHighscorePanel.SetActive(false);
			HighscorePanel.SetActive(true);

			//GameObject.Find ("HighscoreTxt").GetComponent<Text> ().text = 

		} else if (btn.gameObject.name == "AbortDeleteHighscoreBtn") {
			DeleteHighscorePanel.SetActive(false);
			HighscorePanel.SetActive(true);

		}
	}
}
