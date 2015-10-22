using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	public float attackPower;
	public float attackBonus;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other) {
        IHitable enemy = other.gameObject.GetComponent<IHitable>();
        if (enemy == null) return;     
        if (gameObject.CompareTag(other.gameObject.tag)) return;

        if (!enemy.IsDead)
			enemy.OnHit(attackPower + attackBonus);
	}
}
