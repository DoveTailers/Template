using UnityEngine;
using System.Collections;

public class BulletMovement3D : MonoBehaviour {
	public float speed;
	public GameObject Explosion;
	// Use this for initialization
	void Start () {
		Rigidbody rb;
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.velocity = transform.up.normalized*speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collider) {
		Destroy (this.gameObject);
	}
}
