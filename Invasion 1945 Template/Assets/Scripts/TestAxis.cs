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
	public GameObject SpawnAsteroidScript;
	public float cameraScrollSpeed;



	private float initialCameraPosYMin;
	private Vector3 initialCameraPos;
	private float camHeight;
	public static bool level2 = false;
	bool asteroidsSpawned = false;
	Rigidbody spaceShipRigidBody;
	public static bool betweenLevels = false;

	public static bool doneLevel2Transition = false;
	private float spaceshipInitYPos = 0f;
	public static int blackHoleCount = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine (fade ());
		initialCameraPosYMin = camera.transform.position.y;
		initialCameraPos = camera.transform.position;
		camHeight = Camera.main.orthographicSize * 2f;

		// Set Initial Values
		blackHoleCount = 0;
		betweenLevels = false;
		doneLevel2Transition = false;
		level2 = false;

		if(GameController.Instance.puzzle1Checkpoint) {
			betweenLevels = true;
			camera.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y + 13, camera.transform.position.z);
			// added by Artem to fix null pointer
			try{
				spaceShipRigidBody.transform.position = new Vector3 (spaceShipRigidBody.transform.position.x + 2, spaceShipRigidBody.transform.position.y + 13, spaceShipRigidBody.transform.position.z);
			}catch{
				Debug.Log ("testaxis line 51: could not get spaceShipRigidBody poisiton");
			}
		}
		GameObject[] innerAsteroids = GameObject.FindGameObjectsWithTag ("InnerAsteroids");
		if (GameController.Instance.puzzle1NumOfDeaths > 2 && (innerAsteroids.Length > 0)) {
			foreach (GameObject asteroid in innerAsteroids) {
				Destroy (asteroid);
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, moveVertical);

		spaceShipRigidBody = GetComponent<Rigidbody>();

		spaceShipRigidBody.velocity = movement * speed;

		playerClampScript ();
			
		if (betweenLevels) {
			CameraMovementFollow ();
		} 
		if (level2) {
			Vector3 targetPosition2 = new Vector3 (camera.transform.position.x, Camera.main.transform.position.y + cameraScrollSpeed, camera.transform.position.z);
			camera.transform.position = Vector3.Slerp (camera.transform.position, targetPosition2, Time.deltaTime * 1.8f);
			if (GameObject.FindGameObjectsWithTag ("BlackHole").Length < 2) {
				GameObject firstBlackHole = (GameObject) Instantiate (BlackHole, new Vector3 (Random.Range(-9.0f, 0f), Camera.main.transform.position.y + (camHeight/2) + 2.0f , 0.0f), Quaternion.identity);
				Instantiate (BlackHole, new Vector3 (Random.Range(0f, 9.0f), Random.Range(firstBlackHole.transform.position.y + camHeight/2,  + firstBlackHole.transform.position.y + 5.0f) , 0.0f), Quaternion.identity);
				blackHoleCount++;
				if (blackHoleCount > 1 && !asteroidsSpawned) {
					Instantiate (SpawnAsteroidScript);
					asteroidsSpawned = true;
				}

			}
		}
	}
		
	public void playerClampScript() {
		
		if (!betweenLevels) {
			if (level2) {
				if (!doneLevel2Transition) {
					if(spaceshipInitYPos == 0f) {
						spaceshipInitYPos = spaceShipRigidBody.position.y;
					}
					spaceShipRigidBody.position = new Vector3 (
						Mathf.Clamp (spaceShipRigidBody.position.x, boundary.xMin, boundary.xMax),
						Mathf.Clamp (spaceShipRigidBody.position.y, spaceshipInitYPos, spaceshipInitYPos),
						Mathf.Clamp (spaceShipRigidBody.position.z, 0, 0)

					);
					if(spaceShipRigidBody.position.y < camera.transform.position.y + 2.0f) {
						doneLevel2Transition = true;
					}
				} else {
					spaceShipRigidBody.position = new Vector3 (
						Mathf.Clamp (spaceShipRigidBody.position.x, boundary.xMin, boundary.xMax),
						Mathf.Clamp (spaceShipRigidBody.position.y, camera.transform.position.y - Mathf.Abs (boundary.yMin), camera.transform.position.y + 2.0f),
						Mathf.Clamp (spaceShipRigidBody.position.z, 0, 0)

					);
				}
			} else {
				spaceShipRigidBody.position = new Vector3 (
					Mathf.Clamp (spaceShipRigidBody.position.x, boundary.xMin, boundary.xMax),
					Mathf.Clamp (spaceShipRigidBody.position.y, camera.transform.position.y - Mathf.Abs (boundary.yMin), camera.transform.position.y + boundary.yMax),
					Mathf.Clamp (spaceShipRigidBody.position.z, 0, 0)
				
				);
			}
		} else {
			spaceShipRigidBody.position = new Vector3 (
				Mathf.Clamp (spaceShipRigidBody.position.x, boundary.xMin, boundary.xMax),
				Mathf.Clamp (spaceShipRigidBody.position.y, camera.transform.position.y - Mathf.Abs (boundary.yMin), camera.transform.position.y + 100),
				Mathf.Clamp (spaceShipRigidBody.position.z, 0, 0)
			);
		}

	}


	public void CameraMovementFollow() {
		if (Mathf.Abs(spaceShipRigidBody.position.y - camera.transform.position.y) >= 2f ||
			Mathf.Abs(spaceShipRigidBody.position.x - camera.transform.position.x) >= 2f) 
		{

			if (betweenLevels) {
				Vector3 targetPosition = new Vector3 (camera.transform.position.x, spaceShipRigidBody.position.y, camera.transform.position.z);
				camera.transform.position = Vector3.Slerp (camera.transform.position, targetPosition, Time.deltaTime * 1.8f);
				camera.transform.position = new Vector3 (
					camera.transform.position.x,
					Mathf.Clamp (camera.transform.position.y, initialCameraPosYMin, camera.transform.position.y + 100),
					camera.transform.position.z
				);

				// Code to clamp position of player and camera for next puzzle
				if (initialCameraPosYMin >= camHeight) {
					Vector3 targetPosition2 = new Vector3 (spaceShipRigidBody.position.x, camera.transform.position.y, spaceShipRigidBody.position.z);
					spaceShipRigidBody.position = Vector3.Slerp (spaceShipRigidBody.position, targetPosition2, Time.deltaTime * 1.8f);
					level2 = true;
					betweenLevels = false;
					GameController.Instance.puzzle1Checkpoint = true;
				}
				initialCameraPosYMin = camera.transform.position.y;
			}
		}


	}

	public IEnumerator fade() {
		float fadeTime = GameObject.Find ("GameController").GetComponent<Fading> ().BeginFade (-1);
		yield return new WaitForSeconds (fadeTime);
	}

}
