using UnityEngine;
using System.Collections;
using UnityEngine.UI;   

public class HPBarScript : MonoBehaviour {
    public float HPMax;
    public float CurrentHP;
    public Image HPBar;
    public Image DamageBar;
    private float _imageMaxSize;
    // Use this for initialization
    void Start () {
        this._imageMaxSize = HPBar.rectTransform.sizeDelta.x;
	}
	
	// Update is called once per frame
	void Update () {

        float imageCurrentSize = this._imageMaxSize * this.CurrentHP / HPMax;

        HPBar.rectTransform.sizeDelta =
            new Vector2(
                imageCurrentSize,
                HPBar.rectTransform.sizeDelta.y
            );      

	}
}
