using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	//public GameObject loadingImage;

	public void TryLastlevel (){
		SceneManager.LoadScene (GameController.Instance.GetLastLevelName ());
	}

	public void LoadScene(string level)
	{
		//loadingImage.SetActive(true);
		SceneManager.LoadScene(level);
	}

	public void QuitGame (){
		Application.Quit ();
	}

	public void ContinueOnClick (){
		GameController.Instance.Continue ();
	}

	public void SaveScoreQuit (string name){
		UIControl.Instance.SaveToScores ();
		PlayerPrefs.SetInt (GameController.Instance.highscore, 0);
		LoadScene (name);
	}
}