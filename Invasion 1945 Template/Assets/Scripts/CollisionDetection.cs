using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

	public static bool puzzle1Complete = false;
	
	public static bool collision = false;
	public GameObject Explosion;
	public Canvas moveUpText;

	// Use this for initialization
	void Start () {
		puzzle1Complete = false;
		collision = false;
	}
	

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Coin")) {
			Destroy (collider.gameObject);
			puzzle1Complete = true;
			TestAxis.betweenLevels = true;
			Instantiate (moveUpText);
		}

	}

	void OnCollisionEnter(Collision collider) {
		if (!(collider.gameObject.CompareTag ("Maze")) ) {
			Instantiate(Explosion, this.gameObject.transform.position, Quaternion.identity);
			collision = true;
		}
		GameController.Instance.puzzle1NumOfDeaths++;
	}
}
