using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController_Wave : MonoBehaviour {
	public float speed;
	Rigidbody2D rb;
	public Boundary boundary;
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	public GameObject shot1;
	public GameObject shot2_a;
	public GameObject shot2_b;
	public Transform shotSpawn;
	public float fireRate;
	public int bulletType;

	private float nextFire;
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			if(bulletType == 0)
			{
				Instantiate(shot1, shotSpawn.position, shotSpawn.rotation);
			}
			else if(bulletType == 1)
			{
				Instantiate(shot2_a, shotSpawn.position, shotSpawn.rotation);
				Instantiate(shot2_b, shotSpawn.position, shotSpawn.rotation);
			}
		}

	}

	void FixedUpdate()
	{
		rb.velocity = transform.up.normalized*speed;
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical); 
		rb.velocity = movement * speed;

		rb.position = new Vector2 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),  
			Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax)
		);
		if (Input.GetButtonDown("Fire2")) 
		{
			if (bulletType != 1)
			{
				bulletType++;
			}
			else if (bulletType == 1)
			{
				bulletType = 0;
			}
		}
	}
}
