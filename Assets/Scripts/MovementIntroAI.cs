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
        
        
    }

    void OnEnable()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance>1)
        {
            Vector3 dir = target.position - transform.position;
            dir.Normalize();
            transform.position += dir * moveSpeed * Time.deltaTime;
            animator.SetFloat("Speed", 0.4f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);

            
        }
        if (animator.GetFloat("Speed") == 0f)
        {
            GetComponentInChildren<MovementIntroAI>().enabled = false;

        }
    }

    void lookAtTarget()
    {
        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime*1);
    }

    void Flip()
    {
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);

        if (col.gameObject.name == "Savior")
        {

            GetComponentInChildren<MovementIntroAI>().enabled = false;
        }
        
    }

}