using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GUI_Scrolling_Text : MonoBehaviour {
	public Font myFont;
	public TextAsset[] txtArr;
	public string nxtScene = "MainMenub";
	public Texture2D fadeTexture;
	public float scrollTimer = 85.0f;
	AsyncOperation async;
	private bool oneLoad = false;
	private float alpha = 0.0f;
	private bool keyPress = false;

	private bool isCreditsLoaded = false;
	private string currScene;

	void Start(){
		try{
			UIControl.Instance.DisableUI();
		}catch{
			Debug.Log ("credits could not disable UI");
		}

		try{
			if (currScene == "Credits"){
				isCreditsLoaded = true;
			}
		}catch{
			Debug.Log ("Error getting currscene name in GUI Scrolling");
		}
				
				
	}

	void OnGUI () {
		currScene = SceneManager.GetActiveScene ().name;
		if (oneLoad == false) { 
			StartCoroutine ("load");
			oneLoad = true;
		}
		if (Input.anyKey && keyPress == false) {
			keyPress = true;
			if ((scrollTimer - 5.5f) > 0) {
				scrollTimer = 0.0f;
			}
		}
			
		if (currScene != "Credits" || isCreditsLoaded) {
			//string txtFile = "Text/" + txtArr[0];
			//Debug.Log (txtFile);
			//TextAsset txt = Resources.Load("Text/IntroText") as TextAsset;
			string text = txtArr [0].ToString ();
			//string text = "Some long text ahdasd asghdgash gashdgahsgd hasgdh agh ash dahsg dahsgd ahsd hasgd hasgd hasg dhgahsdhasg dhasgd has gdhgashd sahdgajdasj gjhsdgajgd jasgd jhasgjd agsjd agsjhd gasjhdg jhsagd jahsgd jasgd jhasgjdh gasjhd gaj a dhsgajhd gajsgd jahsg djasgd jhasgdjsahg jahsgdjahg jdagsjd gasjhd gausydtguaysgujasgd jhagsd jhgasjdh gajdgajsgdjahgd jashgd ajsgduaystgd asgd jahsgd jahgsd jahsgdjhagsjhdasg ahsg djh";
			var centeredStyle = GUI.skin.GetStyle ("Label");
			centeredStyle.alignment = TextAnchor.UpperCenter;
			centeredStyle.fontSize = 30;
			//Font myFont = (Font)Resources.Load ("Fonts/Stjldbl1", typeof(Font));
			centeredStyle.font = myFont;
			centeredStyle.normal.textColor = Color.black;
			//GUI.Label (new Rect (Screen.width/2-50, Screen.height/2-25, 100, 50), "BLAH", centeredStyle);
			//GUI.Label (new Rect (0, Screen.height/2-22 - (Time.time*2), Screen.width, 5000), text, centeredStyle);
			DrawOutline (new Rect (0, Screen.height / 2 + 415 - (Time.time * 65), Screen.width, 5000), text, centeredStyle, Color.yellow); 
			scrollTimer -= Time.deltaTime; 
			if (scrollTimer < 0.0f || keyPress == true) {
				//alpha += -1.0f * 0.2f * Time.deltaTime;
				//alpha = Mathf.Clamp01 (alpha);
				alpha += Mathf.Clamp01 (Time.deltaTime / 5);
				GUI.color = new Color (0, 0, 0, alpha);
				//GUI.depth = -1000;
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeTexture);
				AudioListener.volume -= Mathf.Clamp01 (AudioListener.volume / 75);
				if (scrollTimer < -5.5f) {
					
					AudioListener.volume = 1;
					try{
						UIControl.Instance.EnableUI();
					}catch{
						Debug.Log ("Error enabling UI");
					}
					async.allowSceneActivation = true;
				}
				//SceneManager.LoadScene (nxtScene);
			}
		} else {
			try{
				isCreditsLoaded = GameController.Instance.isCreditsLoaded;
			} catch {
				Debug.Log ("error getting credits bool from gamecontroller");
			}
		}

	}

	public static void DrawOutline (Rect position, string text, GUIStyle style, Color outColor) {
		// Function used for drawning an outline around the story text
   		var backupStyle = style;
    	var oldColor = style.normal.textColor;
   		style.normal.textColor = outColor;
    	position.x--;
    	GUI.Label(position, text, style);
    	position.x +=2;
    	GUI.Label(position, text, style);
    	position.x--;
    	position.y--;
    	GUI.Label(position, text, style);
    	position.y +=2;
    	GUI.Label(position, text, style);
    	position.y--;
    	style.normal.textColor = oldColor;
    	GUI.Label(position, text, style);
    	style = backupStyle;    
	}

	IEnumerator load() {
		async = SceneManager.LoadSceneAsync (nxtScene);
		async.allowSceneActivation = false;
		yield return async;
	}
}