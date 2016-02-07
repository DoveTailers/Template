using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class TestAxis : MonoBehaviour {

	public float speed;
	public Boundary boundary;

	private GUIStyle myGUIStyle1 = new GUIStyle();

	void OnGUI() {
		myGUIStyle1.fontSize = 50;
		myGUIStyle1.normal.textColor = Color.white;

		GUI.Label (new Rect (10, 5, 100, 50), "Movement: " + Input.GetAxis("Vertical"), myGUIStyle1);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector2 movement = new Vector3(moveHorizontal, moveVertical);

		Rigidbody2D spaceShipRigidBody = GetComponent<Rigidbody2D>();

		spaceShipRigidBody.velocity = movement * speed;

		spaceShipRigidBody.position = new Vector2 (
			Mathf.Clamp(spaceShipRigidBody.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(spaceShipRigidBody.position.y, boundary.yMin, boundary.yMax)
		);
			
	}
}
