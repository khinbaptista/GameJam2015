using UnityEngine;
using System.Collections;

public class Poison : MonoBehaviour {

	[SerializeField]
	private float max = 100;

	[SerializeField] [Tooltip("this * poison% / s")]
	private float damageOverTime = 5;

	[SerializeField] [Tooltip("this * poison% / attack")]
	private float damageBonus = 5;

	[SerializeField] [Tooltip("this * poison%")] [Range(1f, 5f)]
	private float speedBonus = 2f;

	private Animator anim;
	private Player player;

	[SerializeField][Tooltip("Amount of poison increased at once")]
	private float deltaPoison = 5;

	[Tooltip("Amount of poison decreased per second")]
	public float poisonDecreaseRate = 5;

	[SerializeField] [Range(0, 100)]
	private float poisonLevel;
	public float PoisonLevel {
		set {
			poisonLevel = Mathf.Clamp(value, 0f, max);
			UpdateAnimationSpeed();
		}

		get { return poisonLevel; }
	}

	public float PoisonLevelScaled {
		get { return PoisonLevel / max; }
	}

	public float DamageBonus {
		get {	return damageBonus * PoisonLevelScaled;	}
	}

	public float SpeedBonus {
		get { return speedBonus * PoisonLevelScaled; }
	}

	public void AddPoison(float _deltaPoison) {
		PoisonLevel += _deltaPoison;
	}

	private void UpdateAnimationSpeed() {
		anim.SetFloat("AttackSpeedModifier", 1 + SpeedBonus);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Poison")) {
			AddPoison(deltaPoison);
		}

		if (poisonLevel > 0.0f) {
			player.OnHit(damageOverTime * Time.deltaTime);
			PoisonLevel -= poisonDecreaseRate * Time.deltaTime;

			if (poisonLevel < 0)
				poisonLevel = 0.0f;
		}
	}
}
