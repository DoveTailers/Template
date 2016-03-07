using UnityEngine;
using System.Collections;

public class EnemySpawnerX : MonoBehaviour {

	public GameObject EnemyShip;
	public float maxSpawnRateSecs = 5f;
	// Use this for initialization
	void Start () {
		Invoke ("SpawnEnemy", maxSpawnRateSecs);

		InvokeRepeating ("IncreaseSpwanRate", 0f, 30f);
		//increase spawn rate every 30 seconds
	}

	// Update is called once per frame
	void Update () {

	}

	void SpawnEnemy() {

		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (.3f, .2f));
		// bottom left corner of the screen

		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (.6f, 1));
		// top right point

		GameObject anEnemy = (GameObject)Instantiate (EnemyShip);
		anEnemy.transform.position = new Vector2 (max.x, Random.Range(min.y, max.y));

		ScheduleNextEnemySpawn();
		// Schedule when to spawn next enemy
	}

	void ScheduleNextEnemySpawn() {
		float spawnInSeconds;
		if (maxSpawnRateSecs > 1f) {
			spawnInSeconds = Random.Range (1f, maxSpawnRateSecs);
			// pick a number from 1f to maxSpawnRateSecs
		} else {
			spawnInSeconds = 1f;
		}
		Invoke ("SpawnEnemy", spawnInSeconds);
	}

	void IncreaseSpwanRate() {
		if (maxSpawnRateSecs > 1f)
			maxSpawnRateSecs--;

		if (maxSpawnRateSecs == 1f)
			CancelInvoke ("IncreaseSpwanRate");
	}
}
