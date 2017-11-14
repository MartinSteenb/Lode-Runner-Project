using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreenTrigger : MonoBehaviour {

	public GameObject target;
	public GameObject enemy;
	public bool enemyTrigger;
	public EnemyGreen enemyGreen;


	void Start () {
		target = GameObject.Find ("King");
		enemyGreen = enemy.GetComponent<EnemyGreen> ();
		enemyTrigger = false;
	}

	void Update () {
		if (enemyTrigger) {
			enemyGreen.chasePlayer ();
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject == target) {
			enemyTrigger = true;
			enemyGreen.patrolling = false;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject == target) {
			enemyTrigger = false;
			enemyGreen.patrolling = true;
		}
	}
}