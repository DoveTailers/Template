using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider player) {
		if (player.gameObject.CompareTag ("Player")) {
			Rigidbody spaceShipRigidBody = player.gameObject.GetComponent<Rigidbody>();
			var direction = -(spaceShipRigidBody.transform.position - gameObject.transform.position).normalized;
//			direction = new Vector3 ((1 / direction.x), (1 / direction.y), direction.z);
			spaceShipRigidBody.AddForce(-(spaceShipRigidBody.transform.position - gameObject.transform.position).normalized * spaceShipRigidBody.mass * 2000.0F / (gameObject.transform.position - spaceShipRigidBody.transform.position).sqrMagnitude);

			//spaceShipRigidBody.AddForce (direction * 100.0F);
		}

	}


}
