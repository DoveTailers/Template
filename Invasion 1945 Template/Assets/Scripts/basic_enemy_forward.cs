using UnityEngine;
using System.Collections;

public class basic_enemy_forward : MonoBehaviour {
	public float speed;

	void Start () {
		Rigidbody2D rb;
		rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = transform.up.normalized*-speed;
	}
}
