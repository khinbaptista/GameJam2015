using UnityEngine;
using System.Collections;

public class TextDelete : MonoBehaviour {

	public GameObject text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Chamou");
		if (other.gameObject.name == "Character") {
			Debug.Log ("Entrou");
			text.SetActive(false);
		}
	}
}
