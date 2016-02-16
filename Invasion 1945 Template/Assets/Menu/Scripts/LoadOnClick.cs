using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	//public GameObject loadingImage;

	public void LoadScene(string level)
	{
		//loadingImage.SetActive(true);
		SceneManager.LoadScene(level);
	}

	public void QuitGame (){
		Application.Quit ();
	}
}