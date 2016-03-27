using UnityEngine;
using System.Collections;

//It is common to create a class to contain all of your
//extension methods. This class must be static.
public static class ExtensionMethods
{
	//Even though they are used like normal methods, extension
	//methods must be declared static. Notice that the first
	//parameter has the 'this' keyword followed by a Transform
	//variable. This variable denotes which class the extension
	//method becomes a part of.

	public static GameObject FindObject(this GameObject parent, string name)
	{
		//finds an object inside of a parent.
		Component[] trs= parent.GetComponentsInChildren(typeof(Transform), true);
		foreach(Transform t in trs){
			if(t.name == name){
				return t.gameObject;
			}
		}
		return null;
	}

}

