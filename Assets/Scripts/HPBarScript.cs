using UnityEngine;
using System.Collections;
using UnityEngine.UI;   

public class HPBarScript : MonoBehaviour {
    public Player Player;
    public Image HpBar;
    private float _imageMaxSize;
    // Use this for initialization
    void Awake () {
        this._imageMaxSize = HpBar.rectTransform.sizeDelta.x;
        this.Player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        float imageCurrentSize = this._imageMaxSize * this.Player.CurrentHp / this.Player.MaxHp;

        HpBar.rectTransform.sizeDelta =
            new Vector2(
                imageCurrentSize,
                HpBar.rectTransform.sizeDelta.y
            );      

	}
}
