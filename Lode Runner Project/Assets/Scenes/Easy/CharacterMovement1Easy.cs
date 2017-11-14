using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement1Easy : MonoBehaviour {

	public float speed; // Character movement speed
	public float jumpPower;
	public int endScore;
	public bool grounded;
	public bool enabled = false;
	public GUIText hundred;
	public bool play = false;
	public bool godMode = false;
	private bool speedLimitMin = false;
	private bool speedLimitMax = false;

	private Animator animator;
	private Rigidbody2D rb;	

	Vector2 spawnPosition;

	private Ladder ladder;
	private Ladder ladder1;
	private Ladder ladder2;
	private Ladder ladder3;
	private Ladder ladder4;
	private Ladder ladder5;
	private Ladder ladder6;
	private Ladder ladder7;
	private Ladder ladder8;
	private Ladder ladder9;

	[HideInInspector]
	public ChestCounter chestCounter; public ChestCounter youDied;  

	private bool inside1 = false;
	private bool inside2 = false;
	private bool inside3 = false;
	private bool inside4 = false;
	private bool inside5 = false;
	private bool inside6 = false;

	private Animation hitt_animation;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.freezeRotation = true;
		spawnPosition = transform.position;
		animator = this.GetComponent<Animator> ();
		StartCoroutine (ScoreText ());

		chestCounter = GameObject.Find ("Score Text").GetComponent<ChestCounter> ();
		youDied = GameObject.Find ("YOUDIED").GetComponent<ChestCounter> ();
		hundred = GameObject.Find("100").GetComponent<GUIText> ();

		ladder = GameObject.Find("ladder").GetComponent<Ladder> ();
		ladder1 =  GameObject.Find("ladder1").GetComponent<Ladder> ();
		ladder2 =  GameObject.Find("ladder2").GetComponent<Ladder> ();
		ladder3 =  GameObject.Find("ladder3").GetComponent<Ladder> ();
		ladder4 =  GameObject.Find("ladder4").GetComponent<Ladder> ();
		ladder5 =  GameObject.Find("ladder5").GetComponent<Ladder> ();
		ladder6 =  GameObject.Find("ladder6").GetComponent<Ladder> ();
		ladder7 =  GameObject.Find("ladder7").GetComponent<Ladder> ();
		ladder8 =  GameObject.Find("ladder8").GetComponent<Ladder> ();
		ladder9 =  GameObject.Find("ladder9").GetComponent<Ladder> ();

		hitt_animation = GetComponent<Animation> ();
		Time.timeScale = 1f;
		endScore = 0;
		speed = 2;
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		

		//Character Movement
		Vector3 move = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, 0); //GetAxis = smoothed output, GetAxisRaw = stop moving immediately after release
		transform.position += move * speed * Time.deltaTime;


		//Jumping
		if (!grounded && rb.velocity.y == 0) {
			grounded = true;
		}
			
		if (Input.GetKey (KeyCode.Space) && grounded) {
			rb.velocity = new Vector2(rb.velocity.x, jumpPower);
			grounded = false;
		}

		//Walking,jumping and climbing animations
		if (ladder.climbing || ladder1.climbing || ladder2.climbing || ladder3.climbing || ladder4.climbing || ladder5.climbing || ladder6.climbing || ladder7.climbing || ladder8.climbing || ladder9.climbing){
			animator.SetInteger ("Direction", 2);
		} else if (ladder.climbing == false || ladder1.climbing == false) {
			animator.SetInteger ("Direction", 3);
		} 

		//Walking rotation
		if (Input.GetKey (KeyCode.D)) {
			if (transform.rotation != Quaternion.Euler (0, 0, 0)) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
			}
		}

		if (Input.GetKey (KeyCode.A)) {
			if (transform.rotation != Quaternion.Euler (0, 180, 0)) {
				transform.rotation = Quaternion.Euler (0, 180, 0);
			}
		}

		//Respawn
		if (Input.GetKeyDown (KeyCode.R)) {
			transform.position = spawnPosition;
		}

		//End of level
		if (endScore == 6) {
			ladder7.endReached = true; 	
		}


		//GODMODE
		if (Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.O)) {
			godMode = true;
		}

		//TESTMODE
		if (Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.T)) {
			Destroy(GameObject.FindWithTag("EnemyWorm"));
		}

		//INCREASE DECREASE PLAYER SPEED
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.KeypadPlus)) {
			if (!speedLimitMax) {
				speed += 1;

				print (speed);
				if (speed >= 20) {
					speedLimitMax = true; 
				}
			}
		}

		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.KeypadMinus)) {
			if (!speedLimitMin) {
				speed += -1;

				print(speed);
				if (speed <= 1) {
					speedLimitMin = true; 
				}
			}
		
		}







		// Deletes chest and adds points to the counter


		if (inside1 && Input.GetKey (KeyCode.E)) {
			chestCounter.score += 1;
			GameObject.Find("100").GetComponent<GUIText> ().enabled = true;
			StartCoroutine (ScoreText ());
			Destroy (GameObject.FindWithTag("Chest1"));
			inside1 = false;
			endScore += 1;
		}
			
		if (inside2 && Input.GetKey (KeyCode.E)) {
			chestCounter.score += 1;
			GameObject.Find("100").GetComponent<GUIText> ().enabled = true;
			StartCoroutine (ScoreText ());
			Destroy (GameObject.FindWithTag("Chest2"));
			inside2 = false;
			endScore += 1;
		}

		if (inside3 && Input.GetKey (KeyCode.E)) {
			chestCounter.score += 1;
			GameObject.Find("100").GetComponent<GUIText> ().enabled = true;
			StartCoroutine (ScoreText ());
			Destroy (GameObject.FindWithTag("Chest3"));
			inside3 = false;
			endScore += 1;
		}

		if (inside4 && Input.GetKey (KeyCode.E)) {
			chestCounter.score += 1;
			GameObject.Find("100").GetComponent<GUIText> ().enabled = true;
			StartCoroutine (ScoreText ());
			Destroy (GameObject.FindWithTag("Chest4"));
			inside4 = false;
			endScore += 1;
		}

		if (inside5 && Input.GetKey (KeyCode.E)) {
			chestCounter.score += 1;
			GameObject.Find("100").GetComponent<GUIText> ().enabled = true;
			StartCoroutine (ScoreText ());
			Destroy (GameObject.FindWithTag("Chest5"));
			inside5 = false;
			endScore += 1;
		}

		if (inside6 && Input.GetKey (KeyCode.E)) {
			chestCounter.score += 1;
			GameObject.Find("100").GetComponent<GUIText> ().enabled = true;
			StartCoroutine (ScoreText ());
			Destroy (GameObject.FindWithTag("Chest6"));
			inside6 = false;
			endScore += 1;
		}

		PlayerPrefs.SetInt("score", chestCounter.score);
		int x = PlayerPrefs.GetInt ("score");
		print (x);
	}


	void OnTriggerStay2D (Collider2D other) {
		if (!godMode) {

			if (other.gameObject.tag == "EnemyWorm") {
				StartCoroutine (Hitt_animation_routine ());
			}

			if (other.name == "headCollider") {
				Destroy (GameObject.Find ("Enemy"));
			}

			if (other.name == "headCollider_1") {
				Destroy (GameObject.Find ("Enemy_1"));
			}

			if (other.name == "headCollider_2") {
				Destroy (GameObject.Find ("EnemyNaked"));
			}

			if (other.name == "headCollider_3") {
				Destroy (GameObject.Find ("Enemy_2"));
			}

			if (other.name == "headCollider_4") {
				Destroy (GameObject.Find ("Enemy_3"));
			}

			if (other.name == "headCollider_5") {
				Destroy (GameObject.Find ("Enemy_4"));
			}

			if (other.name == "bat") {
				StartCoroutine (Hitt_animation_routine ());
			}
		}
		if (other.gameObject.tag == "Chest1") {
			inside1 = true; 
			Debug.Log ("Chest1");
		} 

		if (other.gameObject.tag == "Chest2") {
			inside2 = true; 
			Debug.Log ("Chest2");
		} 

		if (other.gameObject.tag == "Chest3") {
			inside3 = true; 
			Debug.Log ("Chest3");
		} 

		if (other.gameObject.tag == "Chest4") {
			inside4 = true; 
			Debug.Log ("Chest4");
		} 

		if (other.gameObject.tag == "Chest5") {
			inside5 = true; 
			Debug.Log ("Chest5");
		} 

		if (other.gameObject.tag == "Chest6") {
			inside6 = true; 
			Debug.Log ("Chest6");
		} 

		if (other.gameObject.tag == "Finish") {
			Application.LoadLevel ("2Easy");
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		inside1 = false;
		inside2 = false;
		inside3 = false;
		inside4 = false;
		inside5 = false;
		inside6 = false;
	}

	private IEnumerator ScoreText() {
		yield return new WaitForSeconds (2);
		GameObject.Find("100").GetComponent<GUIText> ().enabled = false;
	}
		
	private IEnumerator Hitt_animation_routine() {
		GameObject.Find("YOUDIED").GetComponent<GUIText> ().enabled = true;

		Time.timeScale = 0;
		float pauseEndTime = Time.realtimeSinceStartup + 1;
		while (Time.realtimeSinceStartup < pauseEndTime) {
			yield return 0;
		}

		Time.timeScale = 1f;
		yield return new WaitForSeconds (0.05f);
		Time.timeScale = 1f;
		Application.LoadLevel ("1Easy");
	}
}





