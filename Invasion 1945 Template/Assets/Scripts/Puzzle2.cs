using UnityEngine;
using System.Collections;

public class Puzzle2 : CollisionDetection {

	public Rigidbody2D fanObstacle;
	public float fanRotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (puzzle1Complete) {
			fanObstacle.MoveRotation (fanObstacle.rotation + fanRotationSpeed * Time.fixedDeltaTime * -1);
		} else {
			fanObstacle.MoveRotation (fanObstacle.rotation + fanRotationSpeed * Time.fixedDeltaTime);
		}
	}

}
