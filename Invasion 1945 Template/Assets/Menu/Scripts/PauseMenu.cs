using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;

	public GameObject pauseMenuCanvas;

	// Update is called once per frame
	void Update () 
	{
		if (isPaused) {
			Time.timeScale = 0f;
			pauseMenuCanvas.SetActive (true);
		} else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyUp (KeyCode.Escape)) 
		{
			isPaused = !isPaused;
		}
	}

	public void Continue ()
	{
		isPaused = false;
	}

	public void Restart ()
	{
		SceneManager.LoadScene (Application.loadedLevelName);
	}

	public void Quit ()
	{
		SceneManager.LoadScene ("mainmenub");
	}
}
