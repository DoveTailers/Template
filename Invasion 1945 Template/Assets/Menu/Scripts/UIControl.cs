using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {

	//UICanvas access
	public GameObject UICanvas;


	//weapon setup
	public Transform[] allWeapons;
	public int selectedWeapon;

	//health and armour bar, could move this to a damage script for all player objects
	// public float initialValue; move as part of stats bar 
	public GameObject healthBar;
	// public GameObject ArmourBar; for later


	// Update is called once per frame
	// Use J,K to switch between weapons
	void Update () {
		if (Input.GetKeyDown (KeyCode.J)) {
			ChangeWeapon (-1);
		} else if (Input.GetKeyDown (KeyCode.K)) {
			ChangeWeapon (1);
		}

		//TEST AREA ------------------------------------------------------------------------
		// press 1 to test setammo
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SetAmmo (1);
		}
		// press 2 and 3 to test health bar change
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			AdjustHealth (-5.0f);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			AdjustHealth (5.0f);
		}
		// ----------------------------------------------------------------------------------
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

	// adjust ammo value in the UI
	// could use inf for gun1 by making check before calling to ignore if selectedWeapon == 0;
	public void SetAmmo (int amount){
		// get the ammo text field of the gun object
		Text ammoBox = allWeapons [selectedWeapon].Find ("AmmoCount").GetComponent<Text>();
		//current value as int
		int ammoValue = int.Parse (ammoBox.text);
		ammoBox.text = (ammoValue + amount).ToString ();

		// if ammo is out disable the object, remove from list, set next weapon as active
//		if (ammoValue + amount <= 0 && selectedWeapon != 0) {
//			int emptyWeapon = selectedWeapon;
//			ChangeWeapon (-1);
//		} else {
//			// set new value
//			ammoBox.text = (ammoValue + amount).ToString ();
//		}
	}

	public void AdjustHealth (float amount) {
		healthBar.GetComponent<Slider> ().value += amount;
	}
}


