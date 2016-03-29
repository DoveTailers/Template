using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;

	private GameObject pauseMenuCanvas;
	private GameObject dialogBox;
	private GameObject pauseDisplay;
	private Scene thisScene;
	private float timeStarted;

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
				Continue ();
			} else {
				if (!GameController.Instance.IsPlayerDead ()) {
					isPaused = true;
				}
			}
		}
		if (isPaused) {
		// freeze the game, activate pause menu
			Time.timeScale = 0f;
			pauseMenuCanvas.SetActive (true);
		} 
		else {
		// unpause and unfreeze adding countdown timer
			pauseMenuCanvas.SetActive (false);
		}
	}

	// do the countdown
	private IEnumerator CountDown(){
		//print ("at enum");
		//timeleft = 3f * Time.timeScale;
		pauseMenuCanvas.SetActive (false);

		float pauseEndTime = Time.realtimeSinceStartup + 3;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			UIControl.Instance.DisplayCount (Mathf.Ceil (pauseEndTime - Time.realtimeSinceStartup));
			yield return 0;
		}
		UIControl.Instance.DisplayCount (0f);
		Time.timeScale = 1f;
		//yield return null;
	}

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
		//print ("starting coroutine");
		StartCoroutine (CountDown());
		//print ("ending coroutine");
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
			isPaused = false;
			Time.timeScale = 1f;
			SceneManager.LoadScene (thisScene.name);

		} else if (dialogStatus == "quit") {
			isPaused = false;
			Time.timeScale = 1f;
			print ("quitting");
			PlayerPrefs.SetInt (GameController.Instance.highscore, 0);
			SceneManager.LoadScene ("mainmenub");
		} else {
			dialogStatus = "";
			TogglePause (true);
		}
	}
		

	public void Save (){
		// save needed variables to PlayerPrefs
		GameController.Instance.DisplayMessage ("SAVED!"); 
		GameController.Instance.SaveGameState();
	}

	// doesn't work. likely due to timescale, although delay load uses a coroutine that bypasses timescale, 
	// gamecontroller does not. the solution would be to set timescale to 1 before loading or to run the 
	// load game in gamecontroller as a coroutine
//	public void Load (){
//		// loaded needed PlayerPrefs
//		dialogStatus = "";
//		isPaused = false;
//		GameController.Instance.DisplayMessage ("LOADING...");
//		delayLoad ();
//	}

	IEnumerator delayLoad (){
		yield return new WaitForSeconds (4);
		GameController.Instance.LoadGame();
	}
}
