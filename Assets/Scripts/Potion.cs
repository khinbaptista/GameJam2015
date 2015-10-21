﻿using UnityEngine;
using System.Collections;

public class Potion : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Potion collided");
        if (other.gameObject == GameObject.Find("Character")) {
            other.gameObject.GetComponent<Player>().potionAmount += 1;
			Destroy (gameObject);
		}
	}
}
