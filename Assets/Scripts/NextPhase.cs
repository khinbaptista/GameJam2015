using System;
using UnityEngine;
using System.Collections;

public class NextPhase : MonoBehaviour
{

    public String nextSceneName;

    private bool AllMonstersDead 
    {
        get
        {
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Enemies"))
            {
                IHitable hitable = gameObject.GetComponent<IHitable>();
                if (hitable == null)
                    continue;
                if (!gameObject.GetComponent<IHitable>().IsDead)
                    return false;
            }

            return true;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (AllMonstersDead) {
            Application.LoadLevel(nextSceneName);
        }
	}
}
