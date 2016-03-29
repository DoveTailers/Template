using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinTransition : MonoBehaviour {
	
	// Update is called once per frame
	void OnDestroy () {
		UIControl.Instance.AddScore (5000);
		SceneManager.LoadScene ("WinGame");
	}
}
