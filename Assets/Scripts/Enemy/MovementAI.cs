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

	private Enemy enemy;
	private CliffDetection cliff;

	public bool isGrounded {
		get { return _isGrounded; }
	}

	void Start () {
		target = GameObject.Find("Character").transform;
		animator = GetComponentInChildren<Animator> ();
		attack = GetComponent<EnemyAttack>();

		enemy = GetComponent<Enemy>();

		cliff = GetComponentInChildren<CliffDetection>();
		if (cliff == null)
			Debug.Log("Cliff Detection not found");
	}
	
	void Update() {
		if (enemy.IsDead)
			return;
	    if (attack.IsAttacking)
	        return;
	    if (target.GetComponent<Player>().IsDead)
	        return;

		float distance = Vector3.Distance (target.position, transform.position);
		if (distance > maxDistance && distance < minDistance) {
			Vector3 dir = target.position - transform.position;
			dir.Normalize();

			if (dir.x > 0 && !facingRight)
				Flip();
			else if (dir.x < 0 && facingRight)
				Flip();

			// Move towards player
			if (!cliff.isNearCliff) {
				transform.position += dir * moveSpeed * Time.deltaTime;
				animator.SetBool("Walk", true);
			}
			else
				animator.SetBool("Walk", false);
		}
		else {
			animator.SetBool("Walk", false);

			if (distance < maxDistance)
				attack.AttackStart ();
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