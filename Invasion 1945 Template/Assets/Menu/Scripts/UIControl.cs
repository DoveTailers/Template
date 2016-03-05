using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {

	public GameObject UICanvas;

	public Transform[] allWeapons;
	public int selectedWeapon;
	//public int ammocount;


	// Update is called once per frame
	// Use J,K to switch between weapons
	void Update () {
		if (Input.GetKeyDown (KeyCode.J)) {
			ChangeWeapon (-1);
		} else if (Input.GetKeyDown (KeyCode.K)) {
			ChangeWeapon (1);
		}
	}

	// set active of active weapon object, while disabling all others. check to see which object is active to know
	// active weapon
	public void ChangeWeapon (int direction) {
		int result = selectedWeapon + direction;
		if (result < 0) {
			selectedWeapon = allWeapons.Length - 1;
		} else if (result >= allWeapons.Length) {
			selectedWeapon = 0; 
		} else {
			selectedWeapon = result;
		}

		for (int i = 0; i < allWeapons.Length; i++) {
			if (i == selectedWeapon) {
				allWeapons [i].gameObject.SetActive (true);
			} else {
				allWeapons [i].gameObject.SetActive (false);
			}
		}
	}

}
