using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public Transform target;
	public float speed = 0.001f;
	public GameObject Character;
	public bool onPathCheck = false;
	private Rigidbody2D rb;

	public MoveOnePath moveOnPath;



	// Use this for initialization
	void Start () {
		moveOnPath = GetComponent<MoveOnePath> ();
		moveOnPath.enabled = false;

		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!onPathCheck) {
			//rotate to look at the player
			transform.LookAt (target.position);
			transform.Rotate (new Vector2 (0, -90), Space.Self);//correcting the original rotation

			//lock the y-axis rotation (z is used in unity)
			transform.eulerAngles = new Vector2 (0, transform.eulerAngles.y);

			//move towards the player
			transform.Translate (new Vector2 (speed * Time.deltaTime, 0));

			/*if (Vector2.Distance(transform.position,target.position)>1f){//move if distance from target is greater than 1
			
		}*/

		}
	}

	/*void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "path_object") {
			Debug.Log ("1");
			onPathCheck = true;
			moveOnPath.enabled = true;
			rb.gravityScale = 0.0f;

		}
	}*/
}
