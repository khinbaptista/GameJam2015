using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	public float attackPower;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other) {
		Enemy enemy = other.gameObject.GetComponent<Enemy>();
		Debug.Log(enemy);
		if (!enemy) return;
		
		enemy.OnHit(attackPower);
	}
}
