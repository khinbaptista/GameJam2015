using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	[SerializeField]
	private float speed = 5;

	[SerializeField]
	private float damage = 10;

    [SerializeField]
    private float maximumDifference = 10;

    [SerializeField]
    private Collider2D startBound;

	[Tooltip("Leave Z component alone!")]
	public Vector3 direction;

    private Vector3 originalPosition;

	void Start () {
		direction.Normalize();
        originalPosition = transform.position;
	}
	
	void Update () {
        transform.position += direction * speed * Time.deltaTime;
        if (transform.position.x <= startBound.transform.position.x) {
            transform.position = originalPosition;
        }
	}

	public void OnTriggerEnter2D(Collider2D other) {
		IHitable victim = other.GetComponent<IHitable>();
        if (other.gameObject == GameObject.Find("Character")) {
			victim.OnHit(damage);
            Destroy(gameObject);
		}
	}
}
