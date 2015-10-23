using UnityEngine;
using System.Collections;
using UnityEngine.UI;   

public class EnemyHPBar : MonoBehaviour {
	private Enemy enemy;
	public Image HpBar;
	private float _imageMaxSize;

	// Use this for initialization
	void Awake () {
		this._imageMaxSize = HpBar.rectTransform.sizeDelta.x;
		this.enemy = GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
		
		float imageCurrentSize = this._imageMaxSize * this.enemy.CurrentHp / this.enemy.MaxHp;
		
		HpBar.rectTransform.sizeDelta =
			new Vector2(
				imageCurrentSize,
				HpBar.rectTransform.sizeDelta.y
				);      
		
	}
}