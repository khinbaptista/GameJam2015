using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
    private Player _player;
	// Use this for initialization
	void Start () {
        this._player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_player.IsDead)
        {
            foreach(Transform go in transform)
            {
                go.gameObject.SetActive(true);
            }
        }
	}
}
