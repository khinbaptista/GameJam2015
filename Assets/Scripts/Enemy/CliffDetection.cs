using UnityEngine;
using System.Collections;

public class CliffDetection : MonoBehaviour {

	private int groundLayer;
	private bool nearCliff;

	public bool isNearCliff {
		get { return nearCliff; }
	}

	void Start() {
		groundLayer = LayerMask.NameToLayer("Ground");
		Debug.Log("Ground layer is " + groundLayer);
	}

	public void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.layer == groundLayer)
			nearCliff = false;
    }

	public void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.layer == groundLayer)
			nearCliff = true;
	}
}
