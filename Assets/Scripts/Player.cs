using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IHitable {
	
	[SerializeField]
	private float _HP = 4000;
    private float _currentHP;
    private Animator animator;
    private int _potionAmount;
    public float moveRate;
	public float damageAmount;
	public bool isAttacking = false;

	private bool isDead {
		get { return _HP <= 0.0f; }
	}
	
	public float HP {
		get { return _HP; }
        set { _HP = value; }
	}

    public float CurrentHP {
        get { return _currentHP; }
        set { _currentHP = value; }
    }

    public int PotionAmount
    {
        get { return _potionAmount; }
        set { _potionAmount = value; }
    }

    // Use this for initialization
    void Start () {
        this._currentHP = this._HP;
        animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
				
	}
	

	public void OnHit(float attackPower) {
		if (isDead)
			return;

		_HP -= attackPower;
		if (isDead) {
            _HP = 0;
			animator.SetTrigger("Death");
		}
	}
}
