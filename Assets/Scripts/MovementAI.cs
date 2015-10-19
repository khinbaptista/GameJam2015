using UnityEngine;
using System.Collections;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MovementAI : MonoBehaviour {
	// 1 - Designer variables

	public float moveSpeed;
	public float maxDistance;
	public Transform target;

	void Start () {
		target = GameObject.Find("hero").transform;
	}
	
	void Update() {
		if (Vector3.Distance(target.position, transform.position) > maxDistance)
		{
			// Get a direction vector from us to the target
			Vector3 dir = target.position - transform.position;
			
			// Normalize it so that it's a unit direction vector
			dir.Normalize();
			
			// Move ourselves in that direction
			transform.position += dir * moveSpeed * Time.deltaTime;
		}
	}
}