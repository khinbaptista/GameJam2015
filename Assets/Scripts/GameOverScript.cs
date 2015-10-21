using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
    private Player _player;
	// Use this for initialization
	void Start () {
        this._player = (Player)FindObjectOfType(typeof(Player));
	}
	
	// Update is called once per frame
	void Update () {
        if (_player.isDead)
        {
            foreach(GameObject go in transform)
            {
                go.gameObject.SetActive(true);
            }
        }
	}
}
