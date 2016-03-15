using UnityEngine;
using System.Collections;
using System.Linq;

public class RemoveStaleObjects : MonoBehaviour {
	private GameObject[] removableObjectsBlackHole;
	private GameObject[] OuterAsteroids;
	private GameObject[] InnerAsteroids;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] flyingAsteroids = GameObject.FindGameObjectsWithTag ("FlyingAsteroids");
		removableObjectsBlackHole = GameObject.FindGameObjectsWithTag ("BlackHole");
		OuterAsteroids = GameObject.FindGameObjectsWithTag ("InnerAsteroids");
		InnerAsteroids = GameObject.FindGameObjectsWithTag ("OuterAsteroids");
		GameObject[] array = ((OuterAsteroids.Concat (InnerAsteroids).ToArray()).Concat(flyingAsteroids).ToArray()).Concat(removableObjectsBlackHole).ToArray();

		foreach (GameObject obj in array) {
			if (obj.transform.position.y < (Camera.main.transform.position.y - Camera.main.orthographicSize - 3.0f)) {
				Destroy (obj);
			}
		}
	}
}
