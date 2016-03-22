using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shootable_BlockByContact : MonoBehaviour
{

    private UIControl uiScript;
    private EnemyHealth eHealthScript;

    // adjust to change weapon / collision damage and points
    private float bulletDamage = -4f;
    private int bulletScore = 4;
    private float missleDamage = -10f;
    private int missleScore = 10;
    private float collisionDamage = -50f;
    private int suicideScore;

    private GameController_Boss My_GameController;

    public GameObject explosion;
    void OnTriggerEnter2D(Collider2D other)
    {
        // added shootable tag to EnemyBullet_1 because I think another script takes care of it.
        // feel free to correct me
        if (other.tag == "Boundary" || other.tag == "Shootable")
        {
            return;
        }
        if (other.tag == "Player")
        {
            // does job already, dont need to do anything

        }
        else {
            float currHit = 0f;
            if (other.tag == "Bullet")
            {
                //print (gameObject.ToString () + " was hit with Bullet");
                currHit = bulletDamage;

            }
            else if (other.tag == "Missle")
            {
                //print (gameObject.ToString () + " was hit with Missle");
                currHit = missleDamage;

            }
            // could add more bullet types above in an "else if"
            else {
                print(other.gameObject.ToString() + "did not match one of the bulletType tags");
                return;
            }
            Destroy(other.gameObject);
            try
            {
                eHealthScript = gameObject.GetComponentInChildren<EnemyHealth>();
               
                if (eHealthScript.EnemyIsDead(currHit))
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                    Destroy(gameObject);

                    My_GameController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController_Boss>();
                    My_GameController.shield_destoryed = true;
                }
            }
            catch
            {
                print("could not get " + gameObject.ToString() + " Script!");
            }

        }
    }
}