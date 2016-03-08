using UnityEngine;
using System.Collections;

public class Bullet_DestoryByContact : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		if (other.tag == "Player") {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}

		
	}
}