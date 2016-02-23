using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

	protected static bool reverse = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collider) {
		if (!collider.gameObject.CompareTag ("Maze")) {
			resetValues ();
			Application.LoadLevel (Application.loadedLevel);
		}

    }

	void OnTriggerEnter2D(Collider2D collider) {
		Destroy (collider.gameObject);
		reverse = true;
	}

	void resetValues() {
		reverse = false;
	}
}
