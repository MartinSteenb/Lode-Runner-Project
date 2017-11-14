using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public bool bounds;

	public GameObject King;

	public float smoothTimeY;
	public float smoothTimeX;

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;
	Vector3 velocity;

	// Use this for initialization
	void Start () {
		King = GameObject.Find ("King");

		Screen.SetResolution (1360, 720, false);
	}

	// Update is called once per frame
	void LateUpdate () {
		float posX = Mathf.SmoothDamp (transform.position.x, King.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, King.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);

		if (bounds) {
			transform.position = new Vector3 (	Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x),
				Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp (transform.position.z, minCameraPos.z, maxCameraPos.z));
		}

	}
}
