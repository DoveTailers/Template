using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider collider) {
		if (collider.gameObject.CompareTag ("Player") || collider.gameObject.CompareTag ("FlyingAsteroids")) {
			
			Rigidbody colliderRigidBody = collider.gameObject.GetComponent<Rigidbody>();
			var direction = -(colliderRigidBody.transform.position - gameObject.transform.position).normalized;
//			direction = new Vector3 ((1 / direction.x), (1 / direction.y), direction.z);
			if (collider.gameObject.CompareTag ("Player")) {
				colliderRigidBody.AddForce(-(colliderRigidBody.transform.position - gameObject.transform.position).normalized * colliderRigidBody.mass * 2000.0F / (gameObject.transform.position - colliderRigidBody.transform.position).sqrMagnitude);
			} else if(collider.gameObject.CompareTag ("FlyingAsteroids")) {
				colliderRigidBody.AddForce(-(colliderRigidBody.transform.position - gameObject.transform.position).normalized * colliderRigidBody.mass * 10.0F / (gameObject.transform.position - colliderRigidBody.transform.position).sqrMagnitude);
			}

			//spaceShipRigidBody.AddForce (direction * 100.0F);
		}

	}


}
