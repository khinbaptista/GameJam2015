using UnityEngine;
using System.Collections;

public class Poison : MonoBehaviour {

	[SerializeField]
	private float max = 100;

	[SerializeField] [Tooltip("this * poison% / s")]
	private float damageOverTime;

	[SerializeField] [Tooltip("this * poison% / attack")]
	private float damageBonus;

	[SerializeField] [Tooltip("this * poison%")] [Range(1f, 5f)]
	private float speedBonus;

	private Animator anim;
	
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

	public void AddPoison(float deltaPoison) {
		PoisonLevel += deltaPoison;
	}

	private void UpdateAnimationSpeed() {
		anim.speed = 1 + SpeedBonus;
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
