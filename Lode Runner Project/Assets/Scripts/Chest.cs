using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

	private Animator animator;

	private bool empty = false;
	private bool chestOpen = false;

	//public ChestCounter chestCounter;

	void Start () {
		animator = this.GetComponent<Animator> ();

	}

	void Update () {
		if (chestOpen && Input.GetKeyDown (KeyCode.E)) {
			animator.SetInteger ("State", 2);
		} 
	}


	void OnTriggerStay2D (Collider2D other) {
		if (other.name == "King") {
			animator.SetInteger ("State", 1);
			chestOpen = true;
			} 
		}

	void OnTriggerExit2D (Collider2D other) {
		if (!empty){
			animator.SetInteger ("State", 0);
			}
		}
}
