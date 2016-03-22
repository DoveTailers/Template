using UnityEngine;
using System.Collections;

public class Boss_Puzzle_onCollect : MonoBehaviour {
    public bool leftside;
    private EnemyHealth eHealthScript;
    public GameObject explosion;
    private GameController_Boss My_GameController;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {

            //tick sheld health down and also destory a side missle launcher
            GameObject[] rockets;
            GameObject[] shield;
            shield = GameObject.FindGameObjectsWithTag("boss01_shield");
            if (leftside == true)
            {
                rockets = GameObject.FindGameObjectsWithTag("boss01_left_rocket");
            }
            else
            {
                rockets = GameObject.FindGameObjectsWithTag("boss01_right_rocket");
            }

            foreach (GameObject r in rockets)
            {
                try
                {
                    print(r.transform.position);
                    Instantiate(explosion, r.transform.position, r.transform.rotation);
                    Destroy(r);

                }
                catch
                {
                    print("could not get " + r.gameObject.ToString() + " Script!");
                    print("script: " + eHealthScript.ToString());
                }
            }

            Destroy(gameObject);

            foreach (GameObject s in shield)
            {
                try
                {
                    eHealthScript = s.GetComponentInChildren<EnemyHealth>();
                    float currHit = -2600f;
                    if (eHealthScript.EnemyIsDead(currHit))
                    {
                        Instantiate(explosion, transform.position, transform.rotation);
                        Destroy(s);

                        My_GameController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController_Boss>();
                        My_GameController.shield_destoryed = true;
                    }
                }
                catch
                {
                    print("could not get " + s.gameObject.ToString() + " Script!");
                    print("script: " + eHealthScript.ToString());
                }
            }



            

        }


    }
}