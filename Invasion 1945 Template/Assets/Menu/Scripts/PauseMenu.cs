using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;

	private GameObject pauseMenuCanvas;
	private Scene thisScene;

	void Awake (){
		// initiate variables
		pauseMenuCanvas = GameObject.Find ("PauseCanvas");
		thisScene = SceneManager.GetActiveScene ();
		isPaused = false;
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
			Time.timeScale = 0f;
			pauseMenuCanvas.SetActive (true);
		} else {
		// unpause and unfreeze
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}
	}

	public void Continue ()
	{
		isPaused = false;
	}

	public void Restart ()
	{
		SceneManager.LoadScene (thisScene.name);
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
