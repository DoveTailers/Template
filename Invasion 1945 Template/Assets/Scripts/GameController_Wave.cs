using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameController_Wave : MonoBehaviour {

	public GameObject hazard1;
	public GameObject hazard2;
	public Vector2 spawnValues;
	public Vector2 spawnValues2;
	public Vector2 spawnValues3;
	public float waveWait1, waveWait2, waveWait3;
	private GameObject EnemySpawnObject;
	public float StartWaitTime;
	public float StopWaitTime;
    public float NextWaitTime;
	void Start () {


		EnemySpawnObject = gameObject.FindObject ("EnemySpawnerOb");
		StartCoroutine (SpawnWaves (spawnValues, waveWait1, hazard1));
		StartCoroutine (SpawnWaves (spawnValues2, waveWait2, hazard1));
		StartCoroutine (SpawnRandomToggle(StartWaitTime));
		StartCoroutine (SpawnRandomToggle(StopWaitTime));
		StartCoroutine (SpawnWaves (spawnValues3, waveWait3, hazard2));
        StartCoroutine (Next(NextWaitTime));
	}

	IEnumerator SpawnWaves (Vector2 sv, float wWait, GameObject ha) {
		yield return new WaitForSeconds (wWait);
		Vector2 spawnPosition = new Vector2 (sv.x, sv.y);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (ha, spawnPosition, spawnRotation);
	}

	IEnumerator SpawnRandomToggle(float waittime){
		yield return new WaitForSeconds(waittime);
		if (EnemySpawnObject != null) {
			EnemySpawnObject.SetActive (!EnemySpawnObject.activeInHierarchy);
		}

	}

    IEnumerator Next(float waittime) {
		yield return new WaitForSeconds (waittime);
		if (!GameController.Instance.IsPlayerDead ()) {
			print ("moving to next wave");
			UIControl.Instance.AddScore (1500);
			float fadeTime = GameObject.Find ("GameController").GetComponent<Fading> ().BeginFade (1);
			yield return new WaitForSeconds (fadeTime);
//			GameController.Instance.SaveGameState ();
			GameController.Instance.SaveGameState ();
			SceneManager.LoadScene ("Transition1");
		}
	}
}
