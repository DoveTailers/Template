using UnityEngine;
using System.Collections;

public class Boss_Astorid_Script : MonoBehaviour {
    public float spinspeed = 0;
	// Use this for initialization
	void Start () {        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, spinspeed) * Time.deltaTime);
    }

}
