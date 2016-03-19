using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	private Slider health;

	void Start (){
		health = this.GetComponentInChildren <Slider> ();
	}

	public void TakeDamage (float amount){
		health.value += amount;
		if (health.value < 0f) {
			health.value = 0f;
		}
	}

	public bool EnemyIsDead (float damage){
		TakeDamage (damage);
		if (health.value == 0f) {
			return true;
		} 
		return false;
	}
}
