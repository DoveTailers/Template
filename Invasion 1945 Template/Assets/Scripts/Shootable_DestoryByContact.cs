using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shootable_DestoryByContact : MonoBehaviour {

	private UIControl uiScript;
	private EnemyHealth eHealthScript;

	// adjust to change weapon / collision damage and points
	private float bulletDamage = -4f;
	private int bulletScore = 4;
	private float missleDamage = -10f;
	private int missleScore = 10;
	private float lazerDamage = -0.8f;
	private int lazerScore = 1;
	private float collisionDamage = -50f;
	private int suicideScore;
	private bool destProj = true;
	public GameObject explosion;

	void OnTriggerStay2D (Collider2D other) {
		float currHit = 0f;
		int currScore = 0;
		if (other.tag == "Lazer") {
			currHit = lazerDamage;
			currScore = lazerScore;
			try {
				eHealthScript = gameObject.GetComponentInChildren <EnemyHealth> ();
				UIControl.Instance.AddScore (currScore);
				if (eHealthScript.EnemyIsDead (currHit)) {
					if (gameObject.name == "core"){
						// boss died
						UIControl.Instance.AddScore (5000);
						// for now its game over
						SceneManager.LoadScene("WinGame");
					}
					Instantiate (explosion, transform.position, transform.rotation);
					Destroy (gameObject);
				}
			} catch {
				print ("could not get " + gameObject.ToString () + " Script!");
				print ("script: " + eHealthScript.ToString());
			}
		} else {
			return;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// added shootable tag to EnemyBullet_1 because I think another script takes care of it.
		// feel free to correct me
		if (other.tag == "Boundary" || other.tag == "Shootable" || other.tag == "enemy_bullet" || other.tag == "EnemyLaser") {
			return;
		}
		if (other.tag == "Player") {
			//check if boss wall and return
			if (this.tag == "boss01_left_rocket" || this.tag == "boss01_shield" || this.tag == "boss01_right_rocket") {
				return;
			} else {
				// player on ship collision
				Instantiate (explosion, transform.position, transform.rotation);
				suicideScore = (int) gameObject.GetComponentInChildren<Slider> ().value;
				UIControl.Instance.AddScore (suicideScore);
				if (UIControl.Instance.PlayerIsDead ((-1f * (float) suicideScore))) {
					GameController.Instance.PlayerDied ();
					Instantiate (explosion, transform.position, transform.rotation);
					Destroy (other.gameObject);
				}
				Destroy (gameObject);
			}

		} else { 
			float currHit = 0f;
			int currScore = 0;
			if (other.tag == "Bullet") {
				//print (gameObject.ToString () + " was hit with Bullet");
				currHit = bulletDamage;
				currScore = bulletScore;
			} else if (other.tag == "Missle") {
				//print (gameObject.ToString () + " was hit with Missle");
				currHit = missleDamage;
				currScore = missleScore;
			} else if (other.tag == "Lazer") {
				currHit = lazerDamage;
				currScore = lazerScore;
				destProj = false;
			}
			// could add more bullet types above in an "else if"
			else {
				print (other.gameObject.ToString() + "did not match one of the bulletType tags"); 
				return;
			}
			if (destProj) {
				Destroy (other.gameObject);
			}
			try {
				eHealthScript = gameObject.GetComponentInChildren <EnemyHealth> ();
				UIControl.Instance.AddScore (currScore);
				if (eHealthScript.EnemyIsDead (currHit)) {
					if (gameObject.name == "core"){
						// boss died
						UIControl.Instance.AddScore (5000);
						// for now its game over
						SceneManager.LoadScene("WinGame");
					}
					Instantiate (explosion, transform.position, transform.rotation);
					Destroy (gameObject);
				}
			} catch {
				print ("could not get " + gameObject.ToString () + " Script!");
			}
			
		}
	}
}