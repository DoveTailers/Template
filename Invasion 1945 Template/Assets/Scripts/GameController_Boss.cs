using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameController_Boss : MonoBehaviour
{
	public GameObject boss;
	public GameObject left_rocket;
	public GameObject right_rocket;
	public GameObject core;
	public GameObject canvas;
	public GameObject shield2;
	public GameObject shield3;
	public GameObject Eur;
	public GameObject Eur2;
	public GameObject astroid;
	public GameObject astroid2;
	public GameObject laserBoss;
	public GameObject laserBoss2;
	public GameObject laser1;
	GameObject laser2;
	private int rocket_destoryed = 0;
	public bool shield_destoryed = false;
	public bool left_done = false;
	public bool right_done = false;
	public bool setup = false;
	public float movespeed;
	Vector3 laser1NewScale;
	Vector3 laser2NewScale;
	private bool isBossDead;
	private Vector3 laser1OriginalScale;
	private Vector3 laser2OriginalScale;
	private bool setUpLasers = false;
	private PauseMenu pauseScript;
	private bool reverseLasers = false;
	private bool lasersInPlace = false;
	private bool reverseLaserBoss = false;

	void Start()
	{
		Time.timeScale = 0f;
		pauseScript = GameObject.Find ("PauseMenu").gameObject.GetComponent<PauseMenu> ();
		pauseScript.Continue ();
		isBossDead = false;
		boss = GameObject.Find("Boss_01");
		core = GameObject.Find("Boss_01/core");
		canvas = GameObject.Find("Boss_01/core/Canvas");
		shield2 = GameObject.Find("Boss_01/boss01_shield_2");
		shield3 = GameObject.Find("Boss_01/boss01_shield_3");
		Eur = GameObject.Find("Boss_01/EUR");
		Eur2 = GameObject.Find("Boss_01/EUR_2");
		astroid = GameObject.Find("Boss_01/Astorid_Inner_Circle");
		astroid2 = GameObject.Find("Boss_01/Astorid_Inner_Circle_2");
		InvokeRepeating("SwitchSides", 1f, 2f);

		laser1.SetActive (false);

		laser2 = (GameObject) Instantiate (laser1, new Vector3 (laserBoss.transform.position.x, laserBoss.transform.position.y - 0.2f, 0.0f), 
			Quaternion.Euler(laser1.transform.rotation.x,laser1.transform.rotation.y,90));
		laser2.SetActive (false);
		//laser2OriginalScale = new Vector3(laser1.transform.localScale.x, 6.0f, laser1.transform.localScale.z);
		laser2.transform.localScale = new Vector3 (laser1.transform.localScale.x, 6.0f, laser1.transform.localScale.z);
	}

	void Update()
	{

		if (shield_destoryed == true)
		{
			canvas = GameObject.Find("Boss_01/core/Canvas");
			canvas.SetActive(true);
			try
			{
				left_rocket = GameObject.Find("Boss_01/boss01_left_rocket");
				left_rocket.transform.position = Vector3.MoveTowards(left_rocket.transform.position, new Vector3(core.transform.position.x - 0.5f,left_rocket.transform.position.y, left_rocket.transform.position.z), movespeed * Time.deltaTime);
				if (left_rocket.transform.position.x == core.transform.position.x - 0.5f)
				{
					print("made it!");
					left_done = true;
				}
			}
			catch
			{
				if (left_done == false)
				{
					print("well, gj u did a puzzle");
					rocket_destoryed++;
					left_done = true;
				}

			}

			try
			{
				right_rocket = GameObject.Find("Boss_01/boss01_right_rocket");
				right_rocket.transform.position = Vector3.MoveTowards(right_rocket.transform.position, new Vector3(core.transform.position.x + 0.5f, right_rocket.transform.position.y, right_rocket.transform.position.z), movespeed * Time.deltaTime);
				if (right_rocket.transform.position.x == core.transform.position.x + 0.5f)
				{
					print("made it!");
					right_done = true;
				}
			}
			catch
			{
				if (right_done == false)
				{
					print("well, gj u did a puzzle. if it is two, we move on");
					rocket_destoryed++;
					right_done = true;
				}

			}
			try
			{
				Destroy(shield2);
				Destroy(shield3);
				Destroy(Eur);
				Destroy(Eur2);
				Destroy(astroid);
				Destroy(astroid2);
			}
			catch { }
			if (left_done && right_done)
			{
				setup = true;
				shield_destoryed = false;
				setUpLasers = true;

			}
		}

		if (setUpLasers == true) {
			if (!lasersInPlace) {
				laserBoss.transform.position = Vector3.MoveTowards (laserBoss.transform.position, new Vector3 (-8.5f, 5.7f, boss.transform.position.z), Time.deltaTime * 2.5f);
				laserBoss.transform.rotation = Quaternion.Lerp (laserBoss.transform.rotation, Quaternion.Euler (new Vector3 (0, 0, 90)), Time.deltaTime );
//				laserBoss.transform.Rotate( Vector3.forward * (Time.deltaTime * 10.0f));
				laserBoss2.transform.position = Vector3.MoveTowards(laserBoss2.transform.position, new Vector3 (8.5f, 5.7f, boss.transform.position.z), Time.deltaTime * 2.5f);
				laserBoss2.transform.rotation = Quaternion.Lerp (laserBoss2.transform.rotation, Quaternion.Euler (new Vector3 (0, 0, -90)),Time.deltaTime);
			}


			// guns going into position
			if (laserBoss.transform.eulerAngles.z > 89.0f) {
				lasersInPlace = true;
				if (!reverseLaserBoss) {
					laserBoss.transform.position = Vector3.MoveTowards (laserBoss.transform.position, new Vector3 (-8.5f, 6.0f, boss.transform.position.z), Time.deltaTime * 2.5f);
					laserBoss2.transform.position = Vector3.MoveTowards (laserBoss2.transform.position, new Vector3 (8.5f, 6.0f, boss.transform.position.z), Time.deltaTime * 2.5f);
				} else {
					laserBoss.transform.position = Vector3.MoveTowards (laserBoss.transform.position, new Vector3 (-8.5f, -1.7f, boss.transform.position.z), Time.deltaTime * 2.5f);
					laserBoss2.transform.position = Vector3.MoveTowards (laserBoss2.transform.position, new Vector3 (8.5f, -1.7f, boss.transform.position.z), Time.deltaTime * 2.5f);
				}

				if (!laser1.activeSelf && !laser2.activeSelf) {
					laser1.SetActive (true);
					laser2.SetActive (true);
				}


				if (!reverseLasers) {
					laser1.transform.position = new Vector3 (laserBoss.transform.position.x + 0.5f, laserBoss.transform.position.y - 0.2f, 0.0f);
					laser1OriginalScale = laser1.transform.localScale;
					laser1NewScale = new Vector3 (laser1.transform.localScale.x, 6.0f, laser1.transform.localScale.z);


					laser2.transform.position = new Vector3 (laserBoss2.transform.position.x - 0.5f, laserBoss2.transform.position.y - 0.2f, 0.0f);
					laser2OriginalScale = laser2.transform.localScale;
					laser2NewScale = new Vector3 (laser2.transform.localScale.x, 0.1f, laser2.transform.localScale.z);

					laser1.transform.localScale = Vector3.MoveTowards (laser1OriginalScale, laser1NewScale, Time.deltaTime * 0.8f);
					laser2.transform.localScale = Vector3.MoveTowards (laser2OriginalScale, laser2NewScale, Time.deltaTime * 0.8f);
				} else {
					laser1.transform.position = new Vector3 (laserBoss.transform.position.x + 0.5f, laserBoss.transform.position.y - 0.2f, 0.0f);
					laser1OriginalScale = laser1.transform.localScale;
					laser1NewScale = new Vector3 (laser1.transform.localScale.x, 0.1f, laser1.transform.localScale.z);


					laser2.transform.position = new Vector3 (laserBoss2.transform.position.x - 0.5f, laserBoss2.transform.position.y - 0.2f, 0.0f);
					laser2OriginalScale = laser2.transform.localScale;
					laser2NewScale = new Vector3 (laser2.transform.localScale.x, 6.0f, laser2.transform.localScale.z);

					laser1.transform.localScale = Vector3.MoveTowards (laser1OriginalScale, laser1NewScale, Time.deltaTime * 0.8f);
					laser2.transform.localScale = Vector3.MoveTowards (laser2OriginalScale, laser2NewScale, Time.deltaTime * 0.8f);
				}

				if (Mathf.Approximately (laser2.transform.localScale.y, 0.1f)) {
					reverseLasers = !reverseLasers;
				}

				if (Mathf.Approximately (laser1.transform.localScale.y, 0.1f)) {
					reverseLasers = !reverseLasers;
				}

				if (laserBoss.transform.position.y < -1.5f) {
					reverseLaserBoss = !reverseLaserBoss;
				} else if (laserBoss.transform.position.y > 5.9f) {
					reverseLaserBoss = !reverseLaserBoss;
				}

				BoxCollider2D Box1 = laser1.GetComponent<BoxCollider2D> ();
				BoxCollider2D Box2 = laser2.GetComponent<BoxCollider2D> ();

				if (Box1 != null) {
					Destroy (Box1);
				}

				if (Box2 != null) {
					Destroy (Box2);
				}
				Box1 = laser1.AddComponent<BoxCollider2D> ();
				Box2 = laser2.AddComponent<BoxCollider2D> ();

				Box1.isTrigger = true;
				Box2.isTrigger = true;
			}



//			setup = false;

//			StartCoroutine(ScaleOverTime(10));

			if (rocket_destoryed == 2) {
				//i can potentially set more attacks up here when both sides are destoryed from the puzzle
			} else {
				//and here when someone brute forced it
			}
		}


		//laser1.transform.localScale = Vector3.Lerp(laser1.transform.localScale, newScale, 1f * Time.deltaTime);

	}

	IEnumerator ScaleOverTime(float time)
	{
		


		float currentTime = 0.0f;

		do
		{
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);

		//Destroy(gameObject);
	}

	void SwitchSides()
	{
		if (setup == true)
		{
			Rigidbody2D rb;
			rb = boss.GetComponent<Rigidbody2D>();
			if (boss.transform.position.x > 0)
			{
				rb.velocity = new Vector2((float)-2.5, boss.GetComponent<Rigidbody2D>().velocity.y);
			}
			else {
				rb.velocity = new Vector2((float)2.5, boss.GetComponent<Rigidbody2D>().velocity.y);
			}
		}

	}

}