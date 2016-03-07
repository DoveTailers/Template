using UnityEngine; 
using System.Collections;

public class GravityScript2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerStay2D (Collider2D player) {
		Debug.Log ("approaching trigger");
		if (player.gameObject.CompareTag ("Player")) {

			Rigidbody2D spaceShipRigidBody = player.gameObject.GetComponent<Rigidbody2D>();
			var direction = -(spaceShipRigidBody.transform.position - gameObject.transform.position).normalized;
			//			direction = new Vector3 ((1 / direction.x), (1 / direction.y), direction.z);
			spaceShipRigidBody.AddForce(-(spaceShipRigidBody.transform.position - gameObject.transform.position).normalized * spaceShipRigidBody.mass * 400.0F / (gameObject.transform.position - spaceShipRigidBody.transform.position).sqrMagnitude);

			//spaceShipRigidBody.AddForce (direction * 100.0F);
		}

	}
}
