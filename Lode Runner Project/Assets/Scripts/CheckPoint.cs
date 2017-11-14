using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	public Transform endMarker;
	public GameObject boss;

	public bool checkpointReached;
	private float checkpointSpeed;

	public bool startBossFight;
	private float platformSpeed;

	void Start () {
		checkpointReached = false;
		checkpointSpeed = 0.5f;

		startBossFight = false;
		platformSpeed = 0.8f;
	}

	void Update () {
		if (checkpointReached) {
			float step = checkpointSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, endMarker.position, step);
		}

		if (startBossFight) {
			float step = platformSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, endMarker.position, step);

			if (transform.position == endMarker.position) {
				boss.SetActive (true);
			}
		}
	}
}
