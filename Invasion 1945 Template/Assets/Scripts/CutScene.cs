using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour {

	void Start()
	{
		
		StartCoroutine(Wait(26.0f));
	}

	private IEnumerator Wait(float duration)
	{
		yield return new WaitForSeconds(duration);
		SceneManager.LoadScene ("Puzzle_2");
	}
}
