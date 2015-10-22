using UnityEngine;
using System.Collections;
using UnityEngine.UI;   

public class VenomBarScript : MonoBehaviour {
    private Poison _playerPosion;
    public Image VenomBar;
    private float _imageMaxSize;
    // Use this for initialization
    void Awake () {
        this._imageMaxSize = VenomBar.rectTransform.sizeDelta.x;
        this._playerPosion = GameObject.FindObjectOfType<Poison>();
	}
	
	// Update is called once per frame
	void Update () {

        float imageCurrentSize = this._imageMaxSize * this._playerPosion.PoisonLevelScaled;

        VenomBar.rectTransform.sizeDelta =
            new Vector2(
                imageCurrentSize,
                VenomBar.rectTransform.sizeDelta.y
            );      

	}
}
