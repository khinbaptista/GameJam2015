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

	void Start () {
		target = GameObject.Find("hero").transform;
		animator = GetComponentInChildren<Animator> ();
	}
	
	void Update() {
		float distance = Vector3.Distance(target.position, transform.position);
		if (distance > maxDistance && distance < minDistance) {

			// Get a direction vector from us to the target
			Vector3 dir = target.position - transform.position;
			
			// Normalize it so that it's a unit direction vector
			dir.Normalize ();
			
			// Move ourselves in that direction
			transform.position += dir * moveSpeed * Time.deltaTime;
			animator.SetBool ("Walk", true);
		} else {
			animator.SetBool ("Walk", false);
		}
	}
}