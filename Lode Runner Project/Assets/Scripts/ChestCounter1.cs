using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCounter1 : MonoBehaviour {
	public GUIText scoreText;
	public GUIText youDied;

	[HideInInspector]
	public int score; public float timeLevel2;


	// Use this for initialization
	void Start () {
		//score1 = PlayerPrefs.GetInt("score");
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//scoreText.text =  "POINTS:  " + score1;
		scoreText.text = score + " / 6";
		youDied.text =  "YOU DIED";

		timeLevel2 = Time.timeSinceLevelLoad;
		int timeLevel2int = Mathf.RoundToInt (timeLevel2); 
		PlayerPrefs.SetInt ("timeLevel2", timeLevel2int);
	}



}
