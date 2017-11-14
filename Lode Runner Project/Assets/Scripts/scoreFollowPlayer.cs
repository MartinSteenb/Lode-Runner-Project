using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreFollowPlayer : MonoBehaviour {

	public Transform target;
	public GUIText debugGUIText;

	// Use this for initialization
	void Start () {
		
	}
	
	// LateUpdate is called after Update each frame
	void LateUpdate () {
		debugGUIText.transform.position = UnityEngine.Camera.main.WorldToViewportPoint(target.position);
	}
}
