using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.Collections.Generic;

public class UIControl : MonoBehaviour {
	// names for playerprefs

	// use string name of checkpoint for level restart

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

	// for gunfill
	public Slider gunSlider;
	public Image gunFill;

	public RawImage statsui;
	public RawImage healthback;
	public RawImage statsbar;


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

		// get the current weapon
		selectedWeapon = 0;
		// not needed
//		else {
//			//selectedWeapon = gun1;
//		}

		// ChangeWeapon (0); only needed for dynamic array

		healthBar = GameObject.FindGameObjectWithTag ("HealthUI");
		score = GameObject.FindGameObjectWithTag ("ScoreUI").gameObject.GetComponent<Text>();

		if (PlayerPrefs.HasKey ("PlayerScore")) {
			score.text = PlayerPrefs.GetInt ("PlayerScore").ToString ();
		} else {
			score.text = "0000";
		}

		//preserve the instance throughout scene change
		DontDestroyOnLoad(this.gameObject);
	}

	void Start(){
		statsui = GameObject.FindGameObjectWithTag ("StatsUI").gameObject.GetComponent<RawImage>();
		healthback = GameObject.FindGameObjectWithTag ("HealthBack").gameObject.GetComponent<RawImage>();
		statsbar = GameObject.FindGameObjectWithTag ("StatsBar").gameObject.GetComponent<RawImage>();
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
			ammo = ammo / 2;
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
		if (choice < 0 || choice >= allWeapons.Length) {
			return false;
		}
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

	// use this to calculate damage (-ve values) or healing (+ve values)
	public void AdjustHealth (float amount) {
		float newHealth = GetHealth () + amount;
		if (newHealth < 0f) {
			newHealth = 0f;
		} else if (newHealth > 100f) {
			newHealth = 100f;
		}
		healthBar.GetComponent<Slider> ().value = newHealth;
	}

	// use this to quickly set health to a specific value at beginning of rounds, or whereever necessary
	// becareful to only use legal values
	public void SetHealth (float value){
		healthBar.GetComponent<Slider> ().value = value;
	}

	public float GetHealth (){
		return healthBar.GetComponent<Slider> ().value;
	}

	public bool PlayerIsDead (float damage){
		AdjustHealth (damage);
		if (GetHealth() == 0f) {
			return true;
		}
		return false;
	}

	public void AddScore (int s){
		try{
			int currValue = int.Parse(score.text);
			score.text = (currValue + s).ToString();
		}catch{
			print ("Could not ADD to score");
		}
	}

	public void SetScore (int newS){
		try {
			score.text = newS.ToString ();
		} catch{
			print ("Could not SET score");
		}
	}

	public string GetScore (){
		return score.text;
	}

	public void SaveToScores (){
		// not a pretty method, hopefully will improve later
		string s = PlayerPrefs.GetString (GameController.Instance.allScores);
		string[] all = s.Split (new string[] {"\n"}, System.StringSplitOptions.None);
		List<int> intScores = new List<int>();
		int currScore;
		try {
			currScore = int.Parse(score.text);
		}catch{
			print ("could not fetch score");
			return;
		}
		foreach (string v in all){
			if (v == "") {
				continue;
			}
			intScores.Add (int.Parse (v));
		}

		intScores.Add (currScore);

		intScores.Sort ();
		intScores.Reverse ();

		var builder = new StringBuilder ();
		intScores.ForEach (x => builder.Append (x+"\n"));
		var res = builder.ToString ();

		PlayerPrefs.DeleteKey (GameController.Instance.allScores);
		PlayerPrefs.SetString (GameController.Instance.allScores, res);


		//Array.Sort
		//allScores.Split ('\n');
	}

	public void SaveGameStateUI(){
		// save ammo
		for (int i = 0; i < allWeapons.Length; i++) {
			string name = allWeapons [i].gameObject.name;
			if (name == "Gun1"){ continue; }
			string ammo = allWeapons [i].gameObject.GetComponentInChildren<Text> ().text;
			PlayerPrefs.SetString (name, ammo);
		}

		// rest of stuff
		PlayerPrefs.SetInt (GameController.Instance.highscore, int.Parse(score.text));
		PlayerPrefs.SetFloat (GameController.Instance.health, GetHealth ());
		//print ("saving score: "+ PlayerPrefs.GetInt(GameController.Instance.highscore.ToString()));
		//print ("saving health: " + PlayerPrefs.GetFloat(GameController.Instance.health.ToString()));
	}

	public void LoadGameStateUI (){
		// load ammo
		for (int i = 0; i < allWeapons.Length; i++) {
			string name = allWeapons [i].gameObject.name;

			if (name == "Gun1"){ continue; }
			if (PlayerPrefs.HasKey (name)) {
				string ammo = PlayerPrefs.GetString (name);
				allWeapons [i].gameObject.GetComponentInChildren<Text> ().text = ammo;
				Debug.Log ("loading gun: " + name + " || with ammo: " + ammo);
			} else {
				print ("Could not find gun in PlayerPrefs: " + name);
			}
		}

		SetScore (PlayerPrefs.GetInt(GameController.Instance.highscore));
		SetHealth (PlayerPrefs.GetFloat(GameController.Instance.health));
		print ("Set score: " + PlayerPrefs.GetInt (GameController.Instance.highscore).ToString ());
		print ("set Health " + PlayerPrefs.GetFloat (GameController.Instance.health).ToString());
		// load the rest
	}

	public void DestroyUI(){
		// to be used when switching to a stage that doesn't need a UI
		Destroy (this.gameObject);
	}

	public int GetWeapon(){
		return this.selectedWeapon;
	}

	public void DisplayCount(float num){
		Text count = GameObject.Find ("CountDownDisplay").gameObject.GetComponent<Text> ();
		if (num == 0) {
			count.text = "";
		} else {
			count.text = num.ToString ();
		}
	}

	public bool IsOverheat (){
		if (gunSlider.value >= gunSlider.maxValue) {
			return true;
		}
		return false;
	}

	public bool IsGunZero (){
		if (gunSlider.value <= 0) {
			return true;
		}
		return false;
	}

	public void UpdateGunFill (float val){
		gunSlider.value += val;
		if (IsOverheat ()) {
			gunSlider.value = gunSlider.maxValue;
		} else if (IsGunZero ()) {
			gunSlider.value = 0;
		}

		// change color
		if (gunSlider.value < (gunSlider.maxValue / 3f)) {
			// cool
			gunFill.color = Color.blue;

		} else if (gunSlider.value < (gunSlider.maxValue / 1.5f)) {
			// warm
			gunFill.color = Color.yellow;

		} else {
			// hot
			gunFill.color = new Color(0.58f, 0.109f, 0.109f);
		}
	}

	public void FadeStats (){
		// normal Statsbar == 100, 5
		// HealthBack == 255, 5
		// StatsUI == 255, 10

		statsui.CrossFadeAlpha (.039f, .5f, false);
		healthback.CrossFadeAlpha (.019f, .5f, false);
		statsbar.CrossFadeAlpha (.019f, .5f, false);
	}

	public void UnFadeStats(){
		statsui.CrossFadeAlpha (1f, .5f, false);
		healthback.CrossFadeAlpha (1f, .5f, false);
		statsbar.CrossFadeAlpha (.8f, .5f, false);
	}

	public void DisableUI(){
		UICanvas.gameObject.SetActive (false);
	}

	public void EnableUI(){
		UICanvas.gameObject.SetActive (true);
	}
}


