using UnityEngine;
using System.Collections;

public class MonstersControl : MonoBehaviour {
    int monstersAlive;

	// Use this for initialization
	void Start () {
        monstersAlive = 8;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public int getNumberOfMonsterAlive() {
        return monstersAlive;
    }

    public void decrementMonsterAlive() {
        monstersAlive--;
    }
}
