using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VenomSplash : MonoBehaviour
{

    private Image _splashImage;
    private Player _player;
    public int StartingSplashPercent = 60;


    public void Awake()
    {
        this._splashImage = gameObject.GetComponent<Image>();
        this._player = GameObject.FindObjectOfType<Player>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Color color = _splashImage.color;
	    color.a = BloodAlpha(StartingSplashPercent);
        _splashImage.color = color;
    }

    private float BloodAlpha(int startingPercent)
    {
        float maxStartingHp = _player.MaxHp * ((float)startingPercent / 100.0f);
        float alpha = 1 - (_player.CurrentHp / maxStartingHp);
        return Mathf.Clamp(alpha, 0, 1);
    } 
}
