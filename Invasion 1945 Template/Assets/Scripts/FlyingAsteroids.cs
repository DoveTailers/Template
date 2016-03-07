using UnityEngine;
using System.Collections;

public class FlyingAsteroids : MonoBehaviour {
	public GameObject Explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			CollisionDetection.collision = true;
			Instantiate(Explosion, this.gameObject.transform.position, Quaternion.identity);
		}
	}
}
