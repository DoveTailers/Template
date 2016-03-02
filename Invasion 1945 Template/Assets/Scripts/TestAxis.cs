using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class TestAxis : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public GameObject camera;
	private Vector3 velocity = Vector3.zero;
	public GameObject BlackHole;
	private float initialCameraPosYMin;
	private Vector3 initialCameraPos;
	private float camHeight;
	bool level2;
	private GUIStyle myGUIStyle1 = new GUIStyle();

	void OnGUI() {
		myGUIStyle1.fontSize = 50;
		myGUIStyle1.normal.textColor = Color.white;

		GUI.Label (new Rect (10, 5, 100, 50), "Movement: " + Input.GetAxis("Vertical"), myGUIStyle1);
	}

	// Use this for initialization
	void Start () {
		initialCameraPosYMin = camera.transform.position.y;
		initialCameraPos = camera.transform.position;
		camHeight = Camera.main.orthographicSize * 2f;
		level2 = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, moveVertical);

		Rigidbody spaceShipRigidBody = GetComponent<Rigidbody>();

		spaceShipRigidBody.velocity = movement * speed;

		if (!CollisionDetection.reverse || level2) {
			spaceShipRigidBody.position = new Vector3 (
				Mathf.Clamp (spaceShipRigidBody.position.x, boundary.xMin, boundary.xMax),
				Mathf.Clamp (spaceShipRigidBody.position.y, boundary.yMin, boundary.yMax),
				Mathf.Clamp (spaceShipRigidBody.position.z, 0, 0)
			);
		} else {
			spaceShipRigidBody.position = new Vector3 (
				Mathf.Clamp (spaceShipRigidBody.position.x, boundary.xMin, boundary.xMax),
				Mathf.Clamp (spaceShipRigidBody.position.y, camera.transform.position.y - boundary.yMax, camera.transform.position.y + 100),
				Mathf.Clamp (spaceShipRigidBody.position.z, 0, 0)
			);
		}
			
		if (Mathf.Abs(spaceShipRigidBody.position.y - camera.transform.position.y) >= 2f ||
			Mathf.Abs(spaceShipRigidBody.position.x - camera.transform.position.x) >= 2f) 
		{
			
			if(CollisionDetection.reverse && (!level2)) {
				Vector3 targetPosition = new Vector3 (camera.transform.position.x, spaceShipRigidBody.position.y, camera.transform.position.z);
				camera.transform.position = Vector3.Slerp (camera.transform.position, targetPosition, Time.deltaTime * 1.8f);
				camera.transform.position = new Vector3 (
					camera.transform.position.x,
					Mathf.Clamp (camera.transform.position.y, initialCameraPosYMin, camera.transform.position.y + 100),
					camera.transform.position.z
				);

				// Code to clamp position of player and camera for next puzzle
				if (initialCameraPosYMin >= camHeight) {
					if (GameObject.FindGameObjectWithTag ("BlackHole") == null) {
						Instantiate (BlackHole, new Vector3 (-9.0f, spaceShipRigidBody.position.y, 0.0f), Quaternion.identity);
						Instantiate (BlackHole, new Vector3 (9.0f, spaceShipRigidBody.position.y - 5.0f, 0.0f), Quaternion.identity);
						boundary.yMin = camera.transform.position.y - (camHeight / 3.5f) + GetComponent<Renderer> ().bounds.size.y;
						boundary.yMax = camera.transform.position.y + (camHeight / 1.5f) - GetComponent<Renderer> ().bounds.size.y;
						level2 = true;
					}
				}
				initialCameraPosYMin = camera.transform.position.y;
			}
			if (level2) {
				Vector3 targetPosition = new Vector3 (camera.transform.position.x, 
					initialCameraPosYMin + camHeight/4, 
					camera.transform.position.z);
				camera.transform.position = Vector3.Slerp (camera.transform.position, targetPosition, Time.deltaTime * 1.5f);
			}
		}
	}
}
