using UnityEngine;
using System.Collections;

public class GameController_Wave2 : MonoBehaviour {

	public Vector2 spawnValues;
	public Vector2 spawnValues2;
	public Vector2 spawnValues3;
	public float waveWait1, waveWait2, waveWait3;
	private GameObject EnemySpawnObject;
	public float StartWaitTime;
	public float StopWaitTime;

	void Start () {


		EnemySpawnObject = gameObject.FindObject ("EnemySpawnerOb");
		StartCoroutine (SpawnRandomToggle(StartWaitTime));
		StartCoroutine (SpawnRandomToggle(StopWaitTime));
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
}
