// NOT CURRENTLY USED, used to generate real time menu buttons.
//Attached to Main Camera

//THINGS TO ADD
// -- level select
// -- some save / Continue function

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// creates Background Texture field
	// drag and drop background image from textures to Main Camera of the scene to change the background of the menu
	public Texture backgroundTexture;
	//OPTIONS
	// 1 -- replace default buttons
	// get rid of outline, replaces button with texture (can be anything), add r1 to GUI.Button in the if statement and leave as empty string or it'll look for style under the string name
	// texture results in a compressed image, use 
	//public Texture r1;
	// use GUIStyle instead, change order of string and r2. GUISTYLE will be stretched to size of button -- normal -- background
	//public GUIStyle r2;

	//allow adjustment of horizontal position
	// default value used before: .375f
	public float guiPositionX1;
	public float guiPositionX2;
	public float guiPositionX3;
	public float guiPositionX4;
	//allow adjustment of vertical position -- recommended settings : new Rect (Screen.width * .375f, Screen.height * .7f, Screen.width * .25f, Screen.height * .1f)
	// default from before: .5f, .6f, .7f, .8f
	public float guiPositionY1;
	public float guiPositionY2;
	public float guiPositionY3;
	public float guiPositionY4;

	void OnGUI(){

		//display the background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);

		//display the buttons
		// first 2 inputs of Rect are positions, next 2 are size. always relative sizes
		if (GUI.Button (new Rect (Screen.width * guiPositionX1, Screen.height * guiPositionY1, Screen.width * .25f, Screen.height * .1f), "New Game")) {
			// start a new game
			print ("starting a new game");
		}
		if (GUI.Button (new Rect (Screen.width * guiPositionX2, Screen.height * guiPositionY2, Screen.width * .25f, Screen.height * .1f), "HighScore")) {
			// display the scores
			print ("opening highscore");
		}
		if (GUI.Button (new Rect (Screen.width * guiPositionX3, Screen.height * guiPositionY3, Screen.width * .25f, Screen.height * .1f), "Options")) {
			// show the options menu
			print ("opening options");
		}

		//display button without GUIoutline
		if (GUI.Button (new Rect (Screen.width * guiPositionX4, Screen.height * guiPositionY4, Screen.width * .25f, Screen.height * .1f), "Exit Game")) {
			// quit the game
			print ("closing the game");
			Application.Quit ();
		}
	}

	//index in build settings of level you want to load
//	public void LoadScene (int level)
//	{
//		Application.LoadLevel (level);
//	}
}
