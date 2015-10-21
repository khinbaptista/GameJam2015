﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool firstJump = false;				// Condition for whether the player should jump.
	public bool secondJump = false;
	public bool canSecondJump = true;
	
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	//public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.
	//public AudioClip[] taunts;				// Array of clips for when the player taunts.
	public float tauntProbability = 50f;	// Chance of a taunt happening.
	public float tauntDelay = 1f;			// Delay for when the taunt should happen.
	
	
	private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.

	private Animator animator;                  // Reference to the player's animator component.
	private Rigidbody2D rigidbody2d;
	private Player playerHealth;
	
	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		animator = GetComponent<Animator>();
		rigidbody2d = GetComponent<Rigidbody2D>();
		playerHealth = GetComponent<Player>();
	}
	
	
	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
		animator.SetBool ("Grounded", grounded);

		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetButtonDown("Jump") && grounded)
			firstJump = true;
		if (Input.GetButtonDown ("Jump") && !grounded && canSecondJump) {
			secondJump = true;
			canSecondJump = false;
		}

		if (grounded && !canSecondJump) {
			canSecondJump = true;
		}
	}
	
	
	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		animator.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
			// ... add a force to the player.
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		
		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();
		
		// If the player should jump...
		if(firstJump)
		{
			// Set the Jump animator trigger parameter.
			makeJump ();
				
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			firstJump = false;
		} 
		else if(secondJump)
		{
			makeJump ();
			secondJump = false;
		}
	}

	void LateUpdate() {
		if (playerHealth.IsDead)
			enabled = false;
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void makeJump ()
	{
		animator.SetTrigger ("Jump");
		
		// Play a random jump audio clip.
		//int i = Random.Range(0, jumpClips.Length);
		//AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);
		
		// Add a vertical force to the player.
		rigidbody2d.AddForce (new Vector2 (0f, jumpForce));
	}	

}
		