using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary1
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController_Wave : MonoBehaviour {
	public float speed;
	Rigidbody2D rb;
	public Boundary1 boundary1;
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		UIControl.Instance.ChangeWeaponTo (0);
	}

	public GameObject shot1;
	public GameObject shot2_a;
	public GameObject shot2_b;
	public GameObject shot3;
	public Transform shotSpawn;
	public float fireRate;
	public int bulletType;

	private bool isFiring;

	private float nextFire;

	void Awake (){
		isFiring = false;
	}

	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (bulletType == 0 && !UIControl.Instance.IsOverheat ()) {
				
				isFiring = true;
				UIControl.Instance.UpdateGunFill (5f);
				Instantiate (shot1, shotSpawn.position, shotSpawn.rotation);
			} else if (bulletType == 1) {

				if (UIControl.Instance.GetAmmo () > 0) {
					Instantiate (shot2_a, shotSpawn.position, shotSpawn.rotation);
					Instantiate (shot2_b, shotSpawn.position, shotSpawn.rotation);
					UIControl.Instance.SetAmmo (-1);
				} else {
					if (UIControl.Instance.ChangeWeaponTo (0)) {
						if (bulletType != 0) {
							bulletType = 0;
						}
					}
				}
				
                
			} else if (bulletType == 2) {
				if (UIControl.Instance.GetAmmo () > 0) {
					nextFire = Time.time + 1.2f;
					Instantiate (shot3, new Vector3 (shotSpawn.position.x, shotSpawn.position.y + 1.85f, shotSpawn.position.z), shotSpawn.rotation);
					//Destory(shot3.gameObject, 1.0f)
					UIControl.Instance.SetAmmo (-1);
				} else {
					if (UIControl.Instance.ChangeWeaponTo (0)) {
						if (bulletType != 0) {
							bulletType = 0;
						}
					}
				}
			}
		} else {
			isFiring = false;
			if (!UIControl.Instance.IsGunZero () && Time.time > nextFire){
				UIControl.Instance.UpdateGunFill (-1f);
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
			Mathf.Clamp (rb.position.x, boundary1.xMin, boundary1.xMax),  
			Mathf.Clamp (rb.position.y, boundary1.yMin, boundary1.yMax)
		);
		//if (Input.GetButtonDown("Fire2"))
        if (Input.GetButtonDown("ChangeGun") && (Input.GetAxisRaw("ChangeGun") < 0f))
        {//button j
            if(UIControl.Instance.ChangeWeapon(-1))
            {
				if (bulletType == 1 || bulletType == 2)
                {
                    bulletType--;

                }
                else {
                    bulletType = 2;
                }
            }
        }
        else if (Input.GetButtonDown("ChangeGun") && (Input.GetAxisRaw("ChangeGun") > 0f))
        {//button k
            if(UIControl.Instance.ChangeWeapon(1))
            {
				if (bulletType == 0 || bulletType == 1)
                {
                    bulletType++;
                }
                else if (bulletType == 2)
                {
                    bulletType = 0;
                }
            }

        }
		
	}
}
