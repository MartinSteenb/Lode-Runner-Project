using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCounter : MonoBehaviour {
	public GUIText scoreText;
	public GUIText youDied;

	[HideInInspector]
	public int score; public float timeLevel1;

	void Start () {
		score = 0;
	}

	void Update () {
		scoreText.text = score + " / 6";
		youDied.text =  "YOU DIED";

		timeLevel1 = Time.timeSinceLevelLoad;
		int timeLevel1int = Mathf.RoundToInt (timeLevel1); 
		PlayerPrefs.SetInt ("timeLevel1", timeLevel1int);
	}



}
