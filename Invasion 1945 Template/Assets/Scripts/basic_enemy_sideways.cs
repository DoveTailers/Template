using UnityEngine;
using System.Collections;

public class basic_enemy_sideways : MonoBehaviour {
	public float speed;

	void Start () {
		Rigidbody2D rb;
		rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (speed, 0f);
	}
}