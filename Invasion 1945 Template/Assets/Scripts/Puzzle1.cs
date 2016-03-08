using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Puzzle1 : MonoBehaviour {

	public float level2Timer = 30.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (TestAxis.level2) {
			
			level2Timer -= Time.deltaTime; 
			if (level2Timer < 0.0f) {
				
				SceneManager.LoadScene ("Wave2");
			}
		}
	}

}
