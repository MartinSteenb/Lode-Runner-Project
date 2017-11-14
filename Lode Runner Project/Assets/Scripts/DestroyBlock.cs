using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour {
	//RaycastHit2D hit;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetMouseButtonDown (1)) {
			
			Ray2D ray = Camera.main.ScreenPointToRay (Input.mousePosition);


			if (Physics2D.Raycast (ray, out hit)) {
				Destroy (hit.transform.gameObject);
				Debug.Log ("click");
			}
		}*/


		
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "King" && Input.GetButtonDown("Fire1")) {
			
				Debug.Log ("Click");
				//Destroy (gameObject);

		}
	}



}
