#pragma strict
var imageFolderName = "jpegs";
var MakeTexture = false;
var pictures = new Array();
var loop = false;
var counter = 0;
var Film = true;
var PictureRateInSeconds:float = 1/30f;
private var nextPic:float = 0;

function Start () {
 if(Film == true){
     PictureRateInSeconds = 1.0f/30.0f;
 }

 var textures : Object[] = Resources.LoadAll(imageFolderName);
 for(var i = 0; i < textures.Length; i++){
     Debug.Log("found");
     pictures.Add(textures[i]);
 }
}

function Update () {
// if(Time.time > nextPic){
     nextPic = Time.deltaTime + PictureRateInSeconds;
     counter += 1;
//     if(MakeTexture){
     GetComponent.<Renderer>().material.mainTexture = pictures[counter];
//         renderer.material.mainTexture = pictures[counter];
//     }
// }
 if(counter >= pictures.length){
     Debug.Log("fertig");
     if(loop){
//         counter = 0;
     }
 }
}