using UnityEngine;
using System.Collections;

public class PuzzleBullets : MonoBehaviour {
	public GameObject shot1;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire = 0.0F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot1, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
