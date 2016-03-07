using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	private int currStage;
	private int currLevel;

	public void newGame (){
		PlayerPrefs.SetInt ("PlayerScore", 0);
		PlayerPrefs.SetFloat ("PlayerHealth", 100f);
		PlayerPrefs.SetInt ("NumLives", 3);
		PlayerPrefs.SetInt ("SelectedWeapon", 0);

		PlayerPrefs.SetString ("Gun2", "20");
		PlayerPrefs.SetString ("Gun3", "10");
		PlayerPrefs.SetString ("Gun4", "5");
		PlayerPrefs.SetString ("Gun5", "2");
	}
}
