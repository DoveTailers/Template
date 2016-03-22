using UnityEngine;
using System.Collections;

public class UICollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Boundary" || other.tag == "Shootable") {
			print ("uicollider error");
			return;
		} else if (other.tag == "Player") {
			//print ("entering collider");
			UIControl.Instance.FadeStats ();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		//print ("Exiting collider");
		UIControl.Instance.UnFadeStats ();
	}

}
