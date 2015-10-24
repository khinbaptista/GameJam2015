using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
                PlayerPrefs.SetInt("Player", 0);
                Application.LoadLevel("Intro");
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                PlayerPrefs.SetInt("Player", 0);
                Application.LoadLevel("Intro");
            }
        }

    }

}
