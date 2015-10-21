using UnityEngine;
using System.Collections;

public interface IHitable{
	float HP { get; }
	bool isDead { get; }

	void OnHit(float damage);
}
