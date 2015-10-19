using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{

	public Collider2D areaOfEffect;
	public float attackPower;

	// Use this for initialization
	void Start() {
		areaOfEffect.isTrigger = true;
		areaOfEffect.enabled = false;
	}

	// Update is called once per frame
	void Update() {

	}

	public void AttackStart() {
		areaOfEffect.enabled = true;
	}

	public void AttackEnd() {
		areaOfEffect.enabled = false;
	}

	public void OnTriggerEnter2D(Collider2D other) {
		Enemy enemy = other.gameObject.GetComponent<Enemy>();

		if (!enemy) return;

		enemy.OnHit(attackPower);
	}
}
