using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnePath : MonoBehaviour {

	public EditorPath PathToFollow;
	public EnemyAI Enemy;

	public int CurrentWayPointID = 0;
	public float speed;
	private float reachDistance = 1.0f;
	public float rotationSpeed = 5.0f;
	public string pathName;
	private Rigidbody2D rb;

	private Vector2 last_position;
	private Vector2 current_position;

	// Use this for initialization
	void Start () {
		//PathToFollow = GameObject.Find (pathName).GetComponent<EditorPath> ();
		Enemy = GetComponent<EnemyAI> ();
		rb = GetComponent<Rigidbody2D> ();
		last_position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance (PathToFollow.path_objs [CurrentWayPointID].position, transform.position);
		transform.position = Vector2.MoveTowards (transform.position, PathToFollow.path_objs [CurrentWayPointID].position, Time.deltaTime * speed);

	
		if (distance <= reachDistance) {
			CurrentWayPointID++; 
		}

		if (CurrentWayPointID == 0) {
			transform.Rotate (new Vector2 (0, 180), Space.Self);
		}

		//End of the path
		if (CurrentWayPointID >= PathToFollow.path_objs.Count) {

			CurrentWayPointID = 0;
			//this.Enemy.moveOnPath.enabled = false;
			//Enemy.onPathCheck = false;
			//rb.gravityScale = 1.0f;
			//CurrentWayPointID = 0;
		}

	}
}
