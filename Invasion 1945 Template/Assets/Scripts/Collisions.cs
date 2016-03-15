using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {
	public float restartDelay = 3f;
	float restartTimer;

	public static int checkpoint = 0;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (collision);
		if(CollisionDetection.collision) {
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			Destroy (player);
			restartTimer += Time.deltaTime;

			//Debug.Log (restartTimer);

			if(restartTimer >= restartDelay)
			{
				
				Application.LoadLevel("Puzzle_2");

			}

		}
	}
		
}
