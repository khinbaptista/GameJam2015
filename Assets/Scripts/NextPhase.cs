using System;
using UnityEngine;
using System.Collections;

public class NextPhase : MonoBehaviour
{

    public String nextSceneName;

    private int NumberOfMonstersAlive 
    {
        get { return GameObject.FindGameObjectsWithTag("Enemies").Length; }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (NumberOfMonstersAlive == 0) {
            Application.LoadLevel(nextSceneName);
        }
	}
}
