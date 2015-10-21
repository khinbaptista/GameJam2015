using UnityEngine;
using System.Collections;

public class NextPhase : MonoBehaviour {
    MonstersControl control;

	// Use this for initialization
	void Start () {
        control = GetComponent<MonstersControl>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 75.0f && control.getNumberOfMonsterAlive() == 0) {
            Application.LoadLevel("desertScene");
        }
	}
}
