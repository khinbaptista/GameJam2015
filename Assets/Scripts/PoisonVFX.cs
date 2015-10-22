using UnityEngine;
using System.Collections;

public class PoisonVFX : MonoBehaviour {
	private Animator anim;

	void Start() {
		anim = GetComponent<Animator>();
	}

	void Update() {

	}

	public void Play() {
		Debug.Log("Play poison VFX!");
		anim.SetTrigger("Play");
	}
}
