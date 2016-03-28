using UnityEngine;
using System.Collections;

public class PlayerWeaponLazer : MonoBehaviour {
	public Vector3 target;
	public Vector3 direction;
	private Rigidbody2D rb;
	public float speed = 2.0f;
	public float lazerTime = 1.0f;
	private GameObject shotSpawn;
	private Transform test;
	private Transform bulSpot;
	// Use this for initialization
	void Start () {
		//rb = gameObject.GetComponent<Rigidbody2D> ();
		//rb.velocity = transform.up.normalized*speed;
		shotSpawn = GameObject.Find ("Player");
	}
	void Update() {
		if (shotSpawn != null) {
			test = shotSpawn.GetComponent<Transform> ();
			lazerTime -= Time.deltaTime;
			bulSpot = gameObject.GetComponent<Transform> ();
			bulSpot.position = new Vector3 (test.position.x, test.position.y + 2.1f, test.position.z);
		}
		if (lazerTime < 0.0f) {
			Destroy (gameObject);
		}
	}
}
