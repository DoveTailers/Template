using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

	public static bool reverse = false;
	public static bool collision = false;
	public GameObject Explosion;


	// Use this for initialization
	void Start () {
		reverse = false;
		collision = false;
	}
	

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Coin")) {
			Destroy (collider.gameObject);
			reverse = true;
		}

	}

	void OnCollisionEnter(Collision collider) {
		if (!(collider.gameObject.CompareTag ("Maze")) ) {
			Instantiate(Explosion, this.gameObject.transform.position, Quaternion.identity);
			collision = true;
		}
	}

	void resetValues() {
		
	}
}
