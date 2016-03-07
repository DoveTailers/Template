using UnityEngine;
using System.Collections;

public class AsteroidBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		if (!(other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("BlackHole"))) {
			
			Destroy(other.gameObject);

		}
	}
}
