using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	[SerializeField]
	private float speed;

	[SerializeField]
	private float damage;

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
