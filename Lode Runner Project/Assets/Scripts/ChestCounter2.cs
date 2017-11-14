using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCounter2 : MonoBehaviour {
	public GUIText scoreText;
	public GUIText youDied;

	[HideInInspector]
	public int score2; public float timeLevel3;


	// Use this for initialization
	void Start () {
		score2 = PlayerPrefs.GetInt("score1");
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text =  "POINTS:  " + score2;
		youDied.text =  "YOU DIED";

		timeLevel3 = Time.timeSinceLevelLoad;
		int timeLevel3int = Mathf.RoundToInt (timeLevel3); 
		PlayerPrefs.SetInt ("timeLevel3", timeLevel3int);
	}



}
