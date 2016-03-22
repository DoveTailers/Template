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

    private int rocket_destoryed = 0;
    public bool shield_destoryed = false;
    public bool left_done = false;
    public bool right_done = false;
    public bool setup = false;
    public float movespeed;

	private bool isBossDead;

	private PauseMenu pauseScript;

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
            }
        }

        if (setup == true)
        {
            if (rocket_destoryed == 2)
            {
                //i can potentially set more attacks up here when both sides are destoryed from the puzzle
            }
            else
            {
                //and here when someone brute forced it
            }
        }
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

    IEnumerator Next(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        if (!GameController.Instance.IsPlayerDead())
        {
            print("moving to next scene");
            UIControl.Instance.AddScore(1500);
            GameController.Instance.SaveGameState();
            SceneManager.LoadScene("some kind of win screen here");
        }
    }

}
