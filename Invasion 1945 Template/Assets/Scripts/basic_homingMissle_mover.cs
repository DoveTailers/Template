using UnityEngine;
using System.Collections;

public class basic_homingMissle_mover : MonoBehaviour {
	public Vector3 target;
	public Vector3 direction;
	public float initial_speed_down;
	private Rigidbody2D rb;
	public float windupTime = 1f;
	private bool winding = false;
	private bool targetFound = false;
	private GameObject closestShootable;
	public enum LR{Left, Right};
	public LR current;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		StartCoroutine (Windup ());
		rb.velocity = transform.up.normalized*initial_speed_down;
		closestShootable = FindClosestShootable (); 
	}
	void Update()
	{
		if (!targetFound) {
			if (closestShootable == null) {
				if (winding) {
					closestShootable = FindClosestShootable ();
					if(current == LR.Right)
					{
						rb.AddForce(Vector3.right*1);
					}
					else{
						rb.AddForce(Vector3.left*1);
					}

				} else {
					rb.AddForce (Vector3.up * 7);
					//cant find target, forfeit missle
				}
			} else {
				target = closestShootable.transform.position;
				targetFound = true;
			}
		} else {
			if(winding)
			{
				if(current == LR.Right)
				{
					rb.AddForce(Vector3.right*1);
				}
				else{
					rb.AddForce(Vector3.left*1);
				}
			}else{
				direction = (target - transform.position);
				if(direction.y<1)
				{
					direction.y = 1;
				}
				rb.AddForce(direction*2);
			}
		}
	
	}

	IEnumerator Windup(){
		winding = true;
		float time = 0;
		while (time < windupTime) {
			time += Time.deltaTime;
			yield return null;
		}
		winding = false;
	}

	GameObject FindClosestShootable() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Shootable");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
}


