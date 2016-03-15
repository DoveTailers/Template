using UnityEngine;
using System.Collections;

public class SpawnAsteroids : MonoBehaviour {
	public Vector3 spawnValues;
	public float hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject[] Stone3 = new GameObject[4];

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			if(TestAxis.blackHoleCount < 8) {
				Debug.Log ("doubled flying astroids: " + hazardCount);
				hazardCount *= 1.5f;
			}
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-9.0f, 9.0f), 24.0f, 0.0f);
				Quaternion spawnRotation = Quaternion.identity;
				GameObject asteroid = (GameObject) Instantiate (Stone3[Random.Range(0, 4)], new Vector3 (Random.Range(-9.0f, 9.0f), Camera.main.transform.position.y + (Camera.main.orthographicSize) + 5f , 0.0f), Quaternion.identity);
				Rigidbody rb = asteroid.GetComponent<Rigidbody> ();
				rb.velocity = Random.insideUnitSphere * 10.0f;
				
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
