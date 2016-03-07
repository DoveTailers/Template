using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
	//could make array for level songs, menu song, game over song, transition song and check which to play

	// public AudioSource nextSong; -- create component and assign later
	// the current song (Audiosource)
	public AudioSource currSong;
	private GameObject musicPlayer;
	private AudioClip[] allClips;
	// for master volume contolls

	// temp for now to turn off
	// keep an eye and see if i actually use this. so far only for testing
	public bool isMusicOn;

	// create a static instance of musiccontroller
	private static MusicController instance = null;

	public static MusicController Instance {
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

		//initialize variables, currSong will need to be modified based on scene
		musicPlayer = GameObject.Find("MusicPlayer");
		currSong = musicPlayer.GetComponent <AudioSource> ();

		//preserve the instance throughout scene change
		DontDestroyOnLoad(this.gameObject);
 	}

	void Start (){
		// initialized in GamePreferences
		isMusicOn = false;
		bool play = GamePreferences.GetMusicState () == 1 ? true : false;
		PlayMusic (play);
	}

	// **********  not needed in final build   *******
	// press 0 to mute music
	void Update (){
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			isMusicOn = !isMusicOn;
			PlayMusic (isMusicOn);
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			SwitchSong ();
		}
	}
	// ---------------------------------------------------------

	// toggle playing music on and off
	public void PlayMusic (bool play){
		if (play && !isMusicOn) {
			GamePreferences.SetMusicState (1);
			isMusicOn = true;
			if (!currSong.isPlaying) {
				currSong.Play ();
			}
		} else if (!play && isMusicOn){
			GamePreferences.SetMusicState (0);
			isMusicOn = false;
			if (currSong.isPlaying) {
				currSong.Stop ();
			}
		}
	}

	public void SetVolume (float amount){
		if (amount >= 0 && amount <= 1) {
			GamePreferences.SetVolumeState (amount);
			AudioListener.volume = amount;
		}
	}

	// see if the stage has a song, if it does, make it the current song. else the stage must be the menu and play default sound
	// should be called from stage script, maybe game controller script
	public void SwitchSong() {
		try {
			if (isMusicOn){
				currSong.Stop();
				isMusicOn = false;
			}
			currSong = GameObject.FindGameObjectWithTag ("StageSong").gameObject.GetComponent <AudioSource> ();
		}catch {
			currSong = musicPlayer.GetComponent <AudioSource> ();
		}
		bool play = GamePreferences.GetMusicState() == 1 ? true : false;
		PlayMusic (play);
	}
}
