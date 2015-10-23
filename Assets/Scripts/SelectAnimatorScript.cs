using UnityEngine;
using System.Collections;

public class SelectAnimatorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject savior = GameObject.FindGameObjectWithTag("Player");
        Animator animSavior = savior.GetComponentInChildren<Animator>();
        RuntimeAnimatorController maleAC = GameObject.Find("Ghost").GetComponentInChildren<Animator>().runtimeAnimatorController;
        if (PlayerPrefs.GetInt("Player") == 1)
        {
            animSavior.runtimeAnimatorController = maleAC;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
