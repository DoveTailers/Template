using UnityEngine;
using System.Collections;

public class Collision_BlockPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "Player") {
			return;
		}

	}
}
