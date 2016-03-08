using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	private Scene currScene;
	public string sceneType;
	private Scene reachedLevel;
	private string level1 = "main_test";

	private static GameController instance = null;

	public static GameController Instance {
		get { return instance; }
	}

	void Awake() {
		//preserve the old instance if one already exists
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}

		if (PlayerPrefs.HasKey ("ReachedLevel")) { 
			SceneManager.GetSceneByName (PlayerPrefs.GetString ("ReachedLevel"));
		} else {
			PlayerPrefs.SetString ("ReachedLevel", level1);
		}

		newGame ();

		DontDestroyOnLoad(this.gameObject);
	}

	void OnLevelWasLoaded (int level){
		// <6 is menu scenes
		// 6 main
		// 7 puzzle_1
		// 8 puzzle_2
		// 9 main_test
		// 10 wave2

		if (level < 6) {
			print ("Menu Scene");
		} else if (level == 9) {
			print ("Wave1");
		} else if (level == 8) {
			print ("Puzzle 2");
		} else if (level == 10) {
			print ("wave2");
		}
	}

	public void newGame (){
		PlayerPrefs.SetInt ("PlayerScore", 0);
		PlayerPrefs.SetFloat ("PlayerHealth", 100f);
		PlayerPrefs.SetInt ("NumLives", 3);
		PlayerPrefs.SetInt ("SelectedWeapon", 0);

		PlayerPrefs.SetString ("Gun2", "20");
		PlayerPrefs.SetString ("Gun3", "10");
		PlayerPrefs.SetString ("Gun4", "5");
		PlayerPrefs.SetString ("Gun5", "2");
	}
}
