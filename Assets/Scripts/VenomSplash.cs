using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VenomSplash : MonoBehaviour
{

    private Image _splashImage;
    private Poison _poison;
    public int StartingSplashPercent = 60;


    public void Awake()
    {
        this._splashImage = gameObject.GetComponent<Image>();
        this._poison = GameObject.FindObjectOfType<Poison>();
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
        //float maxStartingPoison = _poison.max * ((float)startingPercent / 100.0f);
        //float alpha = (_poison.PoisonLevel / maxStartingPoison);
        float alpha = (_poison.PoisonLevelScaled);
        return Mathf.Clamp(alpha, 0, 1);
    } 
}
