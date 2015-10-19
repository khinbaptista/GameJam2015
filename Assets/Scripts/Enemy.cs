using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IHitable {

	[SerializeField]
	private float _HP;

	public float HP {
		get { return _HP; }
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnHit(float attackPower) {

	}
}
