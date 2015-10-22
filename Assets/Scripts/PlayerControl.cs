using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool firstJump = false;				// Condition for whether the player should jump.
	public bool secondJump = false;
	public bool canSecondJump = true;
    private float h;
    private float speed;
	public float moveForce = 0.1f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 3f;				// The fastest the player can travel in the x axis.
	public float jumpForce = 100f;			// Amount of force added when the player jumps.
	
	
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.

	private Animator animator;                  // Reference to the player's animator component.
	private Rigidbody2D rigidbody2d;
	private Player playerHealth;
	
	void Awake()
	{
		// Setting up references.
		animator = GetComponent<Animator>();
		rigidbody2d = GetComponent<Rigidbody2D>();
		playerHealth = GetComponent<Player>();
	}
	
	
	void Update()
	{
        
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        // Cache the horizontal input.
        h = Input.GetAxis("Horizontal");
        // The Speed animator parameter is set to the absolute value of the horizontal input.
        animator.SetFloat("Speed", speed);


        

        // If the player should jump...

        // If the jump button is pressed and the player is grounded then the player should jump.
        if (Input.GetButtonDown("Jump") && grounded)
			firstJump = true;
		if (Input.GetButtonDown ("Jump") && !grounded && canSecondJump) {
			secondJump = true;
			canSecondJump = false;
		}

		if (grounded && !canSecondJump) {
			canSecondJump = true;
		}

        if (firstJump)
        {
            // Set the Jump animator trigger parameter.
            makeJump();

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            firstJump = false;
        }
        else if (secondJump)
        {
            makeJump();
            secondJump = false;
        }
    }
	
	
	void FixedUpdate ()
	{
        speed = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);
        
        // If the input is moving the player right and the player is facing left...
        if (h > 0 && !facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (h < 0 && facingRight)
            // ... flip the player.
            Flip();

        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        //rigidbody2d.velocity = Vector2.right * h * moveForce;

        if (h > 0 || 0 > h)
        {
            Vector2 currentY = Vector2.zero;
            currentY.y = rigidbody2d.velocity.y;
            rigidbody2d.velocity = (Vector2.right * h * moveForce) + currentY;
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
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
        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
    }	

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            grounded = true;
            animator.SetBool("Grounded", true);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            grounded = false;
            animator.SetBool("Grounded", false);
        }
    }

}
		