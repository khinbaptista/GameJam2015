using UnityEngine;
using System.Collections;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MovementAI : MonoBehaviour {
	// 1 - Designer variables

	public float moveSpeed;
	public float maxDistance;
	public float minDistance;
	public Transform target;
	public Animator animator;
	public EnemyAttack attack;
	public bool facingRight = false;
	private bool _isGrounded = false;

	public bool isGrounded {
		get { return _isGrounded; }
		set { _isGrounded = value; }
	}

	void Start () {
		target = GameObject.Find("Character").transform;
		animator = GetComponentInChildren<Animator> ();
		attack = GetComponent<EnemyAttack>();
	}
	
	void Update() {
		float distance = Vector3.Distance (target.position, transform.position);
		if (distance > maxDistance && distance < minDistance) {
			// Get a direction vector from us to the target
			Vector3 dir = target.position - transform.position;
			
			// Normalize it so that it's a unit direction vector
			dir.Normalize ();


			if (dir.x > 0 && !facingRight)
				Flip ();
			else if (dir.x < 0 && facingRight)
				Flip ();

			// Move ourselves in that direction
			transform.position += dir * moveSpeed * Time.deltaTime;
			animator.SetBool ("Walk", true);
		} else if (distance < maxDistance) {
			animator.SetBool ("Walk", false);
			attack.AttackStart ();
		} else {
			animator.SetBool ("Walk", false);
		}
	}
	


	void Flip ()
	{
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}