using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IHitable {
	
	
	public float MaxHp = 100;

    [SerializeField]
    private float _currentHp;

    private Animator _animator;
    public int PotionAmount;
    public float MoveRate;
	public float DamageAmount;

	public bool IsAttacking = false;

	public bool IsDead
	{
	    get { return _currentHp <= 0.0f; }
	}

    public float CurrentHp
    {
        get { return _currentHp; }
        set { _currentHp = value; }
    }




    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Heal"))
        {
            if (PotionAmount > 0)
            {
                PotionAmount--;
                this._currentHp += 20;
                if (_currentHp > MaxHp)
                {
                    _currentHp = MaxHp;
                }
            }
        }

        if (IsDead)
        {
            _currentHp = 0;
            _animator.SetTrigger("Death");
            this.enabled = false;
        }
    }
	

	public void OnHit(float attackPower, float poison = 0) {
		if (IsDead)
			return;

        _currentHp -= attackPower;
	}
}
