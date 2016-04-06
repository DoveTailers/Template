using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public string sceneType;

	private Scene currScene;
	private Scene reachedLevel;

	private bool playerDead;

	// all save game key values, UIControl.cs and this script use these values for PlayerPrefs
	public string allScores = "AllScores";
	public string highscore = "PlayerScore";
	public string health = "PlayerHealth";
	public string gun2 = "Gun2";
	public string gun3 = "Gun3";
	public string levelReached = "LevelReached";
	public string checkpointKey = "Checkpoint";
	public bool puzzle1Checkpoint = false;
	public int puzzle1NumOfDeaths = 0;

	// holds the actual scene names of scene and checkpoint
	public string lastLevelName;
	public string checkpoint;

	// names of levels
	private string level1 = "main_test";
	//private string puzzle1 = "puzzle_2";
	//private string level2 = "wave2";

	public bool isCreditsLoaded = false;

	// all scripts with variables

	private static GameController instance = null;

	public static GameController Instance {
		get { return instance; }
	}

	void Awake() {
		if (cutSceneFromJS.pictures.Count == 0) {
			Object[] textures = Resources.LoadAll("jpegs");
			for(var i = 0; i < textures.Length; i++){
				//Debug.Log("found");
				cutSceneFromJS.pictures.Add (textures [i]);
			}
		}
		//preserve the old instance if one already exists
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}

		lastLevelName = "";
		checkpoint = "";
		playerDead = false;

		if (!PlayerPrefs.HasKey (allScores)) {
			// made up 
			PlayerPrefs.SetString (allScores, "\n");
		}

		// initiate newGame for the first time
		if (!PlayerPrefs.HasKey (highscore)) {
			newGame ();
		}

		//UIControl.Instance.SaveToScores ();

		DontDestroyOnLoad(this.gameObject);
	}

	IEnumerator OnDeath(){
		// stuff to do when player dies
		SetLastLevelName ();
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("GameOver");
		playerDead = false;
	}

	IEnumerator Message (string m){
		Text messageBox = null;
		try{
			messageBox = GameObject.FindGameObjectWithTag("Message").GetComponent<Text>();
			messageBox.text = m;
		} catch{
			print ("Could not get messageBox!");
		}
		yield return new WaitForSeconds (5);
		if (messageBox != null) {
			messageBox.text = "";
		}
	}

	void OnLevelWasLoaded (int level){
		// <6 is menu scenes
		// 6 main
		// 7 puzzle_1
		// 8 puzzle_2
		// 9 main_test
		// 10 wave2

		playerDead = false;
		isCreditsLoaded = false;

		if (level == 12) {
			// unlucky 13, transition
			return;
		}

		// find stage song
		MusicController.Instance.SwitchSong ();
		if (level == 13) {
			isCreditsLoaded = true;
			return;
		}
		if (level == 0) {
			// print ("Intro");

		}else if (level < 8) {
			//print ("Menus");
			puzzle1NumOfDeaths = 0;
			puzzle1Checkpoint = false;

		} else {
			// remember the scene name
			SetLastLevelName ();
			// loads the settings into all levels
			UIControl.Instance.LoadGameStateUI ();

			if (level == 8) {
			
				print ("Wave1");
				// resets the settings THEN loads them
				newGame ();
				UIControl.Instance.LoadGameStateUI ();

			} else if (level == 9) {
				print ("Puzzle 2");

			} else if (level == 10) {
				print ("wave2");

		
			} else if (level == 11) {
				Debug.Log("Bossfight");
			}

		}
	}

	public void PlayerDied (){
		playerDead = true;
		StartCoroutine (OnDeath ());
	}

	public bool IsPlayerDead (){
		return playerDead;
	}

	public void newGame (){
		PlayerPrefs.SetInt (highscore, 0);
		PlayerPrefs.SetFloat (health, 100f);
		PlayerPrefs.SetString (gun2, "40");
		PlayerPrefs.SetString (gun3, "20");
		PlayerPrefs.SetString (levelReached, level1);
		PlayerPrefs.SetString (checkpointKey, checkpoint);
		//PlayerPrefs.SetString ("Gun3", "10");
		//PlayerPrefs.SetString ("Gun4", "5");
		//PlayerPrefs.SetString ("Gun5", "2");
	}

	public void ResetStats(){
		PlayerPrefs.DeleteKey (highscore);
		PlayerPrefs.DeleteKey (health);
		PlayerPrefs.DeleteKey (gun2);
		PlayerPrefs.DeleteKey (gun3);
		PlayerPrefs.DeleteKey (levelReached);
		PlayerPrefs.DeleteKey (checkpointKey);
	}

	public void SaveGameState (){
		// called savegamestate
		try {
			ResetStats ();
			SetLastLevelName ();
			UIControl.Instance.SaveGameStateUI ();
			PlayerPrefs.Save ();
		}catch{
			Debug.Log ("Could Not savegame in GameController");
		}
	}

	public void LoadGame (){
		try{
			Debug.Log ("Loading game, levelreached: " + levelReached);
			SceneManager.LoadScene (PlayerPrefs.GetString (levelReached));
			//Time.timeScale = 1f;
		}catch{
			Debug.Log ("Could Not LoadGame");
		}
	}

	public void Continue (){
		if (PlayerPrefs.HasKey (levelReached)) {
			SceneManager.LoadScene (PlayerPrefs.GetString (levelReached));
		} else {
			string m = "NO SAVED GAME AVAILABLE";
			StartCoroutine (Message (m));
		}
	}

	public void DisplayMessage (string m){
		StartCoroutine (Message (m));
	}

	public string GetLastLevelName (){
		return lastLevelName;
	}

	public void SetLastLevelName (){
		PlayerPrefs.DeleteKey (levelReached);
		lastLevelName = SceneManager.GetActiveScene ().name;
		PlayerPrefs.SetString (levelReached, lastLevelName);
	}

	public void SetCheckpoint (string s){
		PlayerPrefs.SetString (checkpointKey, s);
		checkpoint = s;
	}

	public string GetCheckpoint (){
		return checkpoint;
	}
}
