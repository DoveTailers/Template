using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	public string sceneType;

	private Scene currScene;
	private Scene reachedLevel;
	private string level1 = "main_test";

	// all scripts with variables
	public GameController_Wave wave1;
	public GameController_Wave2 wave2;

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

		// fetch the scripts
		wave1 = GetComponent <GameController_Wave> ();
		wave2 = GetComponent <GameController_Wave2> ();

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

//		if (level == 1) {
//			print ("MainMenu");
//			PlayNoWave ();
//			MusicController.Instance.SwitchSong ();
//		}
//		if (level == 0) {
//			print ("MainMenu");
//			PlayNoWave ();
//			MusicController.Instance.SwitchSong ();
//		}
		MusicController.Instance.SwitchSong ();

//		if (level < 6) {
//			print ("Menus");
//			PlayNoWave ();
//
//		} else if (level == 9) {
//			
//			print ("Wave1");
//			PlayNoWave ();
//			wave1.enabled = true;
//			MusicController.Instance.SwitchSong ();
//
//		} else if (level == 10) {
//
//			print ("wave2");
//			PlayNoWave ();
//			wave2.enabled = true;
//			MusicController.Instance.SwitchSong ();
//
//		
//		}else if (level == 8) {
//			
//			print ("Puzzle 2");
//			PlayNoWave ();
//			MusicController.Instance.SwitchSong ();
//		} 
	}

	public void newGame (){
		PlayerPrefs.SetInt ("PlayerScore", 0);
		PlayerPrefs.SetFloat ("PlayerHealth", 100f);
		PlayerPrefs.SetInt ("NumLives", 3);
		PlayerPrefs.SetInt ("SelectedWeapon", 0);

		PlayerPrefs.SetString ("Gun2", "40");
		//PlayerPrefs.SetString ("Gun3", "10");
		//PlayerPrefs.SetString ("Gun4", "5");
		//PlayerPrefs.SetString ("Gun5", "2");
	}

//	private void PlayNoWave (){
//		print (wave1.enabled.Equals (true));
//		if (wave1.enabled == true) {
//			wave1.enabled = false;
//		}
//		if (wave2.enabled == true) {
//			wave2.enabled = false;
//		}
//	}
}
