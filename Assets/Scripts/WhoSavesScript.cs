using UnityEngine;
using System.Collections;

public class WhoSavesScript : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        GameObject toSave = GameObject.Find("ToSave");
        GameObject savior = GameObject.Find("Savior");

        Animator animToSave = toSave.GetComponentInChildren<Animator>();
        Animator animSavior = savior.GetComponentInChildren<Animator>();
        RuntimeAnimatorController femaleAC = animSavior.runtimeAnimatorController;
        RuntimeAnimatorController maleAC = animToSave.runtimeAnimatorController;

        if (PlayerPrefs.GetInt("Player") == 0)
        {
            animToSave.runtimeAnimatorController =
                femaleAC;
            animSavior.runtimeAnimatorController =
                maleAC;
            PlayerPrefs.SetInt("Player", 1);
        }
        else
        {
            animToSave.runtimeAnimatorController =
                maleAC;
            animSavior.runtimeAnimatorController =
                femaleAC;
            PlayerPrefs.SetInt("Player", 0);
        }
        animSavior.Play("Dead");

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
