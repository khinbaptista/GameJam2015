using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotionCounterScript : MonoBehaviour {
    private Text _potionAmount;
    private Player _player;
	// Use this for initialization
	void Start () {
        this._player = (Player)FindObjectOfType(typeof(Player));
        string amount = this._player.PotionAmount.ToString();
        foreach (Text text in GetComponents<Text>()){
            if(text.name == "PotionCountText"){
                this._potionAmount = text;
            }
        }
        this._potionAmount.text = amount; 
	}
	
	// Update is called once per frame
	void Update () {
        string amount = this._player.PotionAmount.ToString();
        this._potionAmount.text = amount;
    }
}
