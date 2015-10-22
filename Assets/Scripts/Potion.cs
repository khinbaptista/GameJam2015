using UnityEngine;
using System.Collections;

public class Potion : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player")) {
            other.gameObject.GetComponent<Player>().PotionAmount += 1;
			Destroy (gameObject);
		}
	}
}
