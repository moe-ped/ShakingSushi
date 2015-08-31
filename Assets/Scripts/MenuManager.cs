using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public GameObject btn;
	public GameObject LogoPanel;
	public GameObject MenuBtnPanel;
	public GameObject ConfirmPanel;
	public GameObject ComingSoonPanel;
	public GameObject SettingsPanel;
	public GameObject MenuAudio;

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
			ComingSoonPanel.SetActive (true);
		} 

		// Show settings panel when clicking the options btn
		else if (btn.gameObject.name == "SettingsBtn") {
			Debug.Log ("SettingsBtn pressed");
			MenuBtnPanel.SetActive (false);
			SettingsPanel.SetActive (true);
			GameObject.Find("VolumeSlider").GetComponent<Slider>().value = AudioListener.volume;
		} 

		// Show exit confirmation panel when clicking the exit btn
		else if (btn.gameObject.name == "ExitBtn") {
			Debug.Log ("Exit Btn pressed");
			MenuBtnPanel.SetActive (false);
			ConfirmPanel.SetActive (true);
		} 

		// Close game when player confirms the confirmation panel via the Yes btn
		else if (btn.gameObject.name == "YesBtn") {
			Debug.Log ("Exit confirmed");
			Application.Quit ();
		} 

		// Abort the game exit when the player clicks the No btn
		else if (btn.gameObject.name == "NoBtn") {
			Debug.Log ("Exit aborted");
			ConfirmPanel.SetActive (false);
			MenuBtnPanel.SetActive (true);
		} 

		// Set cursor to visible and go to main menu when clicking the main menu button ingame
		// TODO: - this should not be part of the MenuManager script LOL, 
		else if (btn.gameObject.name == "MainMenuBtn") {
			Cursor.visible = true;
			Application.LoadLevel (0);
		} 

		// Disable the coming soon panel and show the Menu panel
		else if (btn.gameObject.name == "BackBtn") {
			ComingSoonPanel.SetActive (false);
			SettingsPanel.SetActive (false);
			MenuBtnPanel.SetActive (true);
		}

		else if (btn.gameObject.name == "ApplyBtn") {
			PlayerPrefs.Save();
		}
	}
}
