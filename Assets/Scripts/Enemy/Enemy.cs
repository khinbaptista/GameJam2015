using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IHitable {

	[SerializeField]
	private float _HP;
	public float moveRate;
	public float damageAmount;
	public bool isAttacking = false;
	private Animator animator;

	private MovementAI movement;

	public float HP {
		get { return _HP; }
	}

	public bool isDead {
		get { return _HP <= 0; }
	}

	// Use this for initialization
	void Start () {
		movement = GetComponent<MovementAI>();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnHit(float attackPower) {
		_HP -= attackPower;
		if (_HP <= 0) {
			animator.SetTrigger("Death");
		}
	}
}
