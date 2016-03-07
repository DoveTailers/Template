using UnityEngine;
using System.Collections;

public class EnemySwerve : MonoBehaviour {
	public Sprite right;
	public Sprite left;
	private Vector3 stageDimensions;
	private float speed1;
	private SpriteRenderer sr;
	private float speed;
	void Start () {
		//Rigidbody2D rb;
		stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
		speed = Random.Range (1.5f, 10f);
		speed1 = speed;
		sr = GetComponent<SpriteRenderer>();
		int spawnDir = Random.Range (0, 2);
		if (spawnDir == 1)
			speed = -speed;
		if (speed > 0) {
			sr.sprite = right;
		} else {
			sr.sprite = left;
		}
		//rb.velocity = transform.up.normalized*-speed;
	}

	void Update() {
		//rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
		if (transform.position.x + .5 > stageDimensions.x) {
			sr.sprite = left;
			speed = -speed;
		} else if (transform.position.x - .5 < -stageDimensions.x) {
			sr.sprite = right;
			speed = -speed;
		}
		transform.Translate(speed * Time.deltaTime , -1 * speed1 * Time.deltaTime, 0);
		//transform.Translate(-speed * Time.deltaTime , -1 * speed * Time.deltaTime, 0);
	}
}
