using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestoryByContact : MonoBehaviour {

    public GameObject explosion;
	private float collisionDamage = -50f;
	private int suicideScore;
	//public GameObject explosionOther;
    void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Boundary") {
			return;
		} else if (other.tag == "BlackHole") {
			return;
		} else if (other.tag == "Shootable") {
			return;
		}
			
       
		//Instantiate(explosionOther, other.transform.position, other.transform.rotation);
		if (other.tag == "Player") {
			suicideScore = (int) gameObject.GetComponentInChildren<Slider> ().value;
			UIControl.Instance.AddScore (suicideScore);
			if (UIControl.Instance.PlayerIsDead (collisionDamage)) {
				GameController.Instance.PlayerDied ();
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (other.gameObject);
			}
		}
		Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);

	}
}
