using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Bullet_DestoryByContact : MonoBehaviour {

	private float enemyBulletDamage = -10f;

	public GameObject explosion;

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Boundary") {
			return;
		}
		if (other.tag == "Player") {
			print ("enemy hit player with damage: " + enemyBulletDamage.ToString ());
			Destroy(gameObject);
			if (UIControl.Instance.PlayerIsDead (enemyBulletDamage)) {
				print ("player has died from bulllet damage");

				GameController.Instance.PlayerDied ();
				Instantiate (explosion, other.transform.position, other.transform.rotation);
				Destroy(other.gameObject);
			}

		}

		
	}
}