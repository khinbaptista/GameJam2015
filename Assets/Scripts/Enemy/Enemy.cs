using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IHitable {

	[SerializeField]
	private float _currentHp;

	public float moveRate;
	public float damageAmount;
	public bool isAttacking = false;
	private Animator animator;

	private MovementAI movement;

	public float CurrentHp {
		get { return _currentHp; }
	}

	public bool IsDead {
		get { return _currentHp <= 0; }
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
		_currentHp -= attackPower;
		if (_currentHp < 0) {
			animator.SetTrigger("Death");
		}
	}
}
