using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;

	private GameObject pauseMenuCanvas;
	private GameObject dialogBox;
	private GameObject pauseDisplay;
	private Scene thisScene;
	private float timeleft;

	private string dialogStatus;

	void Awake (){
		// initiate variables
		pauseMenuCanvas = GameObject.Find ("PauseCanvas");
		pauseDisplay = GameObject.Find ("ActivePauseScreen");
		dialogBox = GameObject.Find ("DialogBox");
		thisScene = SceneManager.GetActiveScene ();
		isPaused = false;
		dialogBox.SetActive (false);
		pauseMenuCanvas.SetActive (false);

		timeleft = 0;
		// confirm box values
		dialogStatus = "";
	}

	// Update is called once per frame
	void Update () 
	{
		// pause the game
		if (Input.GetButtonDown ("Escape")) 
		{
			if (isPaused) {
				dialogStatus = "";
				TogglePause (true);
			}
			isPaused = !isPaused;
		}
		if (isPaused) {
		// freeze the game, activate pause menu
			Time.timeScale = 0.00000001f;
			pauseMenuCanvas.SetActive (true);
		} 
		else {
		// unpause and unfreeze adding countdown timer
			Time.timeScale = 1f;
			pauseMenuCanvas.SetActive (false);
		}
	}

	// do the countdown
//	private IEnumerator CountDown(){
//		print ("at enum");
//		int displayNum = 3;
//		timeleft = 3f * Time.timeScale;
//		pauseMenuCanvas.SetActive (false);
//
//		while (timeleft > 0) {
//			UIControl.Instance.DisplayCount (displayNum);
//			yield return new WaitForSeconds (Time.timeScale);
//			timeleft -= Time.timeScale;
//			displayNum--;
//		}
//		UIControl.Instance.DisplayCount (0);
//		Time.timeScale = 1f;
//	}

	private void TogglePause (bool pauseOn){
		dialogBox.SetActive (!pauseOn);
		pauseDisplay.SetActive (pauseOn);
		if (pauseOn) {
			dialogStatus = "";
			GameObject.Find ("Continue").GetComponent<UnityEngine.UI.Button> ().Select ();
		} else {
			GameObject.Find ("ConfirmText").GetComponent<UnityEngine.UI.Text>().text = "are you sure you want to "+dialogStatus+"?";
			GameObject.Find ("Confirm").GetComponent<UnityEngine.UI.Button> ().Select ();
		}
	}

	public void Continue ()
	{
		isPaused = false;

	}

	public void Restart (){
		dialogStatus = "restart";
		TogglePause (false);
	}

	public void Quit () {
		dialogStatus = "quit";
		TogglePause (false);
	}

	public void Cancel(){
		dialogStatus = "";
		TogglePause (true);
	}

	public void HandleDialog (){
		if (dialogStatus == "restart") {
			
			print ("restarting");
			SceneManager.LoadScene (thisScene.name);

		} else if (dialogStatus == "quit") {
			print ("quitting");
			SceneManager.LoadScene ("mainmenub");
		} else {
			dialogStatus = "";
			TogglePause (true);
		}
	}
		

	public void Save (){
		// save needed variables to PlayerPrefs
		print ("nothing here yet");
	}

	public void Load (){
		// loaded needed PlayerPrefs
		print ("nothing here yet");
	}
}
