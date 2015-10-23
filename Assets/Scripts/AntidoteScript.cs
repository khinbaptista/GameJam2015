using UnityEngine;
using System.Collections;

public class AntidoteScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.tag);
        if(col.gameObject.tag == "Player")
        {
            Application.LoadLevel("Ending");
        }
    }
}
