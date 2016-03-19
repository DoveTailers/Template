using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	private Text scoreDisplay;
	private string currScore;

	// Use this for initialization
	void Start () {
		scoreDisplay = GameObject.FindGameObjectWithTag ("GameOverScore").gameObject.GetComponent<Text> ();
		try {
			currScore = UIControl.Instance.GetScore ();
		} catch {
			print ("Game Over could not fetch score");
			currScore = "0";
		}
		scoreDisplay.text = "Score: " + currScore;
	}
}
