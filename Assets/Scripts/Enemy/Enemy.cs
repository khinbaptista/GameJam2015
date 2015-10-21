using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IHitable {

	[SerializeField]
	private float _maxHp;
	public float moveRate;
	public float damageAmount;
	public bool isAttacking = false;
	private Animator animator;

	private MovementAI movement;

	public float MaxHp {
		get { return _maxHp; }
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
		_maxHp -= attackPower;
		if (_maxHp < 0) {
			animator.SetTrigger("Death");
		}
	}
}
