using UnityEngine;
using System.Collections;

public class Puzzle1 : CollisionDetection {

	public Rigidbody2D smallCircle;
	public Rigidbody2D largeCircle;
	public float innerCircleRotationSpeed;
	public float outerCircleRotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (puzzle1Complete) {
			smallCircle.MoveRotation (smallCircle.rotation + innerCircleRotationSpeed * Time.fixedDeltaTime * -1);
			largeCircle.MoveRotation (largeCircle.rotation + outerCircleRotationSpeed * Time.fixedDeltaTime * -1);
		} else {
			smallCircle.MoveRotation (smallCircle.rotation + innerCircleRotationSpeed * Time.fixedDeltaTime);
			largeCircle.MoveRotation (largeCircle.rotation + outerCircleRotationSpeed * Time.fixedDeltaTime);
		}


	}

}
