using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
				SceneManager.LoadScene("Puzzle_2");
			}

		}
	}
		
}
