using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	[SerializeField]
	private float speed = 5;

	[SerializeField]
	private float damage = 10;

	[Tooltip("Leave Z component alone!")]
	public Vector3 direction;

	void Start () {
		direction.Normalize();
	}
	
	void Update () {
		transform.position += direction * speed * Time.deltaTime;
	}

	public void OnTriggerEnter2D(Collider2D other) {
		IHitable victim = other.GetComponent<IHitable>();

		if (victim != null) {
			victim.OnHit(damage);
		}

		Destroy(gameObject);
	}
}
