using UnityEngine;
using System.Collections;

public class BossDeath : MonoBehaviour {

	private Enemy enemy;
	private Rigidbody2D rigidbody2d;
	private MovementAI movement;

	private bool ended = false;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Enemy> ();
		rigidbody2d = GetComponent<Rigidbody2D>();
		movement = GetComponent<MovementAI> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy.IsDead && !ended) {
			if(movement.facingRight)
				rigidbody2d.velocity = new Vector2 (-7, 0);
			else
				rigidbody2d.velocity = new Vector2 (7, 0);
		}
	}

	public void EndDeath() {
		rigidbody2d.velocity = new Vector2 (0, 0);
		ended = true;
	}
}
