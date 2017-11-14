using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : MonoBehaviour {

	public float speed;
	public CharacterMovement2 player;
	public EnemyAIScript boss;

	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<CharacterMovement2> ();
		boss = FindObjectOfType<EnemyAIScript> ();

		if (player.transform.rotation == Quaternion.Euler (0, 0, 0)) {
			rb.velocity = new Vector2 (speed, rb.velocity.y);
		} else if (transform.rotation != Quaternion.Euler (0, 0, 0)) {
			rb.velocity = new Vector2 (-speed, rb.velocity.y);
		}

	}

	void Update () {
		


	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.layer == 8 || other.gameObject.layer == 9) {
			Destroy (gameObject);
		}

		if (other.gameObject.layer == 9) {
			boss.bossHealth -= 1;
			Debug.Log (boss.bossHealth);
		}
	}
}
