using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContinueButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponentInChildren<Text>().text = "Continue";
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
