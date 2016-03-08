using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

	private Text scoreText;

	void Start(){
		try{
			scoreText = GameObject.Find ("ScoreText").gameObject.GetComponent<Text>();
			if (PlayerPrefs.HasKey ("PlayerScore")){
				scoreText.text = PlayerPrefs.GetInt("PlayerScore").ToString();
			}
		}catch{
			print ("could not get highscore text field");
		}

	}
}
