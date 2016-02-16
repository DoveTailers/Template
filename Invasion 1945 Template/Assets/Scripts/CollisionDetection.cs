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
		resetValues ();
        Application.LoadLevel (Application.loadedLevel);
    }

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("GOT COIN");
		Destroy (collider.gameObject);

		reverse = true;



		/*
		innerCircleRotationSpeed *= -1;
		outerCircleRotationSpeed *= -1;
		*/
	}

	void resetValues() {
		reverse = false;
	}
}
