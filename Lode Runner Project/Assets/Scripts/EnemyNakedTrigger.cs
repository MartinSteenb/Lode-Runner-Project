using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNakedTrigger : MonoBehaviour {

	public GameObject target;
	public GameObject enemy;
	public bool enemyTrigger;
	public EnemyNaked enemyNaked;


	void Start () {
		target = GameObject.Find ("King");
		enemyNaked = enemy.GetComponent<EnemyNaked> ();
		enemyTrigger = false;
	}

	void Update () {
		if (enemyTrigger) {
			enemyNaked.chasePlayer ();
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject == target) {
			enemyTrigger = true;
			enemyNaked.patrolling = false;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject == target) {
			enemyTrigger = false;
			enemyNaked.patrolling = true;
		}
	}
}