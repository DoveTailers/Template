using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {
	// names for playerprefs
	string highscore = "PlayerScore";
	string health = "PlayerHealth";
	string num_lives = "NumLives";
	string selected_weapon = "SelectedWeapon";

	//UICanvas access
	public GameObject UICanvas;
	//weapon setup
	public GameObject[] allWeapons;
	public int selectedWeapon;
	// private int gun1; // not using dynamic script right now
	//health and armour bar, could move this to a damage script for all player objects
	// public float initialValue; move as part of stats bar 
	public GameObject healthBar;
	public Text score;

	// instantiate UIControl to be used by GameController Script
	private static UIControl instance = null;
	// fetch the instance to be called by other scripts
	public static UIControl Instance {
		get { return instance; }
	}

	void Awake() {
		
		// preserve the old instance if one already exists
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}

		// not used yet but gives easy access to the entire UI display
		UICanvas = GameObject.Find ("UICanvas");

		// initialize the weapons array and [ammo count from PlayerPrefs] NOT USED RIGHT NOW
		// allWeapons = GameObject.FindGameObjectsWithTag("GunUI");
//		for (int i = 0; i < allWeapons.Length; i++) {
//
//			string name = allWeapons [i].gameObject.name;
//			// Gun 1 has no ammo
//			if (name == "Gun1"){ 
//				// incase populating array results in gun1 with different index
//				gun1 = i;
//				continue; 
//			}
//
//			Text textBox = allWeapons [i].gameObject.GetComponentInChildren <Text> ();
//
//			if (PlayerPrefs.HasKey (name)) {
//				textBox.text = PlayerPrefs.GetInt(name).ToString();
//			} else {
//				print ("error: PlayerPrefs ammocount not setup for " + allWeapons [i]);
//			}
//		}

		// get the current weapon
		selectedWeapon = 0;
		// not needed
//		else {
//			//selectedWeapon = gun1;
//		}

		// ChangeWeapon (0); only needed for dynamic array

		healthBar = GameObject.FindGameObjectWithTag ("HealthUI");
		score = GameObject.FindGameObjectWithTag ("ScoreUI").gameObject.GetComponent<Text>();

		if (PlayerPrefs.HasKey (highscore)) {
			score.text = PlayerPrefs.GetInt (highscore).ToString ();
		} else {
			score.text = "0000";
		}

		//preserve the instance throughout scene change
		DontDestroyOnLoad(this.gameObject);
	}

	// Update is called once per frame
	// Use J,K to switch between weapons
	void Update () {
		/*if (Input.GetButtonDown ("ChangeGun") && (Input.GetAxisRaw ("ChangeGun") < 0f)) {
			ChangeWeapon (-1);
		} else if (Input.GetButtonDown ("ChangeGun") && (Input.GetAxisRaw ("ChangeGun") > 0f)) {
			ChangeWeapon (1);
		}
        *///ill have the player controller send the signal instead.


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
//		if (Input.GetAxisRaw ("ChangeGun") > 0) {
//			print ("hello +");
//		} else if (Input.GetAxisRaw ("ChangeGun") < 0) {
//			print ("hello -");
//		}
	}
		

	// reset the ammo count of all weapons
	public void resetAmmo (){
		int ammo = 40;
		for (int i = 1; i < allWeapons.Length; i++) {
			selectedWeapon = i;
			SetAmmo ((ammo - GetAmmo ()));
		}
		selectedWeapon = 0;
	}

	// set active of active weapon object, while disabling all others. check to see which object is active to know
	// active weapon
	public bool ChangeWeapon (int direction) {
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
        return true;

    }
    public bool ChangeWeaponTo(int choice) {
        //change it to a weapon of choice, use carefully to not go over.
        selectedWeapon = choice;
        for (int i = 0; i < allWeapons.Length; i++)
        {
            if (i == selectedWeapon)
            {
                allWeapons[i].gameObject.SetActive(true);
            }
            else {
                allWeapons[i].gameObject.SetActive(false);
            }
        }
        return true;
    }

    // adjust ammo value in the UI
    // could use inf for gun1 by making check before calling to ignore if selectedWeapon == 0;
    public void SetAmmo (int amount){
		if (selectedWeapon == 0) {
			return;
		}
		// get the ammo text field of the gun object
		Text ammoBox = allWeapons [selectedWeapon].gameObject.GetComponentInChildren <Text>();
		//current value as int
		int ammoValue = int.Parse (ammoBox.text);
		ammoBox.text = (ammoValue + amount).ToString ();

		// if ammo is out disable the object, remove from list, set next weapon as active
		if (ammoValue + amount <= 0 && selectedWeapon != 0) {
			int emptyWeapon = selectedWeapon;
			//ChangeWeapon (-1);
		} else {
			// set new value
			ammoBox.text = (ammoValue + amount).ToString ();
		}
	}
    public int GetAmmo() {
        // get the ammo text field of the gun object
        Text ammoBox = allWeapons[selectedWeapon].gameObject.GetComponentInChildren<Text>();
        //current value as int
        int ammoValue = int.Parse(ammoBox.text);
        return ammoValue;
    }

	public void AdjustHealth (float amount) {
		healthBar.GetComponent<Slider> ().value += amount;
	}

	public void SaveGameState(){
		// save ammo
		for (int i = 0; i < allWeapons.Length; i++) {
			string name = allWeapons [i].gameObject.name;
			if (name == "Gun1"){ continue; }
			string ammo = allWeapons [i].gameObject.GetComponentInChildren<Text> ().text;
			PlayerPrefs.SetString (name, ammo);
		}

		// rest of stuff
		PlayerPrefs.SetInt ("PlayerScore", int.Parse(score.text));
		PlayerPrefs.SetFloat ("PlayerHealth", healthBar.gameObject.GetComponent<Slider>().value);
		PlayerPrefs.SetInt ("NumLives", 3);
		PlayerPrefs.SetInt ("SelectedWeapon", selectedWeapon);
	}

	public void DestroyUI(){
		// to be used when switching to a stage that doesn't need a UI
		Destroy (this.gameObject);
	}

	public int GetWeapon(){
		return this.selectedWeapon;
	}

	public void DisplayCount(int num){
		Text count = GameObject.Find ("CountDownDisplay").gameObject.GetComponent<Text> ();
		if (num == -1) {
			count.text = "";
		} else {
			count.text = num.ToString ();
		}
	}
}


