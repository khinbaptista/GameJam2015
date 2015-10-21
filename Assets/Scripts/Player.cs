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
    }




    // Use this for initialization
    void Start () {
        this._currentHp = this.MaxHp;
        _animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
				
	}
	

	public void OnHit(float attackPower) {
		if (IsDead)
			return;

        _currentHp -= attackPower;
		if (IsDead) {
            _currentHp = 0;
			_animator.SetTrigger("Death");
		}
	}
}
