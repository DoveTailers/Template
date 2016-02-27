using UnityEngine;
using System.Collections;

public class GameController_Wave : MonoBehaviour {

	public GameObject hazard;
	public Vector2 spawnValues;
	public Vector2 spawnValues2;
	public float waveWait1, waveWait2;

	void Start () {
		StartCoroutine (SpawnWaves (spawnValues, waveWait1));
		StartCoroutine (SpawnWaves (spawnValues2, waveWait2));
	}

	IEnumerator SpawnWaves (Vector2 sv, float wWait) {
		yield return new WaitForSeconds (wWait);
		Vector2 spawnPosition = new Vector2 (sv.x, sv.y);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazard, spawnPosition, spawnRotation);
	}

}
