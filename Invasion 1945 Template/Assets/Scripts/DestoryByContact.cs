using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour {

    public GameObject explosion;
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
        Instantiate(explosion, transform.position, transform.rotation);
		//Instantiate(explosionOther, other.transform.position, other.transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);

	}
}
