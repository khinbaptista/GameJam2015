using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IHitable {
	
	[SerializeField]
	private float _HP;
	private Animator animator;
	public float moveRate;
	public float damageAmount;
	public bool isAttacking = false;
	
	public float HP {
		get { return _HP; }
	}
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
				
	}
	
	public void OnHit(float attackPower) {
		_HP -= attackPower;
		if (_HP < 0) {
			animator.SetTrigger("Death");
		}
	}
}
