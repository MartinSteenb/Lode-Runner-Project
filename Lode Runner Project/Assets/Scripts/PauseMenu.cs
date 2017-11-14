using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public Canvas pauseMenu;

	// Use this for initialization
	void Start () {
		pauseMenu.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			Time.timeScale = 0;
			pauseMenu.enabled = true;
		}
	}

	public void resume () {
		pauseMenu.enabled = false;
		Time.timeScale = 1;
	}

	public void mainMenu () {
		Application.LoadLevel ("Main Menu");
		Time.timeScale = 1;
	}
}
