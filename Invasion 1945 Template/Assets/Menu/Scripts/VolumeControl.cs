using UnityEngine;
using System.Collections;

public class VolumeControl : MonoBehaviour {

	void Awake (){
			// update Mute status
		if (this.name == "MuteToggle") {
			if (GamePreferences.GetMusicState () == 0) {
				this.GetComponent<UnityEngine.UI.Toggle> ().isOn = false;
			}
		} else if (this.name == "VolumeSlider") {
			// update volume bar
			this.GetComponent <UnityEngine.UI.Slider> ().value = GamePreferences.GetVolumeState () * 100.0f;
		}
	}

	//toggle mute by calling musiccontroller functions
	public void toggleMute (bool playmusic){
		bool currState = MusicController.Instance.isMusicOn;

		if (playmusic && !currState) {
			
			MusicController.Instance.MuteSong (playmusic);

		} else if (!playmusic && currState) {
			
			MusicController.Instance.MuteSong (playmusic);

		}
	}

	// set volume through MusicController, adjust UI value
	public void SetVolume (){
		float newVolume = this.GetComponent <UnityEngine.UI.Slider> ().value;
		this.GetComponentInChildren <UnityEngine.UI.Text>().text = newVolume.ToString();
		MusicController.Instance.SetVolume ((newVolume/100.0f));
	}
}