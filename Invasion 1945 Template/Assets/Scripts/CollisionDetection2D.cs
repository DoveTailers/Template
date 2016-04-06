using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionDetection2D : MonoBehaviour {

	public static bool reverse = false;
	public static bool collision = false;
	public GameObject Explosion;

	private string thisScene;


	// Use this for initialization
	void Start () {
		
		reverse = false;
		collision = false;

		thisScene = SceneManager.GetActiveScene ().name;
		//print ("Collision detection thisScene: " + thisScene);
	}


	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag ("Coin")) {
			Destroy (collider.gameObject);
			reverse = true;
		}

	}

	void OnCollisionEnter2D(Collision2D collider) {
		if (!collider.gameObject.CompareTag ("Maze") && !(thisScene == "Boss")) {
			Instantiate(Explosion, this.gameObject.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
			collision = true;
		}
	}

	void resetValues() {

	}
}
