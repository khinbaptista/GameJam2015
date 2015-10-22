using UnityEngine;
using System.Collections;

public class bossLightning : MonoBehaviour {

	public bool isActive = false;
	public float lightDamage;
	private Player player;
	private Animator animator;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Character").GetComponent<Player>();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Random.value > 0.993) && !isActive) {
			this.gameObject.transform.position = gameObject.transform.parent.TransformPoint (Random.Range(-5, 5), this.gameObject.transform.parent.position.y + 10, 0);
			isActive = true;
			animator.SetBool("Active", true);
			Debug.Log (this.gameObject.transform.position.x + " " + GameObject.Find("Character").transform.position.x);
			if(this.gameObject.transform.position.x > (GameObject.Find("Character").transform.position.x - 1)) {
				if(this.gameObject.transform.position.x < (GameObject.Find("Character").transform.position.x + 1)) {
					player.OnHit(lightDamage);
				}
			}
		}
	}

	public void LightningEnd() {
		isActive = false;
		animator.SetBool("Active", false);
	}
}
