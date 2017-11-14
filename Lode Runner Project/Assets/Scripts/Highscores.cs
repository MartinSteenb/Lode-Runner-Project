using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscores : MonoBehaviour {
	public GUIText score;
	public GUIText highscore;

	// Use this for initialization
	void Start () {
		theScore ();
		highscore.text = PlayerPrefs.GetInt ("Highscore", 0).ToString(); //Sets highscore default to 0
	}

	public void theScore () {
		int number1 = PlayerPrefs.GetInt("score2");
		int timeLevel1 = PlayerPrefs.GetInt("timeLevel1");
		int timeLevel2 = PlayerPrefs.GetInt("timeLevel2");
		int timeLevel3 = PlayerPrefs.GetInt("timeLevel3");

		int totalTime = timeLevel1 + timeLevel2 + timeLevel3;
		int finalScore = number1 / totalTime;
		score.text = "" + finalScore;

		//Sets highscore if score > current highscore
		if (finalScore > PlayerPrefs.GetInt ("Highscore", 0)) {
			PlayerPrefs.SetInt ("Highscore", finalScore);
			highscore.text = finalScore.ToString ();
		}

	}



}
