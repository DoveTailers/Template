﻿using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		Rigidbody2D rb;
		rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = transform.up.normalized*-speed;
	}
}