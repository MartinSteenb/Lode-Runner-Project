using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderPagina : MonoBehaviour {

	private int ladderNumber;
	public GameObject l1;
	public GameObject l2;
	public GameObject l3;

	void Start () {
		l1.SetActive (true);
		l2.SetActive (false);
		l3.SetActive (false);
	}

	void Update () {
		
	}

	public void Ladder1Click () {
		l1.SetActive (true);
		l2.SetActive (false);
		l3.SetActive (false);
	}

	public void Ladder2Click () {
		l1.SetActive (false);
		l2.SetActive (true);
		l3.SetActive (false);
	}

	public void Ladder3Click () {
		l1.SetActive (false);
		l2.SetActive (false);
		l3.SetActive (true);
	}
}
