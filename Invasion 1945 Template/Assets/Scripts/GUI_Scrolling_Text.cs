using UnityEngine;
using System.Collections;

public class GUI_Scrolling_Text : MonoBehaviour {
	public Font myFont;
	void OnGUI () {
		TextAsset txt = (TextAsset)Resources.Load("Text/IntroText", typeof(TextAsset));
		string text = txt.text;
		//string text = "Some long text ahdasd asghdgash gashdgahsgd hasgdh agh ash dahsg dahsgd ahsd hasgd hasgd hasg dhgahsdhasg dhasgd has gdhgashd sahdgajdasj gjhsdgajgd jasgd jhasgjd agsjd agsjhd gasjhdg jhsagd jahsgd jasgd jhasgjdh gasjhd gaj a dhsgajhd gajsgd jahsg djasgd jhasgdjsahg jahsgdjahg jdagsjd gasjhd gausydtguaysgujasgd jhagsd jhgasjdh gajdgajsgdjahgd jashgd ajsgduaystgd asgd jahsgd jahgsd jahsgdjhagsjhdasg ahsg djh";
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		centeredStyle.fontSize = 40;
		//Font myFont = (Font)Resources.Load ("Fonts/Stjldbl1", typeof(Font));
		centeredStyle.font = myFont;
		centeredStyle.normal.textColor = Color.black;
		//GUI.Label (new Rect (Screen.width/2-50, Screen.height/2-25, 100, 50), "BLAH", centeredStyle);
		//GUI.Label (new Rect (0, Screen.height/2-22 - (Time.time*2), Screen.width, 5000), text, centeredStyle);
		DrawOutline(new Rect (0, Screen.height/2+432 - (Time.time*75), Screen.width, 5000), text, centeredStyle, Color.yellow); 

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

}