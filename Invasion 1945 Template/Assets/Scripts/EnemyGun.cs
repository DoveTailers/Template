using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {

	public GameObject EnemyBullet;
	public GameObject EnemyShoot;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("FireEnemyBullet", 1f, 3f);

		// Fire enemy bullet after 1 second
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Used to fire an enemy bullet
	void FireEnemyBullet() {
		GameObject playerShip = GameObject.Find ("Player");
		// Get a refernce to the player's ship
		GameObject enemyShip = GameObject.Find ("EnemyShip_1");
		if(playerShip != null) {
			// play not dead

			GameObject bullet = (GameObject)Instantiate(EnemyBullet);
			GameObject shoot = (GameObject)Instantiate(EnemyShoot);
			// Instantiate bullet

			bullet.transform.position = transform.position;
			// set the bullet's initial position

			shoot.transform.position = transform.position;

			Vector2 direction = playerShip.transform.position - bullet.transform.position;
			// computer bullet's direction towards player's ship

			bullet.GetComponent<EnemyBullet> ().SetDirection (direction);
			// set bullet's direction
		}
	}
}
