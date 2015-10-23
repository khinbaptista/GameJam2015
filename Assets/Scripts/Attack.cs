using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
	private bool isAttacking = false;
	private Animator animator;

	public Collider2D areaOfEffect;


	public void Awake(){
		animator = gameObject.GetComponent<Animator> ();
		areaOfEffect.enabled = false;
	}

	// Use this for initialization
	void Start() {
		areaOfEffect.isTrigger = true;
		areaOfEffect.enabled = false;
	}

	// Update is called once per frame
	void Update() {

	}

	void FixedUpdate ()	{
		if ( Input.GetButtonDown("Fire1") && !isAttacking) {
			AttackStart();
		}

		if (Input.GetKeyDown(KeyCode.P)) {
			Debug.Log("Is attacking? " + isAttacking);
		}
	}

	public void AttackStart() {
		animator.SetBool("Attack", true);

		isAttacking = true;
		areaOfEffect.enabled = true;
	}

	public void AttackEnd() {
		isAttacking = false;
		areaOfEffect.enabled = false;
		
		animator.SetBool("Attack", false);
	}

}
