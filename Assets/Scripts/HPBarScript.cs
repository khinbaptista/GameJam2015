using UnityEngine;
using System.Collections;
using UnityEngine.UI;   

public class HPBarScript : MonoBehaviour {
    public Player player;
    public Image HPBar;
    private float _imageMaxSize;
    // Use this for initialization
    void Awake () {
        this._imageMaxSize = HPBar.rectTransform.sizeDelta.x;
        this.player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        float imageCurrentSize = this._imageMaxSize * this.player.CurrentHP / this.player.HP;

        HPBar.rectTransform.sizeDelta =
            new Vector2(
                imageCurrentSize,
                HPBar.rectTransform.sizeDelta.y
            );      

	}
}
