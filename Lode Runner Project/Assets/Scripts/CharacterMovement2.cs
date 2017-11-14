using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement2: MonoBehaviour {

	public float speed; // Character movement speed
	public float jumpPower;
	public int endScore;
	public bool grounded;
	public bool enabled;
	public bool allowSlash;
	public bool play = false;
	public GUIText hundred;

	public Transform attackPoint;
	public GameObject slash;

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
	private Ladder ladder10;
	private Ladder ladder11;
	private Ladder ladder12;
	private Ladder ladder13;

	[HideInInspector]
	public ChestCounter2 chestCounter2; public ChestCounter youDied; public EndLadder endLadder; public ManageScenes sceneManager; public CheckPoint checkPoint;

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

		chestCounter2 = GameObject.Find ("Score Text").GetComponent<ChestCounter2> ();
		youDied = GameObject.Find ("YOUDIED").GetComponent<ChestCounter> ();
		hundred = GameObject.Find("100").GetComponent<GUIText> ();
		checkPoint = GameObject.Find("Block").GetComponent<CheckPoint> ();

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
		ladder10 =  GameObject.Find("ladder10").GetComponent<Ladder> ();
		ladder11 =  GameObject.Find("ladder11").GetComponent<Ladder> ();
		ladder12 =  GameObject.Find("ladder12").GetComponent<Ladder> ();
		ladder13 =  GameObject.Find("ladder13").GetComponent<Ladder> ();

		hitt_animation = GetComponent<Animation> ();
		Time.timeScale = 1f;
		endScore = 0;
		allowSlash = true;
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
			//rb.AddForce (transform.up * jumpPower);
			rb.velocity = new Vector2 (rb.velocity.x, jumpPower);
			grounded = false;
			//sDebug.Log ("hi");

		}

		//Walking,jumping and climbing animations
		if (ladder.climbing || ladder1.climbing || ladder2.climbing || ladder3.climbing || ladder4.climbing || ladder5.climbing || ladder6.climbing || ladder7.climbing || ladder8.climbing || ladder9.climbing || ladder10.climbing || ladder11.climbing || ladder12.climbing || ladder13.climbing) {
			animator.SetInteger ("Direction", 2);
		} else if (ladder.climbing == false) {
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

		//Attacking
		if (Input.GetKeyDown (KeyCode.RightControl) && allowSlash) {
			StartCoroutine (Slash ());
		}

		//Respawn
		if (Input.GetKeyDown (KeyCode.R)) {
			transform.position = spawnPosition;
		}

		//End of level
		if (endScore == 12) {
			ladder7.endReached = true; 	
		}

		PlayerPrefs.SetInt ("score2", chestCounter2.score2);
		int x = PlayerPrefs.GetInt ("score2");
		print (x);
	}









	void OnTriggerStay2D (Collider2D other) {
			
		if (other.name == "Boss") {
			StartCoroutine (Hitt_animation_routine ());
		}

		if (other.name == "flower") {
			checkPoint.startBossFight = true;
		}

		if (other.gameObject.tag == "Finish") {
			Application.LoadLevel ("Highscores");
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
		Application.LoadLevel ("3Hard");
	}

	public IEnumerator Slash() {
		allowSlash = false;
		Instantiate (slash, attackPoint.position, attackPoint.rotation);
		yield return new WaitForSeconds (2);
		allowSlash = true;
	}
}





