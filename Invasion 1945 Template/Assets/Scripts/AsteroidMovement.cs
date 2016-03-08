using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

	private GameObject[] OuterAsteroids;
	private GameObject[] InnerAsteroids;


	// Use this for initialization
	void Start () {
		OuterAsteroids = GameObject.FindGameObjectsWithTag ("OuterAsteroids");
		foreach (GameObject asteroid in OuterAsteroids) {
			Rigidbody rb = asteroid.GetComponent<Rigidbody> ();
			rb.angularVelocity = Random.insideUnitSphere * 2.0f;
		}

		InnerAsteroids = GameObject.FindGameObjectsWithTag ("InnerAsteroids");
		foreach (GameObject asteroid in InnerAsteroids) {
			Rigidbody rb = asteroid.GetComponent<Rigidbody> ();
			rb.angularVelocity = Random.insideUnitSphere * 2.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject asteroid in OuterAsteroids) {
			if (asteroid != null) {
				asteroid.transform.RotateAround (Vector3.zero, new Vector3(0, 0, 1), Time.deltaTime * 1.1f);
			}
		}

		foreach (GameObject asteroid in InnerAsteroids) {
			if (asteroid != null) {
				asteroid.transform.RotateAround (Vector3.zero, new Vector3(0, 0, 1), Time.deltaTime * 1.9f);
			}

		}
	}
}
