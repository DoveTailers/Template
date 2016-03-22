using UnityEngine;
using System.Collections;

public class Boss_Astorid_DestorybyContact: MonoBehaviour {
    //damage copied form bullet scripts
    private float astoridDamage = -20f;

    public GameObject explosion;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            print("astroid hit player with damage: " + astoridDamage.ToString());
            Destroy(gameObject);
            if (UIControl.Instance.PlayerIsDead(astoridDamage))
            {
                print("player has died from astorid damage");

                GameController.Instance.PlayerDied();
                Instantiate(explosion, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
            }

        }


    }
}
