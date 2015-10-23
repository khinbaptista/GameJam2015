using UnityEngine;
using UnityEditor;
using System.Collections;

public class WhoSavesScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject toSave = GameObject.Find("ToSave");
        GameObject savior = GameObject.Find("Savior");
        string pathMale = "Assets/Animations/Characters/Female/FemaleAC.controller";
        string pathFemale = "Assets/Animations/Characters/Male/MaleAC.overrideController";
        Animator animToSave = toSave.GetComponentInChildren<Animator>();
        Animator animSavior = savior.GetComponentInChildren<Animator>();

        if (PlayerPrefs.GetInt("Payer") == 0)
        {
            animToSave.runtimeAnimatorController =
                (RuntimeAnimatorController) AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>(pathFemale);
            animSavior.runtimeAnimatorController =
                (RuntimeAnimatorController)AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>(pathMale);
        }
        else
        {
            animToSave.runtimeAnimatorController =
                (RuntimeAnimatorController)AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>(pathMale);
            animSavior.runtimeAnimatorController =
                (RuntimeAnimatorController)AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>(pathFemale);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
