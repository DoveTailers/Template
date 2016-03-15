using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

	private Text scoreText;

	void Start(){
		try{
			scoreText = GameObject.Find ("ScoreText").gameObject.GetComponent<Text>();
			if (PlayerPrefs.HasKey ("AllScores")){
				scoreText.text = PlayerPrefs.GetString("AllScores");
			}
		}catch{
			print ("could not get highscore text field");
		}

	}
}
