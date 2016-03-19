﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shootable_DestoryByContact : MonoBehaviour {

	private UIControl uiScript;
	private EnemyHealth eHealthScript;

	// adjust to change weapon / collision damage and points
	private float bulletDamage = -4f;
	private int bulletScore = 4;
	private float missleDamage = -10f;
	private int missleScore = 10;
	private float collisionDamage = -50f;
	private int suicideScore;

	public GameObject explosion;
	void OnTriggerEnter2D(Collider2D other)
	{
		// added shootable tag to EnemyBullet_1 because I think another script takes care of it.
		// feel free to correct me
		if (other.tag == "Boundary" || other.tag == "Shootable") {
			return;
		}
		if (other.tag == "Player") {
			// player on ship collision
			Instantiate (explosion, transform.position, transform.rotation);
			suicideScore = (int) gameObject.GetComponentInChildren<Slider> ().value;
			UIControl.Instance.AddScore (suicideScore);
			if (UIControl.Instance.PlayerIsDead (collisionDamage)) {
				GameController.Instance.PlayerDied ();
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (other.gameObject);
			}
			Destroy (gameObject);

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
			} 
			// could add more bullet types above in an "else if"
			else {
				print (other.gameObject.ToString() + "did not match one of the bulletType tags"); 
				return;
			}
			Destroy (other.gameObject);
			try {
				eHealthScript = gameObject.GetComponentInChildren <EnemyHealth> ();
				UIControl.Instance.AddScore (currScore);
				if (eHealthScript.EnemyIsDead (currHit)) {
					Instantiate (explosion, transform.position, transform.rotation);
					Destroy (gameObject);
				}
			} catch {
				print ("could not get " + gameObject.ToString () + " Script!");
				print ("script: " + eHealthScript.ToString());
			}
			
		}
	}
}