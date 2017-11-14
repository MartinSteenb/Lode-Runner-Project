using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {

	public GameObject target;
	public GameObject enemy;
	public bool enemyTrigger;
	public EnemyWorm enemyWorm;


	void Start () {
		target = GameObject.Find ("King");
		enemyWorm = enemy.GetComponent<EnemyWorm> ();
		enemyTrigger = false;
	}

	void Update () {
		if (enemyTrigger) {
			enemyWorm.chasePlayer ();
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject == target) {
			enemyTrigger = true;
			enemyWorm.patrolling = false;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject == target) {
			enemyTrigger = false;
			enemyWorm.patrolling = true;
		}
	}
}
