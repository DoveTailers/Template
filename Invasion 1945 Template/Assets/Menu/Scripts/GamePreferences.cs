using UnityEngine;
using System.Collections;

public class GamePreferences : MonoBehaviour {

	// name of music mute / play variable for playerprefs
	public static string MusicOn = "MusicOn";
	public static string Volume = "VolumeLevel";

	void Awake (){
		// initialization
		if (!PlayerPrefs.HasKey (MusicOn)) {
			PlayerPrefs.SetInt (MusicOn, 1);
		}
		if (!PlayerPrefs.HasKey (Volume)){ 
			PlayerPrefs.SetFloat (Volume, 1.0f);
		}
	}

	public static float GetVolumeState (){
		return PlayerPrefs.GetFloat (Volume);
	}

	public static void SetVolumeState (float value){
		if (value >= 0.0 && value <= 1.0) { 
			PlayerPrefs.SetFloat (Volume, value);
		}
	}
		
	public static int GetMusicState (){
		return PlayerPrefs.GetInt (MusicOn);
	}

	public static void SetMusicState (int state){
		PlayerPrefs.SetInt (MusicOn, state);
	}
}
