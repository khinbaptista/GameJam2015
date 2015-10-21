using UnityEngine;
using System.Collections;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MovementIntroAI : MonoBehaviour
{
    // 1 - Designer variables

    public float moveSpeed;
    public float maxDistance;
    public float minDistance;
    public Transform target;
    public Animator animator;
    public EnemyAttack attack;
    public bool facingRight = false;
    private bool _isGrounded = false;
    

    public bool isGrounded
    {
        get { return _isGrounded; }
    }

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        
        
        Flip();

        MovementIntroAI mv = GetComponentInChildren<MovementIntroAI>();
        mv.enabled = false ;
    }

    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);
        if (transform.position != target.position)
        {
            Vector3 dir = target.position - transform.position;
            dir.Normalize();
            transform.position += dir * moveSpeed * Time.deltaTime;
            animator.SetFloat("Speed", 0.4f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);

            if (distance < maxDistance)
                attack.AttackStart();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}