using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

	private float speed = 2f;
	public bool climbing;

	//public Transform startMarker;
	public Transform endMarker;
	private float startTime;
	private float journeyLength;
	public bool endReached;
	private float ladderSpeed = 0.1f;

	void Start() {
		endReached = false;
	}
	void Update() {
		if (endReached) {
			float step = ladderSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, endMarker.position, step);
		}
	}

	void OnTriggerStay2D(Collider2D other){
		//Debug.Log ("hit");
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S)) {
			climbing = true;
		} 

		if (climbing) {
			if (other.name == "King" && Input.GetKey (KeyCode.W)) {
				other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed);
				other.GetComponent<Rigidbody2D> ().gravityScale = 0;

			} else if (other.name == "King" && Input.GetKey (KeyCode.S)) {
				other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -speed);
				other.GetComponent<Rigidbody2D> ().gravityScale = 0;

			} else {
				other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				other.GetComponent<Rigidbody2D> ().gravityScale = 0;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		climbing = false;
		if (!climbing) {
			other.GetComponent<Rigidbody2D> ().gravityScale = 1;
			other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		}
	}
		
}
