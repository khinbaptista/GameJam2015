using UnityEngine;
using System.Collections;

public class SpecialAttack : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetButtonDown ("Fire2")) {
			animator.SetBool("Special", true);
			Debug.Log("Special set");
		}	
	}
}
