using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
	//could make array for level songs, menu song, game over song, transition song and check which to play


	// the current song
	public AudioSource currSong;

	// temp for now to turn off
	// keep an eye and see if i actually use this. so far only for testing
	public bool isMusicOn;

	private static MusicController instance = null;

	public static MusicController Instance {
    	get { return instance; }
 	}

 	void Awake() {
     	if (instance != null && instance != this) {
        	Destroy(this.gameObject);
        	return;
     	} else {
        	instance = this;
     	}
		DontDestroyOnLoad(this.gameObject);
 	}

	// **********  might not need this in final build   *******
	void Update (){
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			isMusicOn = !isMusicOn;
			PlayMusic (isMusicOn);
		}
	}
	// ---------------------------------------------------------

	// toggle playing music on and off
	public void PlayMusic (bool play){
		if (play) {
			if (!currSong.isPlaying) {
				currSong.Play ();
			}
		} else {
			if (currSong.isPlaying) {
				currSong.Stop ();
			}
		}
	}

	public void ToggleMusic (){
		isMusicOn = !isMusicOn;
		PlayMusic (isMusicOn);
	}
}
