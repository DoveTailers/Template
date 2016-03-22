using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController_Wave2 : MonoBehaviour {

	public Vector2 spawnValues;
	public Vector2 spawnValues2;
	public Vector2 spawnValues3;
	public float waveWait1, waveWait2, waveWait3;
	private GameObject EnemySpawnObject;
	public float StartWaitTime;
	public float StopWaitTime;
	//added by artem
	public float NextWaitTime;
	public float WaveWait4;
	public float WaveWait5;
	public GameObject hazard2;
	public GameObject hazard1;

	void Start () {


		EnemySpawnObject = gameObject.FindObject ("EnemySpawnerOb");
		StartCoroutine (SpawnRandomToggle(StartWaitTime));
		StartCoroutine (SpawnRandomToggle(StopWaitTime));

		StartCoroutine (SpawnWaves (spawnValues3, waveWait1, hazard1));
		StartCoroutine (SpawnWaves (spawnValues2, waveWait1, hazard1));
		StartCoroutine (SpawnWaves (spawnValues, waveWait1, hazard1));

		StartCoroutine (SpawnWaves (spawnValues2, waveWait2, hazard1));
		//StartCoroutine (SpawnWaves (spawnValues, waveWait2, hazard2));

		StartCoroutine (SpawnWaves (spawnValues3, WaveWait4, hazard1));

		StartCoroutine (SpawnWaves (spawnValues2, waveWait3, hazard2));
		StartCoroutine (SpawnWaves (spawnValues, waveWait3, hazard1));

		StartCoroutine (SpawnWaves (spawnValues3, WaveWait5, hazard1));


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
			UIControl.Instance.AddScore (3000);
			GameController.Instance.SaveGameState ();
			SceneManager.LoadScene ("Boss");
			//float fadeTime = GameObject.Find ("GameController").GetComponent<Fading> ().BeginFade (1);
			//yield return new WaitForSeconds (fadeTime);
			//			GameController.Instance.SaveGameState ();
		}
	}
}
