using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IdentifierScript : MonoBehaviour {
    public bool savior = false;
    public Image saviorImage;
    public Image toSaveImage;

    // Use this for initialization
    void Start() {
        
        if (PlayerPrefs.GetInt("Player") == 0)
        {
            toSaveImage = saviorImage;
            saviorImage = GameObject.Find("HerHead").GetComponentInChildren<Image>();

        }
    }
    // Update is called once per frame
    void Update () {
        if (savior)
        {
            saviorImage.gameObject.SetActive(true);
            toSaveImage.gameObject.SetActive(false);
        }
        else
        {
            saviorImage.gameObject.SetActive(false);
            toSaveImage.gameObject.SetActive(true);
        }
	}
	
}
