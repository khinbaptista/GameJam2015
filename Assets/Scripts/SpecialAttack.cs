using UnityEngine;
using System.Collections;

public class SpecialAttack : MonoBehaviour {
	[SerializeField][Tooltip("Minimum % of poison to perform Special Attack")][Range(0, 1)]
	private float minPoison;

	[SerializeField][Tooltip("Cooldown in seconds")]
	private float cooldown = 5;
	[SerializeField] private bool waitingCooldown = false;

	private Poison poisonRef;

	[SerializeField]
	private float damage = 20;

	private Animator animator;
	[SerializeField] private float timer;

	private Collider2D areaOfEffect;
	
	void Start () {
		animator = GetComponent<Animator>();
		poisonRef = GetComponentInParent<Poison>();

		areaOfEffect = GetComponent<Collider2D>();
		areaOfEffect.enabled = false;
	}
	
	void Update () {
		if (Input.GetButtonDown("Fire2") && CanUseSpecial())
			PerformSpecialAttack();

		if (waitingCooldown) {
			timer -= Time.deltaTime;

			if (timer <= 0.0f) {
				timer = 0f;
				waitingCooldown = false;
			}
		}
	}

	private bool CanUseSpecial() {
		if (poisonRef == null)
			Debug.Log("WTF");

		return !waitingCooldown && poisonRef.PoisonLevelScaled >= minPoison;
	}

	private void PerformSpecialAttack() {
		animator.SetTrigger("Special");

		timer = cooldown;
		waitingCooldown = true;

		areaOfEffect.enabled = true;
	}

	public void SpecialAttackEnd() {
		areaOfEffect.enabled = false;
	}

	public void OnTriggerEnter2D(Collider2D other) {
		IHitable victim = other.gameObject.GetComponent<IHitable>();

		if (victim == null)
			return;

		if (!victim.IsDead)
			victim.OnHit(damage);
	}
}
