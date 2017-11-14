using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour {

	public void ReloadScene () {
		//int scene = SceneManager.GetActiveScene ().buildIndex;
		//SceneManager.LoadScene (scene, LoadSceneMode.Single);
		Debug.Log("RELOADSCENE");
	}

	public void LoadNextScene () {
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
