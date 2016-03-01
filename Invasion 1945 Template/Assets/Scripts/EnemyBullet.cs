using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
	float speed;
	Vector2 _direction; // direction of bullet
	bool isReady; // to know when bullet direction is set

	void Awake() {
		speed = 5f;
		isReady = false;
	}

	// Use this for initialization
	void Start () {
	
	}

	// Used to set bullet's direction
	public void SetDirection(Vector2 direction){
		_direction = direction.normalized;
		// set the direction normalized, to get a unit vecto

		isReady = true;
	}

	// Update is called once per frame
	void Update () {
		if (isReady) {
			Vector2 position = transform.position;
			// get bullet's current position
			 
			position += _direction * speed * Time.deltaTime;
			// compute bullet's new position

			transform.position = position;
			// update bullet position

			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
			//remove bullet if it goes outside screen

			if ((transform.position.x < min.x) || (transform.position.x > max.x) || 
				(transform.position.y < min.y) || (transform.position.y > max.y)) {
					Destroy(gameObject);
				}
 		}
	}
}
