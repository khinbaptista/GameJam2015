using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IHitable {

	[SerializeField]
	private float _currentHp;
	public float MaxHp;

	public float moveRate;
	public float damageAmount;
	public bool isAttacking = false;
	public float potionChance;
	private Animator animator;
    private MonstersControl control;
	private MovementAI movement;

	[Range(0, 1)][Tooltip("Minimum level of poison (%) required to damage this actor")]
	public float minimumPoison;

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
        control = GetComponent<MonstersControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnHit(float attackPower, float poison = 0) {
		if (poison < minimumPoison) {
			Debug.Log("Attack failed! Minimum poison required is " + minimumPoison
				+ ", and the attack had poison " + poison);
			return;
		}

		_currentHp -= attackPower;
		if (_currentHp <= 0) {
			animator.SetTrigger("Death");
			if(Random.value < potionChance) {
				GameObject potion = (GameObject)Instantiate(Resources.Load("Potion"));
				Vector2 potionPos = this.transform.position;
				potionPos.y += 2;
				potion.transform.position = potionPos;
			}
            control.decrementMonsterAlive();
		}
	}
}
