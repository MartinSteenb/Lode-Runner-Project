using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour {

	public void LoadDifficulty () {
		Application.LoadLevel ("Difficulty");
	}

	public void ExitGame () {
		Application.Quit ();
	}

	public void Back () {
		Application.LoadLevel ("Main Menu");
	}

	public void Easy () {
		Application.LoadLevel ("1Easy");
	}

	public void Medium () {
		Application.LoadLevel ("1Medium");
	}

	public void Hard () {
		Application.LoadLevel ("1Hard");
	}

	public void Highscores () {
		Application.LoadLevel ("Highscores");
	}

	public void Ladders () {
		Application.LoadLevel ("Ladders");
	}
}
