using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour {

	Vector3 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject King;

	public bool bounds;

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	// Use this for initialization
	void Start () {
		King = GameObject.Find ("King");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float posX = Mathf.SmoothDamp (transform.position.x, King.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, King.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);

		if (bounds) {
			Debug.Log ("true");
			transform.position = new Vector3 (	Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x),
												Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y),
												Mathf.Clamp (transform.position.z, minCameraPos.z, maxCameraPos.z));
		}
	
	}
}
