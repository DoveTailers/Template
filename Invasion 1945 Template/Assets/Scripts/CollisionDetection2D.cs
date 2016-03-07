using UnityEngine;
using System.Collections;

public class CollisionDetection2D : MonoBehaviour {

	public static bool reverse = false;
	public static bool collision = false;
	public GameObject Explosion;


	// Use this for initialization
	void Start () {
		reverse = false;
		collision = false;
	}


	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag ("Coin")) {
			Destroy (collider.gameObject);
			reverse = true;
		}

	}

	void OnCollisionEnter2D(Collision2D collider) {
		if (!(collider.gameObject.CompareTag ("Maze")) ) {
			Instantiate(Explosion, this.gameObject.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
			collision = true;
		}
	}

	void resetValues() {

	}
}
