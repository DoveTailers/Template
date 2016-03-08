using UnityEngine;
using System.Collections;

public class Wave_Cross_forward : MonoBehaviour {
	public float speed;
	float step;
	private Transform target;
	void Start () {
		Rigidbody2D rb;
		rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = transform.up.normalized*-speed;
		InvokeRepeating ("SwitchSides", 1f, 3f);
	}
	void SwitchSides(){
		Rigidbody2D rb;
		rb = gameObject.GetComponent<Rigidbody2D> ();
		if (transform.position.x>0){
			rb.velocity = new Vector2((float)-2.5, GetComponent<Rigidbody2D>().velocity.y);
		}else{
			rb.velocity = new Vector2((float)2.5, GetComponent<Rigidbody2D>().velocity.y);
		}
	}
}
