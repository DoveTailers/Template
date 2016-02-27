using UnityEngine;
using System.Collections;

public class OuterBoundDestory_Wave : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}
}
