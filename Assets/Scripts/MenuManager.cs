using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public GameObject btn;
	public GameObject LogoPanel;
	public GameObject MenuBtnPanel;
	public GameObject ConfirmPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeMenu (GameObject btn) {
		if (btn.gameObject.name == "PlayBtn") {
			Debug.Log ("PlayBtn pressed");
			Application.LoadLevel ("Main");
		} 

		else if (btn.gameObject.name == "HighscoreBtn") {
			Debug.Log ("HighscoreBtn pressed");
		} 

		else if (btn.gameObject.name == "SettingsBtn") {
			Debug.Log ("SettingsBtn pressed");
		} 

		else if (btn.gameObject.name == "ExitBtn") {
			Debug.Log ("Exit Btn pressed");
			MenuBtnPanel.SetActive(false);
			ConfirmPanel.SetActive(true);
		} 

		else if (btn.gameObject.name == "YesBtn") {
			Debug.Log ("Exit confirmed");
			Application.Quit ();
		} 

		else if (btn.gameObject.name == "NoBtn") {
			Debug.Log ("Exit aborted");
			ConfirmPanel.SetActive(false);
			MenuBtnPanel.SetActive(true);

		}
	}
}
