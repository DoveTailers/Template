using UnityEngine;
using System.Collections;

public class PlayerWeaponLazer : MonoBehaviour {
	public Vector3 target;
	public Vector3 direction;
	private Rigidbody2D rb;
	public float speed = 2.0f;
	public float lazerTime = 1.0f;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = transform.up.normalized*speed;
	}
	void Update() {
		lazerTime -= Time.deltaTime;
		Debug.Log (lazerTime);
		if (lazerTime < 0.0f) {
			Destroy (gameObject);
		}
	}
}
