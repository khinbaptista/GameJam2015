using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VenomSplash : MonoBehaviour
{

    private Image splashImage;
    private Player player;


    public void Awake()
    {
        this.splashImage = gameObject.GetComponent<Image>();
        this.player = GameObject.FindObjectOfType<Player>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Color color = splashImage.color;
	    color.a = BloodAlpha();
        splashImage.color = color;
    }

    private float BloodAlpha() {
     float alpha = 1 - player.HP / player.CurrentHP;
     return Mathf.Clamp(alpha, 0, 1);
 }
}
