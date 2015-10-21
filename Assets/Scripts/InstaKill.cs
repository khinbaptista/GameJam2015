using UnityEngine;
using System.Collections;

public class InstaKill : MonoBehaviour {

	private Collider2D area;

	void Start () {
		area = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other) {
		IHitable victim = other.gameObject.GetComponent<IHitable>();

		if (victim == null)
			return;

		victim.OnHit(victim.CurrentHp);
	}
}
