using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
	private bool isAttacking = false;
	private Animator animator;
	public AudioSource hitSound;
	
	public Collider2D areaOfEffect;
	private Enemy enemy;
	
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
		
	}
	
	public void AttackStart() {
		if (!isAttacking && !enemy.IsDead) {
			Debug.Log ("Enemy attack start");
			isAttacking = true;
			areaOfEffect.enabled = true;
			animator.SetTrigger("Attack");
			hitSound.Play();
			Debug.Log("Trigger set");
		}
	}
	
	public void AttackEnd() {
		Debug.Log("Enemy attack end");
		isAttacking = false;
		areaOfEffect.enabled = false;
	}
	
}