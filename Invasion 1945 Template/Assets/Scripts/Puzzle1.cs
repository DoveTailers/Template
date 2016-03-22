using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Puzzle1 : MonoBehaviour {

	public Text timerText;
	public float level2Timer = 30.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (TestAxis.level2) {
			
			level2Timer -= Time.deltaTime; 
			timerText.text = "Stay alive for: " + Mathf.Round(level2Timer).ToString();
			if (level2Timer < 0.0f) {
				UIControl.Instance.AddScore (2000);
				GameController.Instance.SaveGameState ();
				GameController.Instance.puzzle1Checkpoint = false;

				GameController.Instance.SaveGameState ();
				SceneManager.LoadScene ("Wave2");
			}
		}
	}

}
