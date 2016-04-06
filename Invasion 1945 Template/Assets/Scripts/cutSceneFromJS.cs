using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


class cutSceneFromJS : MonoBehaviour {

	string imageFolderName = "jpegs";
	bool MakeTexture = false;
	public static ArrayList pictures = new ArrayList();
	bool loop = false;
	int counter = 0;
	bool Film = true;
	float PictureRateInSeconds = 1/30f;
	private float nextPic = 0;


	void Start () {
	 if(Film == true){
	     PictureRateInSeconds = 1.0f/40.0f;
	 }
		if (pictures.Count == 0) {
			Object[] textures = Resources.LoadAll(imageFolderName);
			for(var i = 0; i < textures.Length; i++){
				//Debug.Log("found");
				pictures.Add(textures[i]);
			}
		}

	}

	void Update () {
	// if(Time.time > nextPic){
	     nextPic = Time.deltaTime + PictureRateInSeconds;
	     counter += 1;
	//     if(MakeTexture){
		try{
			GetComponent<Renderer>().material.mainTexture = pictures[counter] as Texture;
		}catch{
			Debug.Log ("index error");
		}
//		gameObject.renderer.material.mainTexture = pictures[counter];
//	     GetComponent<Renderer>().material.mainTexture = pictures[counter];
	//         renderer.material.mainTexture = pictures[counter];
	//     }
	// }
		if(counter >= pictures.Count){
	     Debug.Log("fertig");
	     if(loop){
	//         counter = 0;
	     }
	 }
	}
}
