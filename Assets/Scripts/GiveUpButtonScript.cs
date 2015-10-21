using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GiveUpButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GetComponentInChildren<Text>().text = "Give Up";

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
