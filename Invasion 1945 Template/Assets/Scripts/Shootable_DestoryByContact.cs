using UnityEngine;
using System.Collections;

public class Shootable_DestoryByContact : MonoBehaviour {

	public GameObject explosion;
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		if (other.tag == "Player" || other.tag == "Bullet") {
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}

		
		
	}
}