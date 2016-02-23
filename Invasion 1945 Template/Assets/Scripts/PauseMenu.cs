using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;

	public GameObject pauseMenuCanvas;

	// Update is called once per frame
	void Update () 
	{
		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
		} else {
			pauseMenuCanvas.SetActive (false);
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
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void Quit ()
	{
		Application.LoadLevel ("mainmenub");
	}
}
