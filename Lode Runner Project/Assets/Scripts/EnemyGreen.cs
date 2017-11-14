using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreen : MonoBehaviour {

	public Transform target;

	public GameObject g_patrolBlock;
	public GameObject g_patrolBlock1;

	private float speed;
	public bool moveRight;
	public bool patrolling;

	void Start () {
		moveRight = true;
		patrolling = true;
	}


	void Update () {

		if (patrolling) {
			speed = 2;

			if (moveRight) {
				transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
			} else if (!moveRight) {
				transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
			}
		}

	}

	public void chasePlayer () {
		speed = 2.3f;

		transform.LookAt (target.position);
		transform.Rotate (new Vector2 (0, -90), Space.Self);

		//lock the y-axis rotation (z is used in unity)
		transform.eulerAngles = new Vector2 (0, transform.eulerAngles.y);

		//move towards the player
		transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject == g_patrolBlock) {
			moveRight = true;
			Flip ();
		}

		if (other.gameObject == g_patrolBlock1) {
			moveRight = false;
			Flip ();
		}
	}

	public void Flip () {
		transform.Rotate (new Vector2 (0, 180), Space.Self);
	}
}
