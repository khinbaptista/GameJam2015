using UnityEngine;
using System.Collections;

public class WhoSpeakScript : MonoBehaviour {
    public bool savior;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        IdentifierScript identifier = GameObject.Find("Speech2").GetComponentInChildren<IdentifierScript>();
        if (this.savior)
            identifier.savior = true;
        else
            identifier.savior = false;
    }
}
