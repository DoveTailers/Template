using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {
	public float scrollSpeed;
	public float tileSizeZ;
	public GameObject childBG;
	private bool onChild = true;

	private Vector2 startPosition;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		Vector3 newScale = childBG.transform.localScale;
		newScale.x *= -1;
		childBG.transform.localScale = newScale;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector2.up * newPosition;
	}
}
