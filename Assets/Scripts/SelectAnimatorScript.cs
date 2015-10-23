using UnityEngine;
using UnityEditor;
using System.Collections;

public class SelectAnimatorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject savior = GameObject.FindGameObjectWithTag("Player");
        string pathMale = "Assets/Animations/Characters/Female/FemaleAC.controller";
        string pathFemale = "Assets/Animations/Characters/Male/MaleAC.overrideController";
        Animator animSavior = savior.GetComponentInChildren<Animator>();

        if (PlayerPrefs.GetInt("Payer") == 0)
        {
            animSavior.runtimeAnimatorController =
                (RuntimeAnimatorController)AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>(pathFemale);
        }
        else
        {
            animSavior.runtimeAnimatorController =
                (RuntimeAnimatorController)AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>(pathMale);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
