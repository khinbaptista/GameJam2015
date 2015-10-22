using UnityEngine;
using System.Collections;

public class TextDelete : MonoBehaviour {

	private GameObject text;

	// Use this for initialization
	void Start () {
		text = GameObject.Find ("Speech1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Chamou");
		if (other.gameObject.name == "Character") {
			Debug.Log ("Entrou");
			Destroy (text);
		}
	}
}
