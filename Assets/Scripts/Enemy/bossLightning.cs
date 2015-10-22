using UnityEngine;
using System.Collections;

public class bossLightning : MonoBehaviour {

	public bool isActive = false;
	public float lightDamage;
	private Player player;
	private Animator animator;
	private Enemy enemy;
	private GameObject character;
	private Transform myTransform;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Character").GetComponent<Player>();
		animator = GetComponent<Animator> ();
		enemy = GetComponentInParent<Enemy> ();
		character = GameObject.Find ("Character");
		myTransform = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Random.value > 0.993) && !isActive && !enemy.IsDead) {
			myTransform.position = gameObject.transform.parent.TransformPoint (Random.Range(-5, 5), myTransform.parent.position.y + 10, 0);
			isActive = true;
			animator.SetBool("Active", true);
		}
	}

	public void LightningEnd() {
		isActive = false;
		if(myTransform.position.x > (character.transform.position.x - 1)) {
			if(myTransform.position.x < (character.transform.position.x + 1)) {
				player.OnHit(lightDamage);
			}
		}
		animator.SetBool("Active", false);
	}
}
