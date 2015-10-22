using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
	public bool IsAttacking = false;
	private Animator animator;
	public AudioSource hitSound;
	
	public Collider2D areaOfEffect;
	private Enemy enemy;

    private bool needDeactivateTrigger = false;
	
	public void Awake(){
		animator = gameObject.GetComponent<Animator> ();
		areaOfEffect.enabled = false;

		enemy = GetComponent<Enemy>();
		if (enemy == null)
			Debug.Log("Enemy not found");
	}
	
	// Use this for initialization
	void Start() {
		areaOfEffect.isTrigger = true;
		areaOfEffect.enabled = false;
		hitSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update() {

        if (needDeactivateTrigger)
            areaOfEffect.enabled = false;
    }
	
	public void AttackStart() {
		if (!IsAttacking && !enemy.IsDead) {
			//Debug.Log ("Enemy attack start");
			IsAttacking = true;
			
			animator.SetTrigger("Attack");
			//Debug.Log("Trigger set");
		}
	}

	public void AttackHit() {
		hitSound.Play();
        areaOfEffect.enabled = true;
	    needDeactivateTrigger = true;
	}
	
	public void AttackEnd() {
		//Debug.Log("Enemy attack end");
		IsAttacking = false;
		//areaOfEffect.enabled = false;
	}
	
}