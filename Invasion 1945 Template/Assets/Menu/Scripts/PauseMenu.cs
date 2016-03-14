using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;

	private GameObject pauseMenuCanvas;
	private Scene thisScene;
	private float timeleft;

	void Awake (){
		// initiate variables
		pauseMenuCanvas = GameObject.Find ("PauseCanvas");
		thisScene = SceneManager.GetActiveScene ();
		isPaused = false;
		pauseMenuCanvas.SetActive (false);
		timeleft = 0;
	}

	// Update is called once per frame
	void Update () 
	{
		// pause the game
		if (Input.GetButtonDown ("Escape")) 
		{
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

	public void Continue ()
	{
		isPaused = false;

	}

	public void Restart ()
	{
		SceneManager.LoadScene (thisScene.name);
	}

	public void Confirm(){

	}

	public void Quit ()
	{
		SceneManager.LoadScene ("mainmenub");
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
