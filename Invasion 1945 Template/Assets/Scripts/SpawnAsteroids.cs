using UnityEngine;
using System.Collections;

public class SpawnAsteroids : MonoBehaviour {
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject Stone3;

	// Use this for initialization
	void Start () {
//		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
//	IEnumerator SpawnWaves ()
//	{
//		yield return new WaitForSeconds (startWait);
//		while (true)
//		{
//			for (int i = 0; i < hazardCount; i++)
//			{
//				Vector3 spawnPosition = new Vector3 (Random.Range (-9.0f, 9.0f), 24.0f, 0.0f);
//				Quaternion spawnRotation = Quaternion.identity;
//				Instantiate (Stone3, spawnPosition, spawnRotation);
//				
//			}
//			yield return new WaitForSeconds (waveWait);
//		}
//	}
}
