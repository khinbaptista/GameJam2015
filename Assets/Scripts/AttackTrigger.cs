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
		IHitable enemy = other.gameObject.GetComponent<IHitable>();
		Debug.Log(enemy);
		if (enemy == null) return;
		
		enemy.OnHit(attackPower);
	}
}
