using UnityEngine;
using System.Collections;

public class LaserCollisions : MonoBehaviour {
	public GameObject explosion;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag ("Lazer") || collider.gameObject.CompareTag ("Missle") || collider.gameObject.CompareTag ("Bullet")) {
			//Debug.Log ("shot");
			Destroy (collider.gameObject);
		} 
		if (collider.gameObject.CompareTag("Player") && UIControl.Instance.PlayerIsDead (-2.0f)) {
			Debug.Log (collider.gameObject.tag);
			GameController.Instance.PlayerDied ();
		
			Instantiate (explosion, collider.transform.position, collider.transform.rotation);
			Destroy(collider.gameObject);
		}
	}
//	void OnTriggerStay2D(Collider2D collider) {
//		if (collider.gameObject.CompareTag ("Player")) {
//			if (UIControl.Instance.PlayerIsDead (-2.0f)) {
//				GameController.Instance.PlayerDied ();
//			}
//		}
//	}
}
